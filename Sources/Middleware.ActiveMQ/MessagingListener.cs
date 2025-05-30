/*
 * Licensed to the Apache Software Foundation (ASF) under one or more
 * contributor license agreements.  See the NOTICE file distributed with
 * this work for additional information regarding copyright ownership.
 * The ASF licenses this file to You under the Apache License, Version 2.0
 * (the "License"); you may not use this file except in compliance with
 * the License.  You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Collections;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Windows.Forms;
using System.Xml;
using Apache.NMS;
using Apache.NMS.ActiveMQ;
using Apache.NMS.ActiveMQ.Commands;
using Apache.NMS.Util;
using KR.MBE.CommonLibrary;
using log4net;
using log4net.Repository.Hierarchy;
using Newtonsoft.Json;


namespace Middleware.ActiveMQ
{

    public class Listener
    {
        //private string host = "192.168.0.14";
        private string m_sHostIP = "";

        private int m_iPort = 7001;
        private string m_sConnectionFacatoryName = "tmsConnection";
        private string m_sQueueName = "tmsQueue";
        private string m_sTopicName = "tmsTopic";
        private string m_sMonitorTopicName = String.Empty;
        private string m_sEisTopicName = String.Empty;
        private string m_sEcsTopicName = String.Empty;
        private int m_iReplyTimeOut = 5000;

        private string m_sClientID = String.Empty;
        private string m_sSubScriberID = String.Empty;
        private string m_sSyncID = String.Empty;
        private string m_sClientIP = String.Empty;
        private string m_sTargetSubject = String.Empty;
        private string m_sReplySubjectPrefix = String.Empty;
        private string m_sReplySubject = String.Empty;
        private string m_sInterfaceStructure = String.Empty;

        private string m_configFileName = "Middleware.ActiveMQ.xml";
        //private Middleware.Util m_oMiddlewareUtil = new Middleware.Util();
        private Hashtable htConfig = new Hashtable();


        //protected static AutoResetEvent semaphore = new AutoResetEvent(false);
        //protected static TimeSpan receiveTimeout = TimeSpan.FromSeconds(10);
        //private static string recvMessage = String.Empty;

        public delegate void OnMessageDelegate(string receivedMsg, string replyTo, string replyId);
        public event OnMessageDelegate ReceiveMessage;

        IConnectionFactory m_Connectionfactory = null;
        IConnection m_Connection = null;
        ISession m_Session = null;
        IDestination m_Destination = null;
        IMessageConsumer m_Consumer = null;
        IMessageProducer m_Producer = null;

        string connectionPath = String.Empty;


        public bool IsConnected
        {
            get { return m_Connection != null; }
        }

        // 
        private enum CreateContextType
        {
            OneTime = 0, EveryTime = 1
        }

        private CreateContextType m_CreateContextType = CreateContextType.OneTime;

        public Listener()
        {
            m_sClientIP = Middleware.ActiveMQ.Util.FindActiveIPAddress();
            htConfig = getConfigData();
            if (htConfig["REPLY"].ToString() == "OK")
            {
                m_sHostIP = htConfig["HostIP"].ToString();
                m_iPort = int.Parse(htConfig["Port"].ToString());
                m_sConnectionFacatoryName = htConfig["ConnectionFactoryName"].ToString();
                m_sQueueName = htConfig["QueueName"].ToString();
                m_sTopicName = htConfig["TopicName"].ToString();
                m_sEisTopicName = htConfig["EisTopicName"].ToString();
                m_sEcsTopicName = htConfig["TopicName"].ToString();
                m_sMonitorTopicName = htConfig["MonitorTopicName"].ToString();
                m_iReplyTimeOut = int.Parse(htConfig["ReplyTimeOut"].ToString());
                m_sClientID = htConfig["ClientID"].ToString();
                m_sReplySubjectPrefix = htConfig["ReplySubjectPrefix"].ToString();
                m_sTargetSubject = htConfig["TargetSubject"].ToString();
                m_sInterfaceStructure = htConfig["InterfaceStructure"].ToString();

                if (htConfig["CreateContextType"].ToString() == "OneTime")
                {
                    m_CreateContextType = CreateContextType.OneTime;
                }
                else if (htConfig["CreateContextType"].ToString() == "EveryTime")
                {
                    m_CreateContextType = CreateContextType.EveryTime;
                }
            }
            else
            {
                // Exception : Can Not Load Config File
            }
            m_sSyncID = "SYNCID01";    // 사용의미 확인힐것
            m_sClientID = m_sClientID + "-" + m_sClientIP; // Util.KeyGenerator.GetUniqueKey(4);
            m_sSubScriberID = m_sClientID;


        }

        ~Listener()
        {
            ListenClose();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Hashtable getConfigData()
        {
            if( htConfig.Count <= 1 )
            {
                String sFullPath = System.Environment.CurrentDirectory + @"\Config\" + m_configFileName;
                htConfig = Middleware.ActiveMQ.Util.ReadXml( sFullPath );
            }
            return htConfig;
        }

        public void Listen()
        {
            try
            {
                String sConnetURL = "tcp://" + htConfig["HostIP"].ToString() + ":" + htConfig["Port"].ToString();
                if (m_Connectionfactory == null)
                {
                    Uri connecturi = new Uri(sConnetURL);
                    m_Connectionfactory = new ConnectionFactory(connecturi);
                }
                if (m_Connection == null)
                {
                    if (m_Connectionfactory != null)
                    {
                        m_Connection = m_Connectionfactory.CreateConnection();
                    }
                }
                if (m_Session == null)
                {
                    m_Session = m_Connection.CreateSession();
                }

                if (m_Destination == null)
                {
                    //if ((htConfig.Contains("EisTopicName")) && htConfig["EisTopicName"].ToString().Length > 0)
                    if ((htConfig.Contains("TopicName")) && htConfig["TopicName"].ToString().Length > 0)
                    {
                        String listenerTopic = "topic://" + m_sTopicName;

                        m_Destination = SessionUtil.GetDestination(m_Session, listenerTopic);
                    }
                }

                if(m_Producer == null)
                {
                    m_Producer = m_Session.CreateProducer(null);
                }

                if (m_Consumer == null)
                {
                    // ReplySubjectPrefix 의 Subject 메세지만 수신함.
                    String selector = "subject like '" + m_sReplySubjectPrefix + "%'";
                    m_Consumer = m_Session.CreateDurableConsumer(m_Session.GetTopic(m_sTopicName), m_sReplySubjectPrefix, selector);
                }

                m_Connection.ExceptionListener += OnConnectionException;
                m_Connection.Start();
                m_Consumer.Listener += OnMessage;

                connectionPath = $"{sConnetURL}:{m_sTopicName}";

                Log.DebugLog($"{connectionPath} Connected");
            }
            catch (Exception ex)
            {
                Log.ErrorLog($"Connection exception: {ex.Message}");
            }
        }

        public void SendReply(string message, string replyTo, string replyId)
        {
            string sTransactionID = Middleware.ActiveMQ.Util.GetXMLRecord(message, "transactionid");
            string sTargetSubject = Middleware.ActiveMQ.Util.GetXMLRecord(message, "targetsubject");
            string sReplyTo = string.Empty;

            if (m_sInterfaceStructure.Equals("JSON"))
            {
                XmlDocument doc = new XmlDocument();
                message = message.Replace(@"<?xml version=""1.0"" encoding=""utf-8""?>", "");
                doc.LoadXml(message);
                message = JsonConvert.SerializeXmlNode(doc, Newtonsoft.Json.Formatting.Indented, false);
            }

            // ByteMessage 로 변경 -> Character set 이슈
            var byteMessage = System.Text.UTF8Encoding.UTF8.GetBytes(message);

            IBytesMessage response = m_Session.CreateBytesMessage(byteMessage);

            response.NMSCorrelationID = replyId;

            response.Properties["transactionid"] = sTransactionID;
            response.Properties["subject"] = sTargetSubject;
            
            
            if (replyTo.Contains('/') == true)
            { 
                int pos = replyTo.LastIndexOf('/');
                sReplyTo = replyTo.Substring(pos + 1);
            }
            else
            {
                sReplyTo = replyTo;
            }

            var destination = m_Session.GetTopic(sReplyTo);

            try
            {
                Log.DebugLog("Send ActiveMQ =====================================");
                Log.DebugLog(message);
                Log.DebugLog("===================================================");
                m_Producer.Send(destination, response);
            }
            catch (Exception ex)
            {

            }
        }


        public void ListenMonitoring()
        {
            try
            {
                String sConnetURL = "tcp://" + htConfig["HostIP"].ToString() + ":" + htConfig["Port"].ToString();
                if (m_Connectionfactory == null)
                {
                    Uri connecturi = new Uri(sConnetURL);
                    m_Connectionfactory = new ConnectionFactory(connecturi);
                }
                if (m_Connection == null)
                {
                    if (m_Connectionfactory != null)
                    {
                        m_Connection = m_Connectionfactory.CreateConnection();
                    }
                }
                if (m_Session == null)
                {
                    m_Session = m_Connection.CreateSession();
                }
                if (m_Destination == null)
                {
                    //if ((htConfig.Contains("EisTopicName")) && htConfig["EisTopicName"].ToString().Length > 0)
                    if ((htConfig.Contains("MonitorTopicName")) && htConfig["MonitorTopicName"].ToString().Length > 0)
                    {
                        String listenerTopic = "topic://" + m_sMonitorTopicName;

                        m_Destination = SessionUtil.GetDestination(m_Session, listenerTopic);
                    }
                }

                if (m_Consumer == null)
                {
                    // ReplySubjectPrefix 의 Subject 메세지만 수신함.
                    String selector = "subject like '" + m_sReplySubjectPrefix + "%'";
                    m_Consumer = m_Session.CreateConsumer(m_Destination, selector);
                }

                m_Connection.ExceptionListener += OnConnectionException;
                m_Connection.Start();
                m_Consumer.Listener += OnMessage;

                connectionPath = $"{sConnetURL}:{m_sMonitorTopicName}";
                Log.DebugLog($"{connectionPath} Connected");
            }
            catch (Exception ex)
            {
                Log.ErrorLog($"Connection exception: {ex.Message}");
            }
        }

        private void OnConnectionException(Exception ex)
        {
            Log.ErrorLog($"Connection exception: {ex.Message}");
            ListenClose();
        }


        public void Listen(string sTopicName, string sListenSubjectName)
        {
            try
            {
                String sConnetURL = "tcp://" + htConfig["HostIP"].ToString() + ":" + htConfig["Port"].ToString();
                if (m_Connectionfactory == null)
                {
                    Uri connecturi = new Uri(sConnetURL);
                    m_Connectionfactory = new ConnectionFactory(connecturi);
                }
                if (m_Connection == null)
                {
                    if (m_Connectionfactory != null)
                    {
                        m_Connection = m_Connectionfactory.CreateConnection();
                    }
                }
                if (m_Session == null)
                {
                    m_Session = m_Connection.CreateSession();
                }
                if (m_Destination == null)
                {
                    String listenerTopic = "topic://" + sTopicName;
                    m_Destination = SessionUtil.GetDestination(m_Session, listenerTopic);
                }
                if (m_Consumer == null)
                {
                    // Listen SubjectName 메세지만 수신함.
                    String selector = "subject like '" + sListenSubjectName + "%'";
                    m_Consumer = m_Session.CreateConsumer(m_Destination, selector);
                }

                m_Connection.ExceptionListener += OnConnectionException;
                m_Connection.Start();
                m_Consumer.Listener += OnMessage;

                connectionPath = $"{sConnetURL}:{sTopicName}";
                Log.DebugLog($"{connectionPath} Connected");

            }
            catch (Exception ex)
            {
                Log.ErrorLog($"Connection exception: {ex.Message}");
            }
        }

        public void ListenClose()
        {
            try
            {
                if (m_Consumer != null)
                {
                    m_Consumer.Listener -= OnMessage;
                    m_Consumer.Dispose();
                    m_Consumer = null;
                }
                if (m_Destination != null)
                {
                    //String listenerTopic = "topic://" + m_sMonitorTopicName;
                    //SessionUtil.DeleteDestination(m_Session, listenerTopic);
                    m_Destination.Dispose();
                    m_Destination = null;
                }
                if (m_Session != null)
                {
                    m_Session.Dispose();
                    m_Session = null;
                }
                if (m_Connection != null)
                {
                    m_Connection.Dispose();
                    m_Connection = null;
                }
                if (m_Connectionfactory != null)
                {
                    m_Connectionfactory = null;
                }

                Log.DebugLog($"{connectionPath} Disconnected");

            }
            catch (Exception ex)
            {
                Log.ErrorLog($"Connection exception: {ex.Message}");
            }
        }


        // IBytesMessage 변환후 처리
        protected void OnMessage(IMessage receivedMsg)
        {
            IBytesMessage recvMessage = null;
            ITextMessage txtMessage = null;
            String sReturnMessage = String.Empty;
            string sReturnReplyTo = string.Empty;
            string sReturnReplyId = string.Empty;

            if (receivedMsg.NMSReplyTo != null)
            {
                sReturnReplyTo = receivedMsg.NMSReplyTo.ToString();
                sReturnReplyId = receivedMsg.NMSCorrelationID;
            }

            if (receivedMsg.GetType().Name.Contains("TextMessage"))
            {
                txtMessage = (ITextMessage)receivedMsg;
                sReturnMessage = txtMessage.Text;
            }
            else if (receivedMsg.GetType().Name.Contains("BytesMessage"))
            {
                recvMessage = (IBytesMessage)((IBytesMessage)receivedMsg as IMessage);
                if (recvMessage != null)
                {
                    System.Text.Encoding utf8 = System.Text.Encoding.UTF8;
                    byte[] msg = new byte[(int)recvMessage.BodyLength];
                    recvMessage.ReadBytes(msg);
                    sReturnMessage = utf8.GetString(msg);
                }

            }

            if (m_sInterfaceStructure.Equals("JSON"))
            {
                XmlDocument docJson = JsonConvert.DeserializeXmlNode(sReturnMessage);
                sReturnMessage = docJson.DocumentElement.OuterXml;
            }

            ReceiveMessage(sReturnMessage, sReturnReplyTo, sReturnReplyId);
        }


    }
}