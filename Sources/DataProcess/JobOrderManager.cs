using System;
using System.Collections;
using System.ComponentModel;
using KR.MBE.CommonLibrary;
using KR.MBE.Message;
using Microsoft.EntityFrameworkCore;
using log4net.Config;
using log4net;
using Apache.NMS.Util;
using System.Globalization;
using System.Windows.Forms.Design;
using KR.MBE.Data.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Runtime;
using KR.MBE.RCMS.Models;

namespace DataProcess
{
    public class JobOrderManager
    {
        public static JobOrderManager m_JobOrderFactory = new JobOrderManager();
        public RcmsContext dbcontext;

        //public static StepJobManager m_stepJobManager
        // Hashtable or List
        public Hashtable m_htCreateStepJobList = null;
        
        // List 생성
        public static BindingList<TbJoborder> m_JobOrderList = new BindingList<TbJoborder>();

        public JobOrderManager()
        {
            m_htCreateStepJobList = new Hashtable();
            //m_JobOrderList = new List<Joborder>();
            //m_JobOrderFactory = new JobOrderManager();

            dbcontext = new RcmsContext();
        }


        public int CreateJobOrder(TbJoborder joborderdata)
        {
            int rtnCode = 0;
            // valid check 
            //if ((rtnCode = validCheck(ref joborderdata)) > 0) return rtnCode;

            // OK -> joborder db cud 
            // JOBORDER DB INSERT
            try
            {
                using (var dbcontext = new RcmsContext())
                {
                    dbcontext.TbJoborders.Add(joborderdata);
                    dbcontext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                //CommonLibrary.LogManager.InfoLog($"JOBORDER TABLE SAVECHANGES ERROR[joborderid:{joborderdata.Joborderid}]");
                Log.ErrorLog($"JOBORDER TABLE SAVECHANGES ERROR[joborderid:{joborderdata.Joborderid}]");
            }

            rtnCode = 1;

            // tos response(생략)
            // NG -> joborderreject db cud
            // tos response(생략)

            //m_JobOrderList ADD

            // -- JobOrder를 가지고 stepjoblist를 만듦.
            // 현재는 setpjob을 하나의 job으로 관리 (To be -> DB에 설정된데로 연동)
            //Joborder stepJobOrder = new Joborder();
            //stepJobOrder.Joborderid = "1234";
            //StepJobManager.m_StepJobOrderList.Add(stepJobOrder);// ADD

            //StepJobManager.m_StepJobManager.Function2();

            return rtnCode;
        }


        // TOS SETJOBORDER RCV CLASS DATA

        public bool isTransferPoint(string sBlock, string sBay, string sRow)
        {
            try
            {
                switch (sRow)
                {
                    case "A":
                        sRow = "1";
                        break;
                    case "B":
                        sRow = "10";
                        break;
                    case "C":
                        sRow = "20";
                        break;
                    case "D":
                        sRow = "30";
                        break;
                    case "E":
                        sRow = "40";
                        break;
                    case "F":
                        sRow = "50";
                        break;
                    case "G":
                        sRow = "60";
                        break;
                }

                sBay = "B" + sBay;

                var result = dbcontext.TbRows.Where(d => d.Blockid == sBlock && d.Rowname == sRow && d.Bayid == sBay && d.Useflag == "True")
                    .FirstOrDefault();

                if (result == null)
                {
                    return false;
                }
                else
                {
                    if (result.Workinglaneflag == "True")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return false;
        }

        public bool isAvailableInventory(string sBlock, string sRow, string sBay, string sTier, bool thereIs)
        {
            try
            {
                switch (sRow)
                {
                    case "A":
                        sRow = "R01";
                        break;
                    case "B":
                        sRow = "R02";
                        break;
                    case "C":
                        sRow = "R03";
                        break;
                    case "D":
                        sRow = "R04";
                        break;
                    case "E":
                        sRow = "R05";
                        break;
                    case "F":
                        sRow = "R06";
                        break;
                    case "G":
                        sRow = "R07";
                        break;
                }

                sBay = "B" + sBay;
                sTier = "T" + string.Format("{0:D2}", int.Parse(sTier));

                var result = dbcontext.TbInventories.Where(d =>
                    d.Bayid == sBay && d.Blockid == sBlock && d.Rowid == sRow && d.Tierid == sTier).ToList();

                if (thereIs)
                {
                    if (result.Count > 0)
                    {
                        return !thereIs;
                    }
                    else
                    {
                        return thereIs;
                    }
                }
                else
                {
                    if (result.Count > 0)
                    {
                        return thereIs;
                    }
                    else
                    {
                        return !thereIs;
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return false;
        }

        public bool checkContainerId(string containerId)
        {
            try
            {
                var result = dbcontext.TbInventories.Where(d => d.Containerid == containerId).ToList();

                if (result.Count > 0)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
            }

            return false;
        }


        public int validCheck(ref TbJoborder joborderdata)
        {
            int rtnCode = 0;

            if (joborderdata.Joborderid == null)
            {
                Log.ErrorLog("JobOrder Data is Null (Joborder Id)");
                return -1;
            }

            if (joborderdata.Equipmentid == null)
            {
                Log.ErrorLog("JobOrder Data is Null (Equipment Id)");
                return -1;
            }

            if (joborderdata.Jobtype == null)
            {
                Log.ErrorLog("JobOrder Data is Null (Jobtype)");
                return -1;
            }

            // 1. 동일 id가 있는지 check
            var orderCount = checkJobOrderId(joborderdata.Joborderid);

            // 장비가 존재하는지
            TbEquipmentinfo eqp = getEquipmentInfo(joborderdata.Equipmentid);

            if (eqp == null)
            {
                Log.ErrorLog($"Unknown Equipment : {joborderdata.Equipmentid}");
                return -1;
            }

                // 2. 작업을 진행중인지 check
            var orderRunningCount = checkIsRunningJob(joborderdata.Equipmentid);

            if(joborderdata.Jobtype == "MV")
            {
                // TODO : MV job vaild check
                return 0;
            }

            var isTransferPointFrom = isTransferPoint(joborderdata.Fromblock,  joborderdata.Frombay, joborderdata.Fromrow);
            var isTransferPointTo = isTransferPoint(joborderdata.Toblock, joborderdata.Tobay, joborderdata.Torow);
            var isFromBayEven = joborderdata.Frombay != null && int.Parse(joborderdata.Frombay) % 2 == 0 ? true : false;
            var isToBayEven = joborderdata.Tobay != null && int.Parse(joborderdata.Tobay) % 2 == 0 ? true : false;

            // 3. FROM TO check.
            if (joborderdata.Fromlocationtype == "ONCHASSIS" && isTransferPointFrom == false)
            {
                Log.ErrorLog($"From Row is not Transfer Point [{joborderdata.Joborderid}, BLOCK : {joborderdata.Fromblock},  ROW : {joborderdata.Fromrow}]");
                return -1;
            }
            else
            {
                if (joborderdata.Fromlocationtype == null)
                {
                    //Log.ErrorLog($"From is not Available Point [{joborderdata.Joborderid}, BLOCK : {joborderdata.Fromblock}],  ROW : {joborderdata.Fromrow}, BAY : {joborderdata.Frombay}, TIER : {joborderdata.Fromtier}]");
                }
                else if (joborderdata.Fromlocationtype != "ONCHASSIS")
                {
                    if (isAvailableInventory(joborderdata.Fromblock, joborderdata.Fromrow, joborderdata.Frombay,
                            joborderdata.Fromtier, true) == false)
                    {
                        Log.ErrorLog($"From is not Available Point [{joborderdata.Joborderid}, BLOCK : {joborderdata.Fromblock}],  ROW : {joborderdata.Fromrow}, BAY : {joborderdata.Frombay}, TIER : {joborderdata.Fromtier}]");
                        return -1;
                    }
                }
            }

            if (joborderdata.Tolocationtype == "ONCHASSIS" && isTransferPointTo == false)
            {
                Log.ErrorLog($"To Row is not Transfer Point [{joborderdata.Joborderid}, BLOCK : {joborderdata.Toblock},  ROW : {joborderdata.Torow}]");
                return -1;
            }
            else
            {
                if (joborderdata.Tolocationtype != "ONCHASSIS")
                {
                    if (isAvailableInventory(joborderdata.Toblock, joborderdata.Torow, joborderdata.Tobay,
                            joborderdata.Totier, false) == false)
                    {
                        Log.ErrorLog($"To is not Available Point [{joborderdata.Joborderid}, BLOCK : {joborderdata.Toblock}],  ROW : {joborderdata.Torow}, BAY : {joborderdata.Tobay}, TIER : {joborderdata.Totier}]");
                        return -1;
                    }
                }
            }

            // 4. Container Check.
            if (int.TryParse(joborderdata.Containersize, out int crtnSize))
            {
                if (crtnSize <= 20 && (isToBayEven == true || isFromBayEven == true))
                {
                    Log.ErrorLog($"Container size not input to Bay [{joborderdata.Joborderid}, CONTAINER SIZE : {crtnSize}, FROM BAY : {joborderdata.Frombay}, TO BAY : {joborderdata.Tobay}]");
                    return -1;
                }
                else if (crtnSize > 20 && (isToBayEven == false || isFromBayEven == false))
                {
                    Log.ErrorLog($"Container size not input to Bay [{joborderdata.Joborderid}, CONTAINER SIZE : {crtnSize}, FROM BAY : {joborderdata.Frombay}, TO BAY : {joborderdata.Tobay}]");
                    return -1;
                }
            }

            if (joborderdata.Tolocationtype == "YARD" && checkContainerId(joborderdata.Containerid))
            {
                Log.ErrorLog($"Container is already inside Yard [{joborderdata.Joborderid}, CONTAINER ID : {joborderdata.Containerid}]");
                return -1;
            }

            if (orderCount > 0)
            {
                Log.ErrorLog($"JobOrder is Duplicate [{joborderdata.Joborderid}]");
                return -1;
            }

            if(orderRunningCount > 0)
            {
                Log.ErrorLog($"This Equipment is Running Job [{joborderdata.Equipmentid}]");
                return -1;
            }

            return rtnCode;
        }

        private TbEquipmentinfo getEquipmentInfo(string equipmentid)
        {

            TbEquipmentinfo equipment = dbcontext.TbEquipmentinfos
                                            .Where(e => e.Equipmentid == equipmentid)
                                            .FirstOrDefault();

            return equipment;
        }

        public int checkIsRunningJob(string equipmentid)
        {
            int rtnCode = 0;

            var runningJob = dbcontext.TbJoborders.Where(a => a.Equipmentid.Contains(equipmentid) && a.Jobstatus != "Completed" && a.Jobstatus != "Rejected").Select(a => a);

            rtnCode = runningJob.Count();
             
            return rtnCode;
        }


        public int checkJobOrderId(string joborderid)
        {
            int rtnCode = 0;

            var samejoborder = dbcontext.TbJoborders.Where(a => a.Joborderid.Contains(joborderid) && a.Jobstatus != "Completed").Select(a => a);
            rtnCode = samejoborder.Count();

            return rtnCode;
        }


        public void StepJobEnd(TbEquipment eqpInfo, TbViewjobtracking viewStepJob)
        {
            Log.InfoLog("StepJobEnd Start : " + viewStepJob.Compositionid );

            if ((CommonConstant.STEPJOBTYPE_EXECUTE == viewStepJob.Stepjobtype )
                    || (CommonConstant.STEPJOBSTATUS_START == viewStepJob.Stepjobstatus ))
            {

                using (var dbcontext = new RcmsContext())
                { 

                    TbViewjobtracking? viewStepJob1 = dbcontext.TbViewjobtrackings
                                                                .Where(e => e.Joborderid == viewStepJob.Joborderid
                                                                        &&  e.Timekey == viewStepJob.Timekey)
                                                                .FirstOrDefault();
                    if(viewStepJob1 != null)
                    {
                        viewStepJob1.Stepjobstatus = CommonConstant.STEPJOBSTATUS_COMPLETED;
                        viewStepJob1.Endtime = DateTime.Now;                                
                        viewStepJob1.Endmode = CommonConstant.EQPOPERATIONMODE_AUTO;        
                        viewStepJob1.Endsystem = "EIS";                                     
                        viewStepJob1.Enduserid = viewStepJob.Equipmentid;                   
                    }

                    // StepJob Start 시 Interface 하도록 설정되어 있으면 Interface 함수 수행
                    if ((CommonConstant.IFACTIONTYPE_END == viewStepJob.Ifactiontype)
                            || (CommonConstant.IFACTIONTYPE_BOTH == viewStepJob.Ifactiontype)
                            || (CommonConstant.IFACTIONTYPE_EXECUTE == viewStepJob.Ifactiontype ))
                    {

                        // IFFUNCTIONNAME 수행
                        if (InterfaceManager.getInstance().ExecuteIFFunction(viewStepJob))
                        {
                            viewStepJob.Endiftime = DateTime.Now;//.setENDIFTIME(DateUtil.getCurrentTimestamp());
                            Log.InfoLog(viewStepJob.Startiffunctionname + " END_IF_TIME : " + viewStepJob.Endiftime );
                        }
                    }
                    dbcontext.SaveChanges();

                }
                deAssignedRCS(viewStepJob);
            }
            else
            {
                Log.ErrorLog("StepJob End ViewJobTracking StepJobStatus Invalid!");
                //Log.ErrorLog("SITEID        : " + viewStepJob.getKeySITEID());
                Log.ErrorLog("JOBORDERID    : " + viewStepJob.Joborderid );
                Log.ErrorLog("TIMEKEY       : " + viewStepJob.Timekey );
                Log.ErrorLog("COMPOSITIONID : " + viewStepJob.Compositionid );
                Log.ErrorLog("STEPJOBSTATUS : " + viewStepJob.Stepjobstatus );
            }

        }

        //
        // RCS 할당해제 처리 (현재 StepJob의 ViewJobParameter에 RCSID가 존재 조건)
        // 
        public void deAssignedRCS(TbViewjobtracking viewStepJob)
        {
            // 수정해야 함.
            /*
            String rcsID = getRCSID(viewStepJob);
            if (rcsID.isEmpty() || rcsID.equals(Constant.ECS_WAITINGRCSID)) return;

            EQUIPMENTINFO oRCS = new EQUIPMENTINFO();
            oRCS.setKeySITEID(viewStepJob.getKeySITEID());
            oRCS.setKeyEQUIPMENTID(rcsID);
            oRCS = (EQUIPMENTINFO)oRCS.excuteDML(SqlConstant.DML_SELECTWITHUDPLOCK);
            oRCS.setEQUIPMENTSTATUS(Constant.EQUIPMENTSTATUS_IDLE);
            oRCS.setJOBORDERID("");
            oRCS.setCOMPOSITIONID("");
            oRCS.setLASTUPDATETIME(txnInfo.getEventTime());
            oRCS.setLASTUPDATEUSERID(txnInfo.getTxnUser());
            oRCS.excuteDML(SqlConstant.DML_UPDATE);
            AddHistory history = new AddHistory();
            history.addHistory(oRCS, txnInfo, Constant.ROWSTATUS_UPDATE);
            */
        }


        // RCS 할당 처리 (현재 StepJob의 ViewJobParameter에 RCSID가 존재 조건)
        // @param jobOrder

        public string getRCSID(TbViewjobtracking viewStepJob)
        {
            string sReturn = "";


            //using(var dbcontext = new )
            using (var dbcontext = new RcmsContext())
            {

                // 이미 생성되어 있으면 ViewJobParameter 를 생성하지 않는다.
                //VIEWJOBPARAMETER checkParameter = new VIEWJOBPARAMETER();
                //checkParameter.setKeySITEID(viewStepJob.getKeySITEID());
                //checkParameter.setKeyJOBORDERID(viewStepJob.getKeyJOBORDERID());
                //checkParameter.setKeyTIMEKEY(viewStepJob.getKeyTIMEKEY());
                //checkParameter.setKeyCOMPOSITIONID(viewStepJob.getCOMPOSITIONID());

                List<TbViewjobparameter> listParameter = dbcontext.TbViewjobparameters //(List<VIEWJOBPARAMETER>)checkParameter.excuteDML(SqlConstant.DML_SELECTLIST);
                                                                    .Where(e => e.Joborderid == viewStepJob.Joborderid
                                                                            &&  e.Timekey == viewStepJob.Timekey
                                                                            &&  e.Compositionid == viewStepJob.Compositionid)
                                                                    .ToList();
                if (listParameter.Count() > 0)
                {
                    // Parameter ID 의 ParameterType이 RCS인경우 RCS 할당 작업
                    for (int i = 0; i < listParameter.Count(); i++)
                    {
                        TbViewjobparameter oViewJobParameter = listParameter[i];//.get(i);

                        TbParameter oParameter = new TbParameter();
                        //oParameter.setKeySITEID(oViewJobParameter.getKeySITEID());
                        //oParameter.setKeyPARAMETERID(oViewJobParameter.getKeyPARAMETERID());
                        //oParameter = (PARAMETERDEFINITION)oParameter.excuteDML(SqlConstant.DML_SELECTROW);

                        if (oParameter.Parametertype == CommonConstant.PARAMETERTYPE_RCS)
                        {
                            sReturn = oViewJobParameter.Tagvalue;// .getTAGVALUE();      // r_RCSID에 해당하는 TAGVALUE
                            break;
                        }
                    }
                }
            }

            return sReturn;
        }


        public TbViewjobtracking? GetNextViewJobTracking(TbViewjobtracking currentTracking)
        {
            using (var dbcontext = new RcmsContext())
            {
                TbViewjobtracking? viewJobTracking = dbcontext.TbViewjobtrackings
                                                        .Where(e => e.Joborderid == currentTracking.Joborderid
                                                                &&  e.Stepsequence > currentTracking.Stepsequence)
                                                        .OrderBy(e => e.Joborderid)
                                                        .ThenBy(e => e.Stepsequence)
                                                        .FirstOrDefault();
                return viewJobTracking;
            }
        }



        // @param viewJobTracking
        public bool JobOrderCompleted(TbViewjobtracking viewJobTracking)
        {
            bool bReturn = false;

            using (var dbcontext = new RcmsContext())
            {
                // 해당 StepJob 모두 완료되었을때 처리
                // ViewJobTracking의 StepJobStatus가 모두 Completed 일때
                // JobOrder 의 JObStatus 변경
                // -- 해당 EQUIPMENTID 상태 변경은 여기서 처리하지 말고 EIS 에서 ChangeEquipmentStatus 메세지를 받아 처리한다.

                //HashMap<String, String> bindMap = new HashMap<String, String>();
                //bindMap.put("SITEID", viewJobTracking.getKeySITEID());
                //bindMap.put("JOBORDERID", viewJobTracking.getKeyJOBORDERID());

                //String Sql = " SELECT V.TIMEKEY, V.COMPOSITIONID, V.STEPJOBSTATUS "
                //        + " FROM VIEWJOBTRACKING V "
                //        + " WHERE V.SITEID = :SITEID "
                //        + " AND V.JOBORDERID = :JOBORDERID "
                //        + " AND V.STEPJOBSTATUS <> 'Completed' "
                //        ;


                List<TbViewjobtracking> listViewJob = dbcontext.TbViewjobtrackings
                                                                .Where(e => e.Joborderid == viewJobTracking.Joborderid
                                                                        &&  e.Stepjobstatus != "Completed")
                                                                .ToList();
    

                //List<HashMap<String, String>> DataList = SqlMesTemplate.queryForList(Sql, bindMap);

                // 모둔 StepJob이 Completed 되면 JobOrder Update 를 수행한다.
                if (listViewJob.Count() == 0)
                {
                    // EquipmentInfo 상태업데이트 (Idle -> Run, JobOrderID, StepJobID)
                    // **** 해당 EQUIPMENTID 상태 변경은 여기서 처리하지 말고 
                    //     EIS 에서 ChangeEquipmentStatus 메세지를 받아 처리할 경우 주석처리 예정

                    //EQUIPMENTINFO eqpInfo = new EQUIPMENTINFO();
                    //eqpInfo.setKeySITEID(viewJobTracking.getKeySITEID());
                    //eqpInfo.setKeyEQUIPMENTID(viewJobTracking.getEQUIPMENTID());
                    //eqpInfo = (EQUIPMENTINFO)eqpInfo.excuteDML(SqlConstant.DML_SELECTWITHUDPLOCK);

                    //eqpInfo.setEQUIPMENTSTATUS(Constant.EQUIPMENTSTATUS_IDLE);
                    //eqpInfo.setJOBORDERID("");
                    //eqpInfo.setCOMPOSITIONID("");
                    //eqpInfo.setLASTUPDATETIME(txnInfo.getEventTime());
                    //eqpInfo.setLASTUPDATEUSERID(txnInfo.getTxnUser());
                    //eqpInfo.excuteDML(SqlConstant.DML_UPDATE);
                    //history.addHistory(eqpInfo, txnInfo, Constant.ROWSTATUS_UPDATE);

                    TbEquipmentinfo? eqpInfo = dbcontext.TbEquipmentinfos
                                                    .Where(e => e.Equipmentid == viewJobTracking.Equipmentid)
                                                    .FirstOrDefault();

                    if(eqpInfo != null)
                    {
                        // ADD HISTORY
                        //dbcontext.tbhis
                    }


                    //JOBORDER jobInfo = new JOBORDER();
                    //jobInfo.setKeySITEID(viewJobTracking.getKeySITEID());
                    //jobInfo.setKeyJOBORDERID(viewJobTracking.getKeyJOBORDERID());
                    //jobInfo = (JOBORDER)jobInfo.excuteDML(SqlConstant.DML_SELECTWITHUDPLOCK);
                    //jobInfo.setJOBSTATUS(Constant.JOBSTATUS_COMPLETED);
                    //jobInfo.setENDTIME(DateUtil.getCurrentTimestamp());
                    //jobInfo.excuteDML(SqlConstant.DML_UPDATE);
                    //history.addHistory(jobInfo, txnInfo, Constant.ROWSTATUS_UPDATE);

                    TbJoborder? jobInfo = dbcontext.TbJoborders
                                                    .Where(e => e.Joborderid == viewJobTracking.Joborderid)
                                                    .FirstOrDefault();

                    if(jobInfo != null)
                    {
                        jobInfo.Jobstatus = CommonConstant.JOBSTATUS_COMPLETED;
                        jobInfo.Endtime = DateTime.Now;

                        // TOS Service에 JobCompleted 보고한다.
                        //InterfaceManager.getInstance().TOSSendMessage(jobInfo, CommonConstant.IF_TOS_JOBCOMPLETED);

                    }

                    dbcontext.SaveChanges();
                    // **************중요
                    //  TOS에서 SetInventory 받아 처리해야 한다.
                    //  TOS Interface 전에 임시 사용
                    /*
                    EnumConstant enumValue = new EnumConstant();
                    String sECSInventoryFlag = enumValue.getDescriptionByEnumValue(jobInfo.getKeySITEID(), Constant.ENUMID_ECSPOLICY, Constant.ENUMVALUE_JOBCOMPLETEDINVENTORYFLAG);
                    if (sECSInventoryFlag.equals(Constant.FLAG_YESNO_YES))
                    {
                        SetInventory(jobInfo);
                    }
                    */

                    bReturn = true;
                }
                else
                {
                    Log.ErrorLog("StepJob End ViewJobTracking StepJob Not Completed!");
                    //Log.ErrorLog("SITEID        : " + viewJobTracking.getKeySITEID());
                    Log.ErrorLog("JOBORDERID    : " + viewJobTracking.Joborderid );
                    Log.ErrorLog("TIMEKEY       : " + listViewJob[0].Timekey);
                    Log.ErrorLog("COMPOSITIONID : " + listViewJob[0].Compositionid);
                    Log.ErrorLog("STEPJOBSTATUS : " + listViewJob[0].Stepjobstatus);
                }
            }

            return bReturn;
        }

    }
}
