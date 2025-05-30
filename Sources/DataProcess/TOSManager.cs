using System;
using System.Diagnostics;
using System.Collections;
using KR.MBE.CommonLibrary;
using KR.MBE.Message;
using Newtonsoft.Json;
using KR.MBE.Data.Models;
using static KR.MBE.Data.CLT.YC.YCMethod;
using Newtonsoft.Json.Linq;
using KR.MBE.RCMS.Models;



namespace DataProcess
{
    public class TOSManager
    {

        //private static TOSManager m_TosManager = new TOSManager();

        public StepJobManager stepJobManager = null;
        private JobOrderManager jobManager = null;

        public TOSManager()
        {
            jobManager = new JobOrderManager();
            stepJobManager = new StepJobManager();
        }


        public void SetJobOrder(string message)
        {
            // CreateJobOrder (jobOrderManage.cs)
            // message를 가지고 Joborder datatable로 변환해서 jobordermanage의 createjoborder call
            // 1. messagebody -> FlattenJObject

            // JSON 데이터를 JObject로 변환
            var receivedJobDatas = JsonConvert.DeserializeObject<RequestReceiveJobList>(message);

            if (receivedJobDatas == null)
                return;

            if(receivedJobDatas.Count == 0)
                return;

            foreach (var job in receivedJobDatas)
            {
                // 2.listdata -> JobOrder(RCMS DB)   
                var tbJobOrder = JobOrderDataMap(job);

                int rtnCode = 0;
                // 3.jobordermanage에서 valid check.
                // valid check 
                /*if ((rtnCode = jobManager.validCheck(ref tbJobOrder)) < 0)
                {
                    // JOBSTATUS =>  Reject
                    tbJobOrder.Jobstatus = CommonConstant.JOBSTATUS_REJECT;
                }*/

                // 4.EIS JobOrderInsert 정보 ActiveMQ Send. 
                if (jobManager.CreateJobOrder(tbJobOrder) > 0)
                {
                    Hashtable htBody = new Hashtable();

                    string sMessageID = "SendAcceptJob";

                    /*
                        "Head.msgId":"",
                        "Head.evntTp":"",
                        "Head.timeStemp":"",
                        "Head.remark":"",

                        //joborderdata = listdata[0]["Head.msgId"];
                        //joborderdata = listdata[0]["Head.evntTp"];
                        //joborderdata = listdata[0]["Head.timeStemp"];
                        //joborderdata = listdata[0]["Head.remark"];
                    */

                    htBody.Add("msgId", job.Head.msgId);
                    htBody.Add("jobID", tbJobOrder.Joborderid);
                    htBody.Add("eqId", tbJobOrder.Equipmentid);

                    MessageHandler.SendMessageAsync(sMessageID, htBody);
                }
                else
                {
                    Hashtable htBody = new Hashtable();

                    string sMessageID = "JobReject";

                    htBody.Add("msgId", job.Head.msgId);
                    htBody.Add("jobID", tbJobOrder.Joborderid);
                    htBody.Add("eqId", tbJobOrder.Equipmentid);

                    MessageHandler.SendMessageAsync(sMessageID, htBody);


                    // JobReject가 되면 ViewjobTracking과 그 이후 작업이 필요없음.
                    return;
                }

                // joborder가  Wait 상태인것 처리....
                // make ViewJobTracking Data
                if (tbJobOrder.Jobstatus != CommonConstant.JOBSTATUS_REJECT)
                {
                    stepJobManager.makeViewJobTracking(tbJobOrder);

                    // StartJobOrder
                    startJobOrder(tbJobOrder);
                }
            }
        }



        public void startJobOrder(TbJoborder jobInfo)
        {
            startJobOrder(jobInfo, null);
        }

        public void startJobOrder(TbJoborder jobInfo, TbViewjobtracking currentStepJob)
        {
            // 실행 가능한지 Check 변수
            bool bOK = false;

            // DeadLock 주의 Lock 순서 
            // EQUIPMENTINFO
            // JOBORDER
            using (var dbcontext = new RcmsContext())
            {
                // 조건에 맞는 장비 정보를 데이터베이스에서 조회
                TbEquipmentinfo eqp = dbcontext.TbEquipmentinfos
                                                .Where(e => e.Equipmentid == jobInfo.Equipmentid)
                                                .FirstOrDefault();

                // eqp가 null이 아닌지 확인 (조건에 맞는 장비가 존재하지 않을 수도 있습니다)
                if (eqp == null)
                {
                    // ERROR MESSAGE CODE
                    Log.ErrorLog("startJobOrder {0} Equipmentid에 해당하는 Equipmentinfo Data가 없습니다." + jobInfo.Equipmentid);
                    return;
                }

                // 처리 가능한지 Check 한다.  
                if (CommonConstant.JOBSTATUS_WAIT == jobInfo.Jobstatus)
                {
                    // 해당 Job 이 최초 실행일때는 장비 상태도 체크한다.
                    if ((CommonConstant.EQUIPMENTSTATUS_IDLE == eqp.Equipmentstatus)
                            && (CommonConstant.EQPCOMMSTATUS_ONLINE == eqp.Commstatus)
                            && (CommonConstant.EQPOPERATIONMODE_AUTO == eqp.Operationmode ))
                    {
                        bOK = true;
                    }
                    else
                    {
                        bOK = false;
                    }
                }
                else
                {
                    // 진행중인 Job/Crane 인 경우 처리 하기 위해
                    // JobStatus = 'Wait' 가 아닌 경우 Crane의 Idle 상태를 보지 않는다.
                    if ((CommonConstant.EQPCOMMSTATUS_ONLINE == eqp.Commstatus)
                            && (CommonConstant.EQPOPERATIONMODE_AUTO == eqp.Operationmode ))
                    {
                        bOK = true;
                    }
                    else
                    {
                        bOK = false;
                    }
                }

                if (bOK)
                {
                    // 해당 JobOrderID의 현재 진행할 StepJob 정보를 가져온다. (첫StepJob)
                    // (StepJobStatus = 'Wait' 인 첫 공정)

                    //List<TbViewjobtracking> ListCurrentStepJob = null;

                    if (currentStepJob == null)
                    {
                        currentStepJob = stepJobManager.getCurrentViewJobTracking(jobInfo);
                    }

                    // 처리할 StepJob이 null일경우
                    if (currentStepJob == null)
                    {
                        // 현재 진행할 StepJob이 없는 경우 에러
                        Log.ErrorLog("더 진행할 ViewJobTracking 정보가 존재하지 않습니다.");
                    }
                    else
                    {
                        // 현재 진행할 StepJob이 존재하는 경우
                        stepJobManager.StepJobStartRequest(currentStepJob);

                        //String sRCSID = getRCSID(currentStepJob);
                        //if (!sRCSID.isEmpty() && !sRCSID.equals(CommonConstant.ECS_WAITINGRCSID))
                        //{
                        //    MONService.sendAssignedToRCS(jobInfo, eqp);
                        //}
                    }
                }
                else
                {
                    // 해당 Job/Crane은 자동 처리가 불가한 상태입니다.
                    Log.ErrorLog("해당 Job/Crane은 자동 처리가 불가한 상태입니다.");
                    Log.ErrorLog("JOBORDERID : " + jobInfo.Joborderid);
                    Log.ErrorLog("JOBORDER STATUS : " + jobInfo.Jobstatus );
                    Log.ErrorLog("EQUIPMENTID : " + eqp.Equipmentid );
                    Log.ErrorLog("EQUIPMENTSTATUS : " + eqp.Equipmentstatus );
                    Log.ErrorLog("COMMSTATUS : " + eqp.Commstatus );
                    Log.ErrorLog("OPERATIONMODE : " + eqp.Operationmode );
                }

            }

        }




        public void SendMoveJob(string message)
        {
            // "Head.msgId":"c001fc90-d5e9-4b68-8066-2a1160c2cadf"
            // "Body.wrkLoc.LocTp":"YARD",
            // "Body.wrkLoc.loc1":"A01",
            // "Body.wrkLoc.loc2":"01",
            // "Body.wrkLoc.loc3":"A",
            // "Body.wrkLoc.loc4":"",
            // "Body.eqId":"YC01",
            // "Body.jobId":"XXXX0000000651049358094996-506442"}

            // JSON 데이터를 JObject로 변환

            RequestMoveJobList receivedJobDatas = null;

            try
            {
                receivedJobDatas = JsonConvert.DeserializeObject<RequestMoveJobList>(message);
            }
            catch(Exception ex)
            {

            }

            if (receivedJobDatas == null)
                return;

            if (receivedJobDatas.Count == 0)
                return;
            
            foreach (var job in receivedJobDatas)
            {
                // 2.listdata -> JobOrder(RCMS DB)   
                var tbJobOrder = JobOrderDataMap(job);

                int rtnCode = jobManager.validCheck(ref tbJobOrder);
                // 3.jobordermanage에서 valid check.
                // valid check 
                if (rtnCode < 0)
                {
                    // JOBSTATUS =>  Reject
                    tbJobOrder.Jobstatus = "Rejected";
                }


                jobManager.CreateJobOrder(tbJobOrder);

                // 4.EIS JobOrderInsert 정보 ActiveMQ Send. 
                if (0 <= rtnCode)
                {
                    Hashtable htBody = new Hashtable();

                    string sMessageID = "SendAcceptJob";

                    htBody.Add("msgId", job.Head.msgId);
                    htBody.Add("jobID", tbJobOrder.Joborderid);
                    htBody.Add("eqId", tbJobOrder.Equipmentid);

                    MessageHandler.SendMessageAsync(sMessageID, htBody);
                }
                else
                {
                    Hashtable htBody = new Hashtable();

                    string sMessageID = "JobReject";

                    htBody.Add("msgId", job.Head.msgId);
                    htBody.Add("jobID", tbJobOrder.Joborderid);
                    htBody.Add("eqId", tbJobOrder.Equipmentid);

                    MessageHandler.SendMessageAsync(sMessageID, htBody);


                    // JobReject가 되면 ViewjobTracking과 그 이후 작업이 필요없음.
                    return;
                }

                // joborder가  Wait 상태인것 처리....
                // make ViewJobTracking Data
                stepJobManager.makeViewJobTracking(tbJobOrder);

                // StartJobOrder
                startJobOrder(tbJobOrder);
            }
        }



        public void SetInventory(string message)
        {

        }


        /*public Joborder JobOrderDataMap(List<Dictionary<string, string>> listdata)
        {
            Joborder joborderdata = new Joborder();


            foreach (var dict in listdata)
            {
                Debug.WriteLine("Dictionary:");
                foreach (var kvp in dict)
                {
                    Debug.WriteLine($"{kvp.Key}: {kvp.Value}");
                }
                Debug.WriteLine(""); // 빈 줄로 구분
            }

            Debug.WriteLine(""); // 빈 줄로 구분

            // TOS에서 수신받은 Data를 JobOrder Table 형태로...

            string value;// = new string[30];

            //joborderdata = listdata[0]["Head.msgId"];
            //joborderdata = listdata[0]["Head.evntTp"];
            //joborderdata = listdata[0]["Head.timeStemp"];
            //joborderdata = listdata[0]["Head.remark"];

            joborderdata.Joborderid = listdata[0]["Body.jobId"];
            joborderdata.Equipmentid = listdata[0]["Body.eqId"];

            joborderdata.Jobtype = listdata[0]["Body.jobTp"];
            joborderdata.Containerid = listdata[0]["Body.cntrNo"];
            joborderdata.Containersize = listdata[0]["Body.cntrLen"];
            joborderdata.Containerweight = listdata[0]["Body.cntrWgt"];
            joborderdata.Containerheight = listdata[0]["Body.cntrHgt"];
            joborderdata.Containeriso = listdata[0]["Body.cntrTp"];
            joborderdata.Containerfullmty = listdata[0]["Body.isFull"];
            joborderdata.Vehicleid = listdata[0]["Body.vehicleId"];
            joborderdata.Vehicleposition = listdata[0]["Body.chssPos"];

            //joborderdata = listdata[0]["Body.pickupLoc.LocTp"];    // 
                                                            //-UNDEFINED : Undefined
                                                            //- VESSEL : Vessel
                                                            //- YARD : Yard
                                                            //- RAIL : Rail
                                                            //- TPW : Water side TP
                                                            //- TPL : Land side TP
                                                            //- CLTP : Cantilever Transfer Point
                                                            //- QCTP : Quay Crane Transfer Point
                                                            //-IP : Interchange point
                                                            //-AP : Apron
                                                            //- GATE : Gate
                                                            //- XRAY : X - ray
                                                            //- ONCHASSIS : On - Chassis
                                                            //- PLATFORM : Platform in QC
            joborderdata.Fromblock = listdata[0]["Body.pickupLoc.loc1"];
            joborderdata.Frombay = listdata[0]["Body.pickupLoc.loc2"];
            joborderdata.Fromrow = listdata[0]["Body.pickupLoc.loc3"];
            joborderdata.Fromtier = listdata[0]["Body.pickupLoc.loc4"];
            //joborderdata = listdata[0]["Body.pickupLndTp"];       // A : Automatic, R : Remote
            //joborderdata = listdata[0]["Body.pickupClrn"];        //0 : Do not update this value
                                                                    //1 : no clearance
                                                                    //2 : clearance

            //joborderdata = listdata[0]["Body.setdownLoc.LocTp"];            //
            joborderdata.Toblock = listdata[0]["Body.setdownLoc.loc1"];
            joborderdata.Tobay = listdata[0]["Body.setdownLoc.loc2"];
            joborderdata.Torow = listdata[0]["Body.setdownLoc.loc3"];
            joborderdata.Totier = listdata[0]["Body.setdownLoc.loc4"];
            //joborderdata = listdata[0]["Body.setdownLndTp"];
            //joborderdata = listdata[0]["Body.setdownClrn"]; 

            //jobId - JOBORDERID (J2401040002)
            //jobTp - JOBID (GI)
            //JOBSTATUS (Completed)
            //jobTp - JOBTYPE (GI)
            //eqId  EQUIPMENTID (CR001)          
            //REMOTESTATIONID (RCS-002)   
            //cntrNo - CONTAINERID (CNTR-001)
            //cntrTp - CONTAINERISO (22G1)     ===> 확인 필요
            //cntrLen - CONTAINERSIZE (20)
            //cntrHgt - CONTAINERHEIGHT (1)
            //cntrWgt - CONTAINERWEIGHT (1234)
            //CONTAINERDOORDIR (1)
            //SPREADERSIZE (20)
            //CONTAINERTYPE (GE)
            //CONTAINEROPR
            //CONTAINERCLASS
            //CONTAINERCARGOTYPE
            //isFull - CONTAINERFULLMTY
            //vehicleId - VEHICLEID (OTR-001)
            //VEHICLETYPE (1)
            //chssPos - VEHICLEPOSITION        ===> 확인 필요
            //pickupLoc.loc1 - FROMBLOCK (BLK-1A)    
            //pickupLoc.loc2 - FROMBAY (B05)
            //pickupLoc.loc3 - FROMROW (R07)
            //pickupLoc.loc4 - FROMTIER (T01)
            //setdownLoc.TOBLOCK (BLK-1A)
            //setdownLoc.TOBAY (B05)
            //setdownLoc.TOROW (R03)
            //setdownLoc.TOTIER (T01)
            //head.timeStamp - SENDTIMEKEY (20240104192859)
            //SENDJOBSTATUS (A)
            //SENDTOPIC (JOB_CREATE)
            //RECVTIME (2024-01-04 19:29:29.980)      ===> ECS Process time
            //STARTTIME (2024-01-04 19:29:30.027)     ===> PLC_START_TIME
            //ENDTIME (2024-01-04 20:25:59.893)
            //COMPOSITIONID  (GI-11000-JobDone)
            //REJECTCODE
            //REJECTCOMMENT
            //LASTUPDATETIME (2024-01-04 20:19:46.263)
            //LASTUPDATEUSERID (CR001)
            //               

            return joborderdata;
        }*/




        public TbJoborder JobOrderDataMap(RequestReceiveJob receivedJob)
        {
            var joborderdata = new TbJoborder();

            // TOS에서 수신받은 Data를 JobOrder Table 형태로...

            joborderdata.Joborderid = receivedJob.Body.jobId;
            joborderdata.Equipmentid = receivedJob.Body.eqId;

            joborderdata.Jobid = receivedJob.Body.jobTp;
            joborderdata.Jobtype = receivedJob.Body.jobTp;
            joborderdata.Containerid = receivedJob.Body.cntrNo;
            joborderdata.Containersize = receivedJob.Body.cntrLen;
            joborderdata.Containerweight = receivedJob.Body.cntrWgt;
            joborderdata.Containerheight = receivedJob.Body.cntrHgt;
            joborderdata.Containeriso = receivedJob.Body.cntrTp;
            joborderdata.Containerfullmty = receivedJob.Body.isFull;
            joborderdata.Vehicleid = receivedJob.Body.vehicleId;
            joborderdata.Vehicleposition = receivedJob.Body.chssPos;
            joborderdata.Spreadersize = receivedJob.Body.cntrLen;


            joborderdata.Fromlocationtype = receivedJob.Body.pickupLoc.LocTp;    // 
            //-UNDEFINED : Undefined
            //- VESSEL : Vessel
            //- YARD : Yard
            //- RAIL : Rail
            //- TPW : Water side TP
            //- TPL : Land side TP
            //- CLTP : Cantilever Transfer Point
            //- QCTP : Quay Crane Transfer Point
            //-IP : Interchange point
            //-AP : Apron
            //- GATE : Gate
            //- XRAY : X - ray
            //- ONCHASSIS : On - Chassis
            //- PLATFORM : Platform in QC
            joborderdata.Fromblock = receivedJob.Body.pickupLoc.loc1;
            joborderdata.Frombay = receivedJob.Body.pickupLoc.loc2;
            joborderdata.Fromrow = receivedJob.Body.pickupLoc.loc3;
            joborderdata.Fromtier = receivedJob.Body.pickupLoc.loc4;
            joborderdata.Fromlandtype = receivedJob.Body.pickupLndTp; // A : Automatic, R : Remote
            joborderdata.Fromclearlance = receivedJob.Body.pickupClrn;
            //0 : Do not update this value
            //1 : no clearance
            //2 : clearance

            joborderdata.Tolocationtype = receivedJob.Body.setdownLoc.LocTp;
            joborderdata.Toblock = receivedJob.Body.setdownLoc.loc1;
            joborderdata.Tobay = receivedJob.Body.setdownLoc.loc2;
            joborderdata.Torow = receivedJob.Body.setdownLoc.loc3;
            joborderdata.Totier = receivedJob.Body.setdownLoc.loc4;
            joborderdata.Tolandtype = receivedJob.Body.setdownLndTp; // A : Automatic, R : Remote
            joborderdata.Toclearlance = receivedJob.Body.setdownClrn;
            //0 : Do not update this value
            //1 : no clearance
            //2 : clearance


            // JOBSTATUS WAIT
            joborderdata.Jobstatus = CommonConstant.STEPJOBSTATUS_WAIT;

            // SENDTIMEKEY
            joborderdata.Sendtimekey = DateTime.Now.ToString("yyyyMMddHHmmss");
            // RECVTIME 
            joborderdata.Recvtime = DateTime.Now;
            //               

            return joborderdata;
        }



        public TbJoborder JobOrderDataMap(RequestMoveJob receivedJob)
        {
            var joborderdata = new TbJoborder();

            // TOS에서 수신받은 Data를 JobOrder Table 형태로...

            joborderdata.Joborderid = receivedJob.Body.jobId;
            joborderdata.Equipmentid = receivedJob.Body.eqId;

            joborderdata.Jobid = "MV";
            joborderdata.Jobtype = "MV";
            //-UNDEFINED : Undefined
            //- VESSEL : Vessel
            //- YARD : Yard
            //- RAIL : Rail
            //- TPW : Water side TP
            //- TPL : Land side TP
            //- CLTP : Cantilever Transfer Point
            //- QCTP : Quay Crane Transfer Point
            //-IP : Interchange point
            //-AP : Apron
            //- GATE : Gate
            //- XRAY : X - ray
            //- ONCHASSIS : On - Chassis
            //- PLATFORM : Platform in QC
            joborderdata.Tolocationtype = receivedJob.Body.wrkLoc.LocTp;
            joborderdata.Toblock = receivedJob.Body.wrkLoc.loc1;
            joborderdata.Tobay = receivedJob.Body.wrkLoc.loc2;
            joborderdata.Torow = receivedJob.Body.wrkLoc.loc3;
            joborderdata.Totier = receivedJob.Body.wrkLoc.loc4;
            joborderdata.Tolandtype = "A";
            joborderdata.Toclearlance = "0";
            //0 : Do not update this value
            //1 : no clearance
            //2 : clearance


            // JOBSTATUS WAIT
            joborderdata.Jobstatus = CommonConstant.STEPJOBSTATUS_WAIT;

            // SENDTIMEKEY
            joborderdata.Sendtimekey = DateTime.Now.ToString("yyyyMMddHHmmss");
            // RECVTIME 
            joborderdata.Recvtime = DateTime.Now;
            //               

            return joborderdata;
        }



        public void saveJobOrderData(string message)
        {

            using (var dcContext = new RcmsContext())
            {
                // JobOrderId로 조회해서 동일한 Data가 있는지 체크
                var checkOrder = dcContext.TbJoborders.Find("ITIER-1", "J2401040001");

                if (checkOrder==null)
                {
                    return;
                }

                var order = new TbJoborder
                {
                    Joborderid = "test123", // JOBORDERID (Primary key) (length: 40)
                    //public string Jobid ; // JOBID (length: 40)
                    //public string Jobstatus ; // JOBSTATUS (length: 40)
                    //public string Jobtype ; // JOBTYPE (length: 40)
                    //public string Equipmentid ; // EQUIPMENTID (length: 40)
                    //public string Remotestationid ; // REMOTESTATIONID (length: 40)
                    //public string Containerid ; // CONTAINERID (length: 40)
                    //public string Containeriso ; // CONTAINERISO (length: 40)
                    //public string Containersize ; // CONTAINERSIZE (length: 40)
                    //public string Containerheight ; // CONTAINERHEIGHT (length: 40)
                    //public string Containerweight ; // CONTAINERWEIGHT (length: 40)
                    //public string Containerdoordir ; // CONTAINERDOORDIR (length: 40)
                    //public string Spreadersize ; // SPREADERSIZE (length: 40)
                    //public string Containertype ; // CONTAINERTYPE (length: 40)
                    //public string Containeropr ; // CONTAINEROPR (length: 40)
                    //public string Containerclass ; // CONTAINERCLASS (length: 40)
                    //public string Containercargotype ; // CONTAINERCARGOTYPE (length: 40)
                    //public string Containerfullmty ; // CONTAINERFULLMTY (length: 40)
                    //public string Vehicleid ; // VEHICLEID (length: 40)
                    //public string Vehicletype ; // VEHICLETYPE (length: 40)
                    //public string Vehicleposition ; // VEHICLEPOSITION (length: 40)
                    //public string Fromblock ; // FROMBLOCK (length: 40)
                    //public string Frombay ; // FROMBAY (length: 40)
                    //public string Fromrow ; // FROMROW (length: 40)
                    //public string Fromtier ; // FROMTIER (length: 40)
                    //public string Toblock ; // TOBLOCK (length: 40)
                    //public string Tobay ; // TOBAY (length: 40)
                    //public string Torow ; // TOROW (length: 40)
                    //public string Totier ; // TOTIER (length: 40)
                    //public string Sendtimekey ; // SENDTIMEKEY (length: 40)
                    //public string Sendjobstatus ; // SENDJOBSTATUS (length: 40)
                    //public string Sendtopic ; // SENDTOPIC (length: 40)
                    //public DateTime? Recvtime ; // RECVTIME
                    //public DateTime? Starttime ; // STARTTIME
                    //public DateTime? Endtime ; // ENDTIME
                    //public string Compositionid ; // COMPOSITIONID (length: 40)
                    //public string Rejectcode ; // REJECTCODE (length: 40)
                    //public string Rejectcomment ; // REJECTCOMMENT (length: 250)
                    //public DateTime? Lastupdatetime ; // LASTUPDATETIME
                    //public string Lastupdateuserid ; // LASTUPDATEUSERID (length: 40)
                };

                // 동기
                dcContext.TbJoborders.Add(order);
                dcContext.SaveChanges();

                //// 비동기
                //dcContext.Joborders.AddAsync(order);
                //dcContext.SaveChangesAsync();
            }

        }

    }
}
