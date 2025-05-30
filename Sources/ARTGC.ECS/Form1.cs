//using  KR.MBE.Data.Models;
using KR.MBE.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using static System.Windows.Forms.LinkLabel;
using KR.MBE.CommonLibrary;
using KR.MBE.Message;
using System.Collections;
using System.IO;
using Microsoft.AspNetCore.Http.Features;
using DataProcess;
using log4net.Config;
using Apache.NMS.ActiveMQ.Commands;
using log4net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using KR.MBE.Data.Models;
using System.Windows;
using MessageBox = System.Windows.Forms.MessageBox;
using Middleware.ActiveMQ;
using Middleware.JsonRPC;
using System.Xml;
using System.Diagnostics.Eventing.Reader;
using Microsoft.Extensions.Logging;
using KR.MBE.RCMS.Models;


namespace ARTGC
{
    public partial class Form1 : Form
    {

        public RcmsContext dbcontext;
        TOSManager tos = new TOSManager();
        PLCManager plc = new PLCManager();
        StepJobManager stepJobManager = new StepJobManager();

        Middleware.ActiveMQ.Listener MQListner = null;
        Middleware.ActiveMQ.Listener MQListnerMonitor = null;
        Middleware.ActiveMQ.Sender MQSender = null;

        Middleware.JsonRPC.JsonRpcServer JRPCServer = null;

        Middleware.JsonRPC.JsonRpcClient JRPClient = null;


        System.Windows.Forms.Timer reconnectTimer = new System.Windows.Forms.Timer();

        public Form1()
        {
            InitializeComponent();
            InitSetting();
            XmlConfigurator.Configure(new System.IO.FileInfo("log4net.config"));

            reconnectTimer.Interval = 5000;
            reconnectTimer.Tick += ReconnectTimer_Tick;
            reconnectTimer.Start();
            ReconnectTimer_Tick(this, new EventArgs());

        }

        private void ReconnectTimer_Tick(object? sender, EventArgs e)
        {
            if (MQListner != null && MQListner.IsConnected == false)
                MQListner.Listen();

            if (MQListnerMonitor != null && MQListnerMonitor.IsConnected == false)
                MQListnerMonitor.ListenMonitoring();
        }

        private void CraneStatusPerioidcTimer_Tick(object? sender, EventArgs e)
        {
            this.btnMsg_aycStatus_Click(this, new EventArgs());
            this.btnMsg_aycPosition_Click(this, new EventArgs());
            this.btnMsg_aycSpreader_Click(this, new EventArgs());
        }


        public void InitSetting()
        {
            //------------------------------------------------------------------
            //- Initialzie ActiveMQ Communication
            MQListner = new Middleware.ActiveMQ.Listener();
            MQListnerMonitor = new Middleware.ActiveMQ.Listener();
            MQSender = new Sender();
            MQListner.ReceiveMessage += ReceiveOnMessageNormal;
            MQListnerMonitor.ReceiveMessage += ReceiveOnMessageMonitor;
            MQListner.Listen();
            MQListnerMonitor.ListenMonitoring();


            //------------------------------------------------------------------
            //- Initialzie JSON-RPC Server
            JRPCServer = new Middleware.JsonRPC.JsonRpcServer();
            JRPCServer.LogEvent += JRPCServer_LogEvent;
            JRPCServer.StartServer();
            this.FormClosed += Form1_FormClosed;


            //------------------------------------------------------------------
            //- Initialize JSON-RPC Client
            JRPClient = new Middleware.JsonRPC.JsonRpcClient();

        }

        private void Form1_FormClosed(object? sender, FormClosedEventArgs e)
        {
            JRPCServer?.StopServer();
        }

        private void JRPCServer_LogEvent(string obj)
        {
            throw new NotImplementedException();
        }

        public static string FormatXml(string xml)
        {
            try
            {
                var doc = new XmlDocument();
                doc.LoadXml(xml); // ���ڿ��� XML�� �ε�

                var sb = new StringBuilder();
                using (var writer = new XmlTextWriter(new StringWriter(sb)))
                {
                    writer.Formatting = System.Xml.Formatting.Indented; // �鿩���� ����
                    writer.Indentation = 2; // �鿩���� ���� (2ĭ)
                    doc.Save(writer);
                }

                return sb.ToString();
            }
            catch (Exception ex)
            {
                return $"[XML ���� ����] {ex.Message}";
            }
        }

        private void ReceiveOnMessageNormal(string message, string replyTo, string replyId)
        {
            //DataSet dsReturn = null;// MessageHandler.GetXmlToDataSet(message, "_REPLYDATA");
            //string[] messages = message.Split( ' ' );

            Log.DebugLog("Received ActiveMQ =================================");
            Log.DebugLog(FormatXml(message));
            Log.DebugLog("===================================================");

            string messageName = ConvertUtil.getXMLResult(message, "<messagename>", "</messagename>");
            string replyTopic = ConvertUtil.getXMLResult(message, "<replytopic>", "</replytopic>");
            string replySubject = ConvertUtil.getXMLResult(message, "<replysubject>", "</replysubject>");
            string messageBody = ConvertUtil.getXMLResult(message, "<body>", "</body>");

            var returnMessage = string.Empty;

            if (messageName.StartsWith("Txn"))
            {
                switch (messageName)
                {
                    case "TxnLogin":
                        returnMessage = InterfaceManager.getInstance().TxnLoginResult(replySubject, messageBody);
                        break;

                    case "TxnAddBlock":
                        returnMessage = InterfaceManager.getInstance().TxnAddBlockResult(replySubject, messageBody);
                        break;
                    //case "TxnStartJobOrder":
                    //    break;
                    default:
                        returnMessage = InterfaceManager.getInstance().TxnRequestResult(replySubject, messageName, messageBody);
                        break;
                }

                if (string.IsNullOrEmpty(returnMessage) == false)
                    MQListner.SendReply(returnMessage, replyTo, replyId);
            }
            else
            {
                switch (messageName)
                {
                    case "SetJobOrder":
                        tos.SetJobOrder(messageBody);
                        break;
                    case "SendAcceptJobReply":
                        break;
                    case "CurrentStepJobRequest":
                        stepJobManager.CurrentStepJobRequest(messageBody);
                        break;
                    case "StepJobStart":
                        stepJobManager.stepJobStart(messageBody);
                        break;
                    case "StepJobEnd":
                        stepJobManager.stepJobEnd(messageBody);
                        break;
                    case "StepJobParameterStatusUpdate":
                        stepJobManager.stepJobParameterStatusUpdate(messageBody);
                        break;
                    case "GetInventoryData":
                        {
                            Log.InfoLog(" GetInventoryData Input ######################");
                            returnMessage = InterfaceManager.getInstance().GetInventoryForRCS(replySubject, messageBody);
                            if (string.IsNullOrEmpty(replyTopic) == false)
                                MQSender.SendTopic(returnMessage, replyTopic);
                            else
                                MQListner.SendReply(returnMessage, replyTo, replyId);
                            Log.InfoLog(" GetInventoryData Input End ######################");
                        }
                        break;
                    case "SendMoveJob":
                        // MoveJob
                        // "Head.msgId":"c001fc90-d5e9-4b68-8066-2a1160c2cadf"
                        // "Body.wrkLoc.LocTp":"YARD",
                        // "Body.wrkLoc.loc1":"A01",
                        // "Body.wrkLoc.loc2":"01",
                        // "Body.wrkLoc.loc3":"A",
                        // "Body.wrkLoc.loc4":"",
                        // "Body.eqId":"YC01",
                        // "Body.jobId":"XXXX0000000651049358094996-506442"} 
                        tos.SendMoveJob(messageBody);
                        break;
                    case "AliveCheck":
                        {
                            returnMessage = InterfaceManager.getInstance().AliveCheck(replySubject);
                            MQListner.SendReply(returnMessage, replyTo, replyId);
                        }
                        break;
                    case "GetQueryResult":
                        {
                            returnMessage = InterfaceManager.getInstance().GetQueryResult(replySubject, messageBody);
                            MQListner.SendReply(returnMessage, replyTo, replyId);
                        }
                        break;
                    case "SetInventory":
                    default:
                        break;
                }
            }
        }

        private void ReceiveOnMessageMonitor(string message, string replyTo, string replyId)
        {
            //DataSet dsReturn = null;// MessageHandler.GetXmlToDataSet(message, "_REPLYDATA");
            //string[] messages = message.Split( ' ' );
            string messageName = ConvertUtil.getXMLResult(message, "<messagename>", "</messagename>");
            string messageBody = ConvertUtil.getXMLResult(message, "<body>", "</body>");

            if (messageName == "PLCUpdataDataToECS")
            {
                // 
                // {"EQUIPMENTID":"CR001","STATIONID":"ST001","TAGID":"CR001_MW3550","BEFOREVALUE":"1","VALUE":"0","SCALEVALUE":""}
                plc.savePLCReadData(messageBody);
            }  //
            else
            {
                MessageBox.Show("TEST");
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {

            // �۾����ø� ������

            // VIEWJOBTRACKING INSERT
            //StepJobManager stepjobMan = new StepJobManager();

            using (var dbcontext = new RcmsContext())
            {
                TbJoborder joborderdata1 = dbcontext.TbJoborders
                                           .Where(e => e.Joborderid == "J2407090001")
                                           .FirstOrDefault();


                if (joborderdata1 == null)
                {
                    System.Windows.Forms.MessageBox.Show("J2407090001 JOB ORDER�� ����");
                    return;
                }


                // joborder��  Wait �����ΰ� ó��....
                // make ViewJobTracking Data
                stepJobManager.makeViewJobTracking(joborderdata1);

                // StartJobOrder
                tos.startJobOrder(joborderdata1);
            }
            //test1();
            //List<Bay> dt1 = dbcontext.Bays.ToList();

            //// BindingList�� ����Ͽ� DataGridView�� ������ ����
            //BindingList<Bay> list1 = new BindingList<Bay>(dt1);

            //Debug.WriteLine(dt1.GetType().Name);

            //dataGridView1.DataSource = list1;

            //// stepjobManager�� m_StepJobOrderList READ & datagridview1�� display.
            //DataTable joborderdt = new DataTable();

            //Joborder joborder1 = new Joborder();
            //StepJobManager
            //joborderdt.a

            //dataGridView1.DataSource = StepJobManager.m_StepJobOrderList;
        }

        private delegate void UpdateDataGridViewDelegate(DataTable table);


        private void UpdateDataGridViewSafe(DataTable table)
        {
            if (dataGridView1.InvokeRequired)
            {
                var d = new UpdateDataGridViewDelegate(UpdateDataGridViewSafe);
                //dataGridView1.Invoke(d, new object[] { value });
                dataGridView1.Invoke(new Action<DataTable>(UpdateDataGridViewSafe), table);
            }
            else
            {
                dataGridView1.DataSource = table;
            }
        }


        public void test1()
        {
            // �ð� ���� ����
            Stopwatch stopwatch = Stopwatch.StartNew();

            //var c = dbcontext.Alarmhistories.Where(a => a.Equipmentid.Contains("bc")).Select(a => a);
            List<TbBay> dt1 = dbcontext.TbBays.ToList();
            //var dt1 = dbcontext.Bays.FirstOrDefault();

            stopwatch.Stop();
            Debug.WriteLine($" Processing Time: {stopwatch.ElapsedMilliseconds} milliseconds");

            stopwatch = Stopwatch.StartNew();

            List<TbBlock> dt2 = dbcontext.TbBlocks.ToList();

            stopwatch.Stop();
            Debug.WriteLine($" Processing Time: {stopwatch.ElapsedMilliseconds} milliseconds");

            // BindingList�� ����Ͽ� DataGridView�� ������ ����
            BindingList<TbBay> list1 = new BindingList<TbBay>(dt1);

            Debug.WriteLine(dt1.GetType().Name);

            dataGridView1.DataSource = list1;
        }


        private void OnJobOrderSearch(object sender, EventArgs e)
        {
            // JobOrder DB ��ȸ
            using (var dbcontext = new RcmsContext())
            {
                var joborder = dbcontext.TbJoborders.ToList();

                dataGridView1.DataSource = joborder;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            KR.MBE.CommonLibrary.Log.InfoLog("TEST INFO LOG MANAGER");

            string messageBody = "";

            Stopwatch stopwatch = Stopwatch.StartNew();

            // JSON ���� ���
            string filePath = @"C:\2024\ECS\Sources\4002.json";

            // ���Ͽ��� JSON ���ڿ� �б�
            string jsonData = File.ReadAllText(filePath);

            // JSON ���ڿ��� JObject�� �Ľ�
            JObject root = JObject.Parse(jsonData);

            // "params" �迭�� ��������
            JArray paramsArray = (JArray)root["params"];

            // ��� ����Ʈ �ʱ�ȭ
            List<Dictionary<string, string>> listdata = new List<Dictionary<string, string>>();

            // �� ��ü�� Dictionary<string, string>�� ��ȯ�Ͽ� ����Ʈ�� �߰�
            foreach (JObject param in paramsArray)
            {
                Dictionary<string, string> flatDictionary = new Dictionary<string, string>();
                JSONStringParser.FlattenJStringData(param, flatDictionary, "");

                listdata.Add(flatDictionary);
            }

            // ��� ���
            //foreach (var dictionary in listdata)
            //{
            //    foreach (var kvp in dictionary)
            //    {
            //        Debug.WriteLine($"{kvp.Key}: {kvp.Value}");
            //    }
            //    Debug.WriteLine("");
            //}

            TOSManager tos = new TOSManager();
            tos.SetJobOrder(jsonData);
            //tos.saveJobOrderData(messageBody);

            stopwatch.Stop();
            Debug.WriteLine($" Processing Time: {stopwatch.ElapsedMilliseconds} milliseconds");

            Stopwatch stopwatch1 = Stopwatch.StartNew();

            //PLCManager plc = new PLCManager();
            //plc.savePLCReadData(messageBody);

            stopwatch1.Stop();
            Debug.WriteLine($" Processing Time: {stopwatch1.ElapsedMilliseconds} milliseconds");
            Debug.WriteLine($" END");

            //// JSON ���� ���
            //string filePath = @"C:\2024\ECS\Sources\4002.json";

            //try
            //{
            //    // ���Ͽ��� JSON ���ڿ� �б�
            //    string jsonData = File.ReadAllText(filePath);

            //    // JSON ���ڿ��� JObject�� �Ľ�
            //    JObject root = JObject.Parse(jsonData);

            //    // "params" �迭�� ��������
            //    JArray paramsArray = (JArray)root["params"];

            //    // ��� ����Ʈ �ʱ�ȭ
            //    List<Dictionary<string, string>> listdata = new List<Dictionary<string, string>>();

            //    // �� ��ü�� Dictionary<string, string>�� ��ȯ�Ͽ� ����Ʈ�� �߰�
            //    foreach (JObject param in paramsArray)
            //    {
            //        Dictionary<string, string> flatDictionary = new Dictionary<string, string>();
            //        JSONStringParser.FlattenJStringData(param, flatDictionary, "");

            //        listdata.Add(flatDictionary);
            //    }

            //    // ��� ���
            //    foreach (var dictionary in listdata)
            //    {
            //        foreach (var kvp in dictionary)
            //        {
            //            Debug.WriteLine($"{kvp.Key}: {kvp.Value}");
            //        }
            //        Debug.WriteLine("");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Debug.WriteLine($"An error occurred: {ex.Message}");
            //}
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }



        // del 
        private void button5_Click(object sender, EventArgs e)
        {


        }

        private void StepJobStart_Click(object sender, EventArgs e)
        {
            string message = "<COMPOSITIONID></COMPOSITIONID><STEPJOBID>Gantry2</STEPJOBID><JOBORDERID>144133415188584-474837</JOBORDERID><STEPSEQUENCE>1000</STEPSEQUENCE><EQUIPMENTID>CR001</EQUIPMENTID>";


            stepJobManager.stepJobStart(message);
        }

        private void StepJobEnd_Click(object sender, EventArgs e)
        {
            //StepJobStart
            string sMessageID = "StepJobEnd";

            // ���õ� ���� �ε����� �����ɴϴ�.
            int selectedRowIndex = dataGridView1.SelectedCells[0].RowIndex;

            // ���õ� ���� �����ɴϴ�.
            DataGridViewRow selectedRow = dataGridView1.Rows[selectedRowIndex];

            // 'joborderid' �÷��� ���� �����ɴϴ�.
            string jobOrderId = Convert.ToString(selectedRow.Cells["joborderid"].Value);

            Hashtable htBody = new Hashtable();

            htBody.Add("JOBORDERID", jobOrderId);
            htBody.Add("EQUIPMENTID", "CR001");
            htBody.Add("STEPJOBID", "Gantry2");
            htBody.Add("STEPJOBTYPE", "StartEnd");
            htBody.Add("STEPSEQUENCE", "1000");
            htBody.Add("COMPOSITIONID", "MV-1000-Gantry2");

            MessageHandler.SendMessageAsync(sMessageID, htBody);
            //MessageHandler.SendMessageAsyncEco(sMessageID, htBody);
        }

        private void btnTestGI_Click(object sender, EventArgs e)
        {
            string message =
                "[{\"head\":{\"msgId\":\"a4ff2434-4609-4f95-920f-6ce925bd4881\",\r\n\"evntTp\":\"BlockToBlock\",\r\n\"timeStemp\":\"2024-11-28 17:00:38\",\r\n\"remark\":null},\r\n\"body\":{\"jobTp\":\"GI\",\r\n\"cntrNo\":\"AAAA3323424\",\r\n\"cntrLen\":\"20\",\r\n\"cntrWgt\":\"82kg\",\r\n\"cntrHgt\":\"8.6\",\r\n\"cntrTp\":\"GE\",\r\n\"isFull\":\"N\",\r\n\"vehicleId\":\"AGV046\",\r\n\"chssPos\":\"C\",\r\n\"pickupLoc\":{\"LocTp\":\"YARD\",\r\n\"loc1\":\"05D\",\r\n\"loc2\":\"05\",\r\n\"loc3\":\"D\",\r\n\"loc4\":\"2\"},\r\n\"pickupLndTp\":\"R\",\r\n\"pickupClrn\":\"0\",\r\n\"setdownLoc\":{\"LocTp\":\"YARD\",\r\n\"loc1\":\"A07\",\r\n\"loc2\":\"07\",\r\n\"loc3\":\"A\",\r\n\"loc4\":\"3\"},\r\n\"setdownLndTp\":\"A\",\r\n\"setdownClrn\":\"0\",\r\n\"eqId\":\"YC01\",\r\n\"jobId\":\"035226214237676-132356\"}}]";



            tos.SetJobOrder(message);

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            string message =
                "<message><header><messagename>GetInventoryData</messagename><replytopic>topic://ecsTopic</replytopic><replysubject>PROD.KR.MBE.EIS.UI-192.168.10.201.XSLbFgKecld7b3Em</replysubject><sourcesubject></sourcesubject><transactionid></transactionid></header><body><BINDV><CRAINID>CR001</CRAINID></BINDV></body></message>";

            string messageName = ConvertUtil.getXMLResult(message, "<messagename>", "</messagename>");
            string replySubject = ConvertUtil.getXMLResult(message, "<replysubject>", "</replysubject>");
            string messageBody = ConvertUtil.getXMLResult(message, "<body>", "</body>");

            var returnMessage = InterfaceManager.getInstance().GetInventoryForRCS(replySubject, messageBody);

            //MQListner.SendReply(returnMessage, replyTo, replyId);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        #region TOS (JSON-RPC) Interface Test Function 
        //======================================================================================
        //=  TOS (JSON-RPC) Interface Test Function 
        //=  

        private void btnMsg_aycConnection_Click(object sender, EventArgs e)
        {
            var aycJobResponse = this.JRPClient.SendJRPC_MSG_Connection();
        }


        private void btnMsg_Accept_Click(object sender, EventArgs e)
        {
            var aycJobResponse = this.JRPClient.SendJRPC_MSG_accept();
        }

        private void btnMsg_pickupDone_Click(object sender, EventArgs e)
        {
            var aycJobResponse = this.JRPClient.SendJRPC_MSG_pickupDone();
        }

        private void btnMsg_jobDone_Click(object sender, EventArgs e)
        {
            var aycJobResponse = this.JRPClient.SendJRPC_MSG_JobDone();
        }

        private void btnMsg_abortStatus_Click(object sender, EventArgs e)
        {
            var aycJobResponse = this.JRPClient.SendJRPC_MSG_abortStatus();
        }

        private void btnMsg_detectVehicle_Click(object sender, EventArgs e)
        {
            var aycJobResponse = this.JRPClient.SendJRPC_MSG_detectVehicle();
        }

        private void btnMsg_aycStatus_Click(object sender, EventArgs e)
        {
            string autoSts = this.TB_AutoStatus.Text;

            var aycJobResponse = this.JRPClient.SendJRPC_MSG_aycStatus(autoSts);
        }

        private void btnMsg_aycPosition_Click(object sender, EventArgs e)
        {
            var aycJobResponse = this.JRPClient.SendJRPC_MSG_aycPosition();
        }

        private void btnMsg_aycSpreader_Click(object sender, EventArgs e)
        {
            var aycJobResponse = this.JRPClient.SendJRPC_MSG_aySpreader();
        }

        private void btnMsg_reject_Click(object sender, EventArgs e)
        {
            var aycJobResponse = this.JRPClient.SendJRPC_MSG_reject();
        }

        #endregion

    }
}
