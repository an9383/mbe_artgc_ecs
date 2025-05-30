using System;
using System.Collections;
using System.Data;
using System.Text.Json;
using System.Windows.Forms;
using System.Xml;
using Apache.NMS.ActiveMQ.Commands;
using Azure.Core;
using KR.MBE.CommonLibrary;
using KR.MBE.Data.ActiveMQ;
using KR.MBE.Data.Models;
using KR.MBE.Message;
using KR.MBE.RCMS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Newtonsoft.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static KR.MBE.Data.CLT.YC.YCMethod;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Formatting = Newtonsoft.Json.Formatting;


namespace DataProcess
{
    public class InterfaceManager
    {
        private static InterfaceManager instance = null;

        private InterfaceManager()
        {

        }

        public static InterfaceManager getInstance()
        {
            instance ??= new InterfaceManager();

            return instance;
        }

        public string AliveCheck(string targetSubject)
        {
            var htConfig = MessageHandler.GetConfig();

            var htHeader = new Hashtable();
            var htBody = new Hashtable();
            var htReturn = new Hashtable();

            htHeader.Add("messagename", "AliveCheckReply");
            htHeader.Add("replysubject", "");
            htHeader.Add("sourcesubject", htConfig["ReplySubjectPrefix"]);
            htHeader.Add("targetsubject", targetSubject);
            htHeader.Add("transactionid", System.Guid.NewGuid());

            htReturn.Add("returnmessage", "");
            htReturn.Add("returndetailmessage", "");
            htReturn.Add("returncode", "0");
            htReturn.Add("returntype", "");

            return MessageHandler.GetSendMessageFormat(htHeader, htBody, htReturn);
        }

        public string MakeBodyDataString(DataTable dt)
        {
            var dataStr = "";

            if (dt == null)
                return dataStr;

            if (dt.Rows.Count > 0)
            {
                foreach (var row in dt.Rows)
                {
                    var data = (DataRow)row;
                    dataStr += "<DATA>";

                    foreach (DataColumn column in dt.Columns)
                    {

                        var str = data[column].ToString();

                        str = str.Replace("&", "&amp;");
                        str = str.Replace("<", "&lt;");
                        str = str.Replace(">", "&gt;");
                        str = str.Replace("'", "&apos;");
                        str = str.Replace(@"""", "&quot;");

                        dataStr += $"<{column}>{str}</{column}>";
                    }

                    dataStr += "</DATA>";
                }
            }
            else
            {
                dataStr += "<DATA>";

                foreach (DataColumn column in dt.Columns)
                {
                    dataStr += $"<{column}></{column}>";
                }

                dataStr += "</DATA>";
            }

            return dataStr;
        }


        public string GetInventoryForRCS(string targetSubject, string message)
        {
            var htConfig = MessageHandler.GetConfig();
            var receivedMessage = ParseReceviedMessage<GetInventoryForBody>(message);

            var htHeader = new Hashtable();
            var htBody = new Hashtable();
            var htReturn = new Hashtable();

            htHeader.Add("messagename", $"GetInventoryDataReply");
            htHeader.Add("replysubject", "");
            htHeader.Add("sourcesubject", htConfig["ReplySubjectPrefix"]);
            htHeader.Add("targetsubject", targetSubject);
            htHeader.Add("transactionid", System.Guid.NewGuid());


            var dt = QueryManager.getCustomQueryData("GetInventoryForRCS", "00001", receivedMessage.BindDictionary);
            var dataString = string.Empty;

            if (dt != null)
            {
                dataString = MakeBodyDataString(dt);
            }

            htBody.Add("DATALIST", dataString);

            htReturn.Add("returnmessage", "");
            htReturn.Add("returndetailmessage", "");
            htReturn.Add("returncode", "0");

            return MessageHandler.GetSendMessageFormat(htHeader, htBody, htReturn);
        }

        public string GetQueryResult(string targetSubject, string message)
        {
            var htConfig = MessageHandler.GetConfig();
            var receivedMessage = ParseReceviedMessage<GetQueryResultBody>(message);

            var htHeader = new Hashtable();
            var htBody = new Hashtable();
            var htReturn = new Hashtable();

            htHeader.Add("messagename", $"{receivedMessage.queryId}Reply");
            htHeader.Add("replysubject", "");
            htHeader.Add("sourcesubject", htConfig["ReplySubjectPrefix"]);
            htHeader.Add("targetsubject", targetSubject);
            htHeader.Add("transactionid", System.Guid.NewGuid());

            //SITE 테이블이 없어졌으므로 강제로 만들어줘야함.
            if (receivedMessage.queryId.Equals("GetSiteList", StringComparison.OrdinalIgnoreCase) == true)
            {
                htBody.Add("DATALIST", "<DATA><SITENAME>MBE</SITENAME><SITEID>MBE</SITEID><DISPLAYITEMNAME>MBE</DISPLAYITEMNAME></DATA>");
            }
            else
            {
                var dt = QueryManager.getCustomQueryData(receivedMessage.queryId, receivedMessage.queryVersion, receivedMessage.BindDictionary);
                var dataString = string.Empty;

                if (dt != null)
                {
                    dataString = MakeBodyDataString(dt);
                }

                htBody.Add("DATALIST", dataString);
            }

            htReturn.Add("returnmessage", "");
            htReturn.Add("returndetailmessage", "");
            htReturn.Add("returncode", "0");

            return MessageHandler.GetSendMessageFormat(htHeader, htBody, htReturn);
        }

        public string TxnLoginResult(string targetSubject, string message)
        {
            var htConfig = MessageHandler.GetConfig();

            var receivedMessage = ParseReceviedMessage<TxnLoginBody>(message);

            var htHeader = new Hashtable();
            var htBody = new Hashtable();
            var htReturn = new Hashtable();

            htHeader.Add("messagename", $"TxnLoginReply");
            htHeader.Add("replysubject", "");
            htHeader.Add("sourcesubject", htConfig["ReplySubjectPrefix"]);
            htHeader.Add("targetsubject", targetSubject);
            htHeader.Add("transactionid", System.Guid.NewGuid());

            var result = QueryManager.getLoginData(receivedMessage.userId, receivedMessage.userPassword);

            htReturn.Add("returnmessage", "");
            htReturn.Add("returndetailmessage", "");
            htReturn.Add("returncode", $"{(result ? "0" : "1")}");
            htReturn.Add("returntype", "");

            return MessageHandler.GetSendMessageFormat(htHeader, htBody, htReturn);
        }


        public string TxnRequestResult(string targetSubject, string messageName, string message)
        {
            var htConfig = MessageHandler.GetConfig();

            TxnRequestBody receivedMessage = new TxnRequestBody();

            if (string.IsNullOrEmpty(message) == false)
            {
                receivedMessage = ParseReceviedMessage<TxnRequestBody>(message);

                receivedMessage.pkColumnList.RemoveAll(s => s == "");
                receivedMessage.dataList.dataInfos.RemoveAll(s => s == null);
            }

            var htHeader = new Hashtable();
            var htBody = new Hashtable();
            var htReturn = new Hashtable();

            htHeader.Add("messagename", $"{messageName}Reply");
            htHeader.Add("replysubject", "");
            htHeader.Add("sourcesubject", htConfig["ReplySubjectPrefix"]);
            htHeader.Add("targetsubject", targetSubject);
            htHeader.Add("transactionid", System.Guid.NewGuid());

            var result = QueryManager.transactionRequestDb(messageName, receivedMessage);

            htReturn.Add("returnmessage", "");
            htReturn.Add("returndetailmessage", "");
            htReturn.Add("returncode", $"{(result ? "0" : "1")}");
            htReturn.Add("returntype", "");

            return MessageHandler.GetSendMessageFormat(htHeader, htBody, htReturn);
        }

        public T? ParseReceviedMessage<T>(string message)
        {
            dynamic receivedMessage = null;

            try
            {
                var xmlDoc = new XmlDocument();
                xmlDoc.LoadXml($"<root>{message}</root>");
                var jsonObj = JsonConvert.SerializeXmlNode(xmlDoc, Formatting.Indented, true);
                receivedMessage = JsonConvert.DeserializeObject<T>(jsonObj);
            } 
            catch (Exception ex)
            {
                Log.ErrorLog($"ParseReceviedMessage Error : {ex.Message}");
            }

            return receivedMessage;
        }

        public void TOSSendMessage(string messageName, Dictionary<string, string> mapBody)
        {
            if (string.IsNullOrEmpty(messageName)) return;
            //string sSubjectName = "PROD.KR.ITIER.TOS.TESTsvr";

            string sBodyList = "";
            sBodyList += "			<EVENTUSER>ECS</EVENTUSER> \r\n";

            //for (Iterator<Entry<string, string>> iterator = mapBody.entrySet().iterator(); iterator.hasNext();)
            //{
            //    Map.Entry<string, string> iterMap = (Map.Entry<string, string>)iterator.next();
            //    sBodyList += "			<" + iterMap.getKey() + ">" + iterMap.getValue() + "</" + iterMap.getKey() + "> \r\n";
            //}

            foreach (KeyValuePair<string, string> iterMap in mapBody)
            {
                sBodyList += "    <" + iterMap.Key + ">" + iterMap.Value + "</" + iterMap.Key + "> \r\n";
            }

            string sMsg = "	<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n"
                    + "	<message>\r\n"
                    + "		<header>\r\n"
                    + "			<messagename>" + messageName + "</messagename>\r\n"
                    + "			<replysubject></replysubject>\r\n"
                    + "			<sourcesubject></sourcesubject>\r\n"
                    + "			<targetsubject></targetsubject>\r\n"
                    + "			<transactionid></transactionid>\r\n"
                    + "		</header>\r\n"
                    + "		<body>\r\n"
                    + sBodyList
                    + "		</body>\r\n"
                    + "	</message>\r\n"
                    + "";

            Log.InfoLog(" TOSSendMessage ######################");
            Log.InfoLog(sMsg);

            // Message Header에 TargetSubject 가 존재하면 Reply Message가 발생한다.
            // Header 에 Subject 모두 Empty로 처리한다.
            //MESFrameProxy.getMessageService().send(sTOSSubjectName, TOSTopic, null, sMsg);

        }



        // StepComposition IFFunctionName과 무관하게 기존적으로 TOS에 보고해야 하는 Message 처리 
        // @param jobOrder
        // @param messageName
        public void TOSSendMessage(TbJoborder jobOrder, string messageName)
        {
            // JobAccept
            if (CommonConstant.IF_TOS_JOBACCEPT == (messageName))
            {
                Dictionary<string, string> mapData = new Dictionary<string, string>();
                mapData.Add("JOBORDERID", jobOrder.Joborderid );
                TOSSendMessage(messageName, mapData);
            }

            // JobReject
            if (CommonConstant.IF_TOS_JOBREJECT == (messageName))
            {
                Dictionary<string, string> mapData = new Dictionary<string, string>();
                mapData.Add("JOBORDERID", jobOrder.Joborderid);
                mapData.Add("REJECTCOMMENT", jobOrder.Rejectcomment );
                TOSSendMessage(messageName, mapData);
            }

            // JobCompleted
            if (CommonConstant.IF_TOS_JOBCOMPLETED == (messageName))
            {
                Dictionary<string, string> mapData = new Dictionary<string, string>();
                mapData.Add("JOBORDERID", jobOrder.Joborderid);
                TOSSendMessage(messageName, mapData);
            }

        }

        // StepComposition IFFunctionName에 설정된 Interface 처리 함수
        // @param viewJobTracking
        public bool ExecuteIFFunction(TbViewjobtracking viewJobTracking)
        {
            if ((string.IsNullOrEmpty(viewJobTracking.Startiffunctionname)==true ) 
                || (CommonConstant.IFFUNCTIONNAME_NONE == (viewJobTracking.Startiffunctionname)))
            {
                return false;
            }

            string messageName = viewJobTracking.Startiffunctionname;

            // JobCompleteITV
            if (CommonConstant.IFFUNCTIONNAME_JOBCOMPLETEITV == (viewJobTracking.Startiffunctionname))
            {
                Dictionary<string, string> mapData = new Dictionary<string, string>();
                mapData.Add("JOBORDERID", viewJobTracking.Joborderid);
                
                TOSSendMessage(messageName, mapData);
            }

            // WaitVehicleTimeOut
            if (CommonConstant.IFFUNCTIONNAME_WAITVEHICLETIMEOUT == (viewJobTracking.Startiffunctionname))
            {
                using (var dbcontext = new RcmsContext())
                {
                    TbJoborder? jobInfo = dbcontext.TbJoborders
                                                    .Where(e => e.Joborderid == viewJobTracking.Joborderid)
                                                    .FirstOrDefault();

                    if(jobInfo != null)
                    {
                        Dictionary<string, string> mapData = new Dictionary<string, string>();
                        mapData.Add("JOBORDERID", jobInfo.Joborderid);
                        mapData.Add("VEHICLEID", jobInfo.Vehicleid);

                        TOSSendMessage(messageName, mapData);
                    }
                }
            }

            // JobStart
            if (CommonConstant.IFFUNCTIONNAME_WAITVEHICLETIMEOUT == (viewJobTracking.Startiffunctionname))
            {
                Dictionary<string, string> mapData = new Dictionary<string, string>();
                mapData.Add("JOBORDERID", viewJobTracking.Joborderid);

                TOSSendMessage(messageName, mapData);
            }

            // TOSReport
            if (CommonConstant.IFFUNCTIONNAME_WAITVEHICLETIMEOUT == (viewJobTracking.Startiffunctionname))
            {
                Dictionary<string, string> mapData = new Dictionary<string, string>();
                mapData.Add("JOBORDERID", viewJobTracking.Joborderid);

                TOSSendMessage(messageName, mapData);
            }

            // ChassisUpdate
            if (CommonConstant.IFFUNCTIONNAME_WAITVEHICLETIMEOUT == (viewJobTracking.Startiffunctionname))
            {
                using (var dbcontext = new RcmsContext())
                {
                    TbJoborder? jobInfo = dbcontext.TbJoborders
                                                    .Where(e => e.Joborderid == viewJobTracking.Joborderid)
                                                    .FirstOrDefault();

                    if (jobInfo != null)
                    {
                        Dictionary<string, string> mapData = new Dictionary<string, string>();
                        mapData.Add("JOBORDERID", jobInfo.Joborderid);
                        mapData.Add("VEHICLEID", jobInfo.Vehicleid);
                        mapData.Add("CONTAINERID", jobInfo.Containerid);

                        TOSSendMessage(messageName, mapData);
                    }
                }
            }

            return true;

        }

        public string TxnAddBlockResult(string targetSubject, string message)
        {
            var htConfig = MessageHandler.GetConfig();

            var blockData = ParseReceviedMessage<TxnAddBlockBody>(message);

            var time = DateTime.Now;

            bool result = false;
            string errMessage = "";
            string errStack = "";

            if (blockData != null)
            {
                try
                {
                    using (var dbcontext = new RcmsContext())
                    {
                        // delete existing block
                        var existingBlock = dbcontext.TbBlocks
                            .Where(e => e.Blockid == blockData.BlockID)
                            .FirstOrDefault();

                        if(existingBlock != null)
                        {
                            dbcontext.Remove(existingBlock);
                            dbcontext.TbBays.RemoveRange(dbcontext.TbBays.Where(e => e.Blockid == blockData.BlockID));
                            dbcontext.TbRows.RemoveRange(dbcontext.TbRows.Where(e => e.Blockid == blockData.BlockID));
                            dbcontext.TbTiers.RemoveRange(dbcontext.TbTiers.Where(e => e.Blockid == blockData.BlockID));
                        }

                        // add block
                        var block = new TbBlock();
                        block.Blockid = blockData.BlockID;
                        block.Blockname = blockData.BlockName;
                        block.Blocktype = blockData.BlockType;
                        block.Useflag = blockData.UseFlag;
                        block.Baydirection = blockData.BayDirection;
                        block.Rowdirection = blockData.RowDirection;
                        block.Itvdirection = blockData.ItvDirection;
                        block.Baseflag = blockData.BaseFlag;
                        block.Gantryposition = 0;
                        block.Maxgantryposition = blockData.MaxGantryPosition;
                        block.Maxtrolleyposition = blockData.MaxTrolleyPosition;
                        block.Maxhoistposition = blockData.MaxHoistPosition;

                        block.Lastupdatetime = time;
                        block.Lastupdateuserid = blockData.EventUser;

                        dbcontext.TbBlocks.Add(block);

                        int baySize = blockData.BayDistance;
                        int halfBaySize = baySize / 2;


                        int endBayNum = blockData.BayCount * 2 - 1;

                        int gantryposition = halfBaySize;
                        int walkwayCount = 0;

                        // add bays
                        for (int i = 1; i <= endBayNum; i++)
                        {
                            bool odd = (i % 2) == 1;


                            var bay = new TbBay();
                            bay.Blockid = blockData.BlockID;
                            bay.Bayid = $"B{i:D2}";
                            bay.Bayname = $"B{i:D2}";
                            bay.Bayindex = i;
                            bay.Useflag = "True";

                            if (odd)
                            {
                                bay.Baysize = "20ft";
                                bay.Baywidth = baySize;

                                if(walkwayCount < blockData.WalkwayInterval)
                                {
                                    walkwayCount++;
                                }
                                else
                                {
                                    walkwayCount = 0;
                                    gantryposition += blockData.WalkwayWidth;
                                }

                            }
                            else
                            {
                                bay.Baysize = "40ft";
                                bay.Baywidth = baySize * 2;
                            }

                            bay.Gantryposition = gantryposition;
                            gantryposition += halfBaySize;

                            bay.Posx = 0;
                            bay.Posy = 0;

                            bay.Bayheight = blockData.MaxHoistPosition;

                            bay.Lastupdatetime = time;
                            bay.Lastupdateuserid = blockData.EventUser;

                            dbcontext.TbBays.Add(bay);

                            int trolleyStart = blockData.RowDistance / 2;
                            int trolleyPosition = trolleyStart;

                            // add row
                            for (int j = 1; j <= blockData.RowCount; j++)
                            {
                                var row = new TbRow();
                                row.Blockid = blockData.BlockID;
                                row.Bayid = bay.Bayid;
                                row.Rowid = $"R{j:D2}";
                                row.Rowname = $"R{j:D2}";
                                row.Rowindex = j;
                                row.Useflag = "True";
                                row.Workinglaneflag = "False";
                                row.Trolleyposition = trolleyPosition;
                                row.Posx = 0;
                                row.Posy = 0;
                                trolleyPosition += blockData.RowDistance;

                                row.Lastupdatetime = time;
                                row.Lastupdateuserid = blockData.EventUser;

                                dbcontext.TbRows.Add(row);

                                // add tier
                                int defaultTierHeight = 2390;

                                for (int k = 1; k<= blockData.TierCount; k++)
                                {
                                    var tier = new TbTier();
                                    tier.Blockid = blockData.BlockID;
                                    tier.Bayid = bay.Bayid;
                                    tier.Rowid = row.Rowid;
                                    tier.Tierid = $"T{k:D2}";
                                    tier.Tiername = $"{k}";
                                    tier.Tierindex = k;
                                    tier.Useflag = "True";
                                    tier.Hoistposition = defaultTierHeight * k;

                                    tier.Lastupdatetime = time;
                                    tier.Lastupdateuserid = blockData.EventUser;

                                    dbcontext.TbTiers.Add(tier);
                                }


                            }
                        }


                        dbcontext.SaveChanges();
                        result = true;
                    }
                }
                catch (Exception ex)
                {
                    Log.ErrorLog($"TxnAddBlockResult Error : {ex.Message}");
                    errMessage = ex.Message;
                    errStack = ex.StackTrace;
                }   
            }

            var htHeader = new Hashtable();
            var htBody = new Hashtable();
            var htReturn = new Hashtable();

            htHeader.Add("messagename", $"TxnAddBlockReply");
            htHeader.Add("replysubject", "");
            htHeader.Add("sourcesubject", htConfig["ReplySubjectPrefix"]);
            htHeader.Add("targetsubject", targetSubject);
            htHeader.Add("transactionid", System.Guid.NewGuid());

            htReturn.Add("returnmessage", errMessage);
            htReturn.Add("returndetailmessage", errStack);
            htReturn.Add("returncode", $"{(result ? "0" : "1")}");
            htReturn.Add("returntype", "");

            return MessageHandler.GetSendMessageFormat(htHeader, htBody, htReturn);
        }
    }
}
