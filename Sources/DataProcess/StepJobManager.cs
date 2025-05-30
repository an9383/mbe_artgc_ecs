using System;
using System.Collections;
using System.Windows.Forms;
using KR.MBE.CommonLibrary;
using KR.MBE.Message;
using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Apache.NMS.Util;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Globalization;
using System.Collections.Generic;
using Apache.NMS.ActiveMQ.Threads;
using static KR.MBE.Data.Constant;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using System.Reflection.Metadata;
using System.Drawing;
using Newtonsoft.Json.Linq;
using System.Windows.Forms.Design;
using System.Security.Policy;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.EntityFrameworkCore.Internal;
using String = System.String;
using KR.MBE.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using KR.MBE.RCMS.Models;


namespace DataProcess
{
    public class StepJobManager
    {
        public class ReceivedIdInforamtion
        {
            public ReceivedIdInforamtion(string[] list)
            {
                if (list.Length >= 2)
                {
                    Tablename = list[0];
                    ReceivedId = list[1];
                }

            }

            public ReceivedIdInforamtion(string pTablename, string pReceivedId)
            {
                Tablename = pTablename;
                ReceivedId = pReceivedId;
            }

            public string Tablename { get; set; }
            public string ReceivedId { get; set; }
        }
            

        public static JobOrderManager JobOrderMan = new JobOrderManager();
        public static StepJobManager StepJobMan = new StepJobManager();
        //public Hashtable m_htCreateStepJobList = null;

        // List 생성
        public static BindingList<TbJoborder> m_StepJobOrderList = new BindingList<TbJoborder>();


        public static EISManager EISman = new EISManager();

        private static object lockobject = new object();

        public StepJobManager()
        {
            //m_htCreateStepJobList = new Hashtable();
            //m_StepJobOrderList = new List<Joborder>();

            //Thread monitorThread = new Thread(new ThreadStart(ProcessingStepJobOrderList));
            //monitorThread.Start();

        }

        //public void StepJobStartRequest(List<TbViewjobtracking> ListViewStepJob)
        public void StepJobStartRequest(TbViewjobtracking ViewStepJob)
        {
            Log.InfoLog("StepJobStartRequest Start : " + ViewStepJob.Compositionid);

            var dbcontext = new RcmsContext();
            bool brtEISSend = false;


            // makeviewjobparameter.
            //for (int i=0;i<ListViewStepJob.Count;i++)
            if(ViewStepJob != null)
            {
                //TbViewjobtracking viewStepJob = ListViewStepJob[i];
                var jobInfo = dbcontext.TbJoborders
                                        .Where(e => e.Joborderid == ViewStepJob.Joborderid)
                                        .FirstOrDefault();

                if(jobInfo == null)
                {
                    Log.ErrorLog("StepJobStartRequest function Error {0} joborderid에 해당하는 JobOrder가 없음" + ViewStepJob.Joborderid);
                    return;
                }

                var eqp = dbcontext.TbEquipmentinfos
                                        .Where(e => e.Equipmentid == jobInfo.Equipmentid)
                                        .FirstOrDefault();

                if (eqp == null)
                {
                    Log.ErrorLog("StepJobStartRequest function Error  eqp 해당하는 Equipment가 없음" + jobInfo.Equipmentid);
                    return;
                }

                // 현재 진행할 StepJob 의 CreateDataType = 'RealTime' 인경우 ViewJobParameter 를 생성한다.
                if (CommonConstant.CREATEDATATYPE_REALTIME == ViewStepJob.Createdatatype)
                {
                    makeViewJobParameter(ViewStepJob);
                }

                // EIS 에 최초 Message 를 Send 한다.
                // OPERATIONMODE가   Auto인 경우만 EIS => SEND
                //    StepJobStatus = 'Wait' 인 첫 공정에 대해서 EIS에 StepJobRequest Message를 전송한다.
                // wait가 두개일경우 어떻게 처리할건지...
                if(  (CommonConstant.STEPJOBOPERATIONMODE_AUTO == (ViewStepJob.Operationmode) ) &&
                    (brtEISSend==false)    )
                {
                    // EIS SEND 
                    brtEISSend = true;
                    EISman.sendStepJobRequestMessage(ViewStepJob);
                }
            }   // listviewjob



            /*

            // ViewJobParameter 의 ParameterID가 RCSID인경우 해당 RCSID의 상태 변경
            bool bStartRequestOK = true;
            string sRCSID = "";// getRCSID(viewStepJob);
            if (string.IsNullOrEmpty(sRCSID))
            {
                if (sRCSID == CommonConstant.ECS_WAITINGRCSID)   // WaitingRCSID
                {
                    // 놀고 있는 RCSID가 없는 경우 RCSID = WaitingRCSID 로 가져온다.
                    // 즉 가용한 RCS가 없어 StepJob StartRequest를 보내지 않는다.
                    bStartRequestOK = false;

                    //if (viewStepJob.Description .getDESCRIPTION().isEmpty())
                    if (string.IsNullOrEmpty(viewStepJob.Description))
                    {
                        viewStepJob.Description = (CommonConstant.ECS_WAITINGRCSID);
                    }
                    else
                    {
                        viewStepJob.Description = viewStepJob.Description + " " + CommonConstant.ECS_WAITINGRCSID;
                    }

                    //viewstepjob update
                    //dbcontext.TbViewjobtrackings.Select(e => e.Joborderid == )

                    //viewStepJob.excuteDML(CommonConstant.DML_UPDATE);
                }
                else
                {
                    // RCS 상태 변경
                    //assignedRCS(sRCSID, viewStepJob, txnInfo);
                    //jobInfo.setREMOTESTATIONID(sRCSID);
                }
            }
 
            //jobInfo.excuteDML(CommonConstant.DML_UPDATE);
            //history.addHistory(jobInfo, txnInfo, CommonConstant.ROWSTATUS_UPDATE);

            if (bStartRequestOK)
            {
                // Equipment 상태업데이트 (Idle -> Run, JobOrderID, StepJobID)
                //eqp.setEQUIPMENTSTATUS(Constant.EQUIPMENTSTATUS_RUN);
                //eqp.setJOBORDERID(viewStepJob.getKeyJOBORDERID());
                //eqp.setCOMPOSITIONID(viewStepJob.getCOMPOSITIONID());
                //eqp.setLASTUPDATETIME(txnInfo.getEventTime());
                //eqp.setLASTUPDATEUSERID(txnInfo.getTxnUser());
                //eqp.excuteDML(SqlConstant.DML_UPDATE);

                //history.addHistory(eqp, txnInfo, CommonConstant.ROWSTATUS_UPDATE);

                // ViewJobTracking 의 StepJob 상태 업데이트 (Wait -> StartRequest)
                if (CommonConstant.STEPJOBSTATUS_WAIT == (viewStepJob.Stepjobstatus))
                {
                    viewStepJob.Stepjobstatus = CommonConstant.STEPJOBSTATUS_STARTREQUEST;
                }

                // Interface ActionType = 'TimeOut' 인 경우 
                if ((CommonConstant.IFACTIONTYPE_TIMEOUT == (viewStepJob.Stepjobstatus)))
                {
                    // TimeOut 계산을 위해 StartIFTime에 저장한다.
                    viewStepJob.Startiftime = DateTime.Now;// .setSTARTIFTIME(DateUtil.getCurrentTimestamp());
                }

                // EIS 에 최초 Message 를 Send 한다.
                // OPERATIONMODE가   Auto인 경우만 EIS => SEND

                //    StepJobStatus = 'Wait' 인 첫 공정에 대해서 EIS에 StepJobRequest Message를 전송한다.
                // wait가 두개일경우 어떻게 처리할건지...
                if (CommonConstant.STEPJOBOPERATIONMODE_AUTO == (viewStepJob.Operationmode))
                {
                    // EIS SEND 
                    ;//EISService.sendStepJobRequestMessage(viewStepJob);
                }

            }
            */




        }


        public void makeViewJobTracking(TbJoborder jobOrder)
        {

            try
            {
                Log.InfoLog("makeViewJobTracking Start : " + jobOrder.Joborderid);

                using (var dbcontext = new RcmsContext())
                {
                    //List<TbStepcomposition> jobFlow = new TbStepcomposition();
                    var listStepJob = dbcontext.TbStepcompositions
                                                        .Where(e => e.Jobid == jobOrder.Jobid)
                                                        .OrderBy(e => e.Stepsequence)
                                                        .ToList();
                    //jobFlow.setKeySITEID(jobOrder.getKeySITEID());
                    //jobFlow.setKeyJOBID(jobOrder.getJOBID());

                    //List<TbStepcomposition> listStepJob = (List<STEPCOMPOSITION>)jobFlow.excuteDML(SqlConstant.DML_SELECTLIST, "ORDER BY STEPSEQUENCE");

                    if (listStepJob == null)
                    {
                        Log.ErrorLog("makeViewJobTracking function Error StepJob is null, Job Type :{0}" + jobOrder.Jobid);
                        return;
                    }

                    if (listStepJob.Count == 0)
                    {
                        Log.ErrorLog("makeViewJobTracking function Error Not Defined Step Job, Job Type :{0}" + jobOrder.Jobid);
                        return;
                    }

                    foreach (var stepJob in listStepJob)
                    {
                        var stepJobDefinition = dbcontext.TbStepjobs
                            //.Where(e => e.Stepjobid == oStepJob.Jobid)
                            .Where(e => e.Stepjobid == stepJob.Stepjobid)
                            .FirstOrDefault();


                        if (stepJobDefinition == null)
                        {
                            Log.ErrorLog("makeViewJobTracking function Error  stepJobDefinition null stepjobid:{0}" + stepJob.Jobid);
                            return;
                        }

                        var viewJobTracking = new TbViewjobtracking
                        {
                            Joborderid = jobOrder.Joborderid,
                            Timekey = DateTime.Now.ToString("yyyyMMddHHmmssfff"),//   DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"),
                            Equipmentid = jobOrder.Equipmentid,
                            Jobid = jobOrder.Jobid,
                            Stepjobid = stepJob.Stepjobid,
                            Stepsequence = stepJob.Stepsequence,
                            Stepjobtype = stepJobDefinition.Stepjobtype,
                            Compositionid = stepJob.Compositionid,
                            Stepjobstatus = CommonConstant.STEPJOBSTATUS_WAIT,
                            Description = stepJob.Description,
                            Operationmode = stepJob.Operationmode,
                            Createdatatype = stepJob.Createdatatype,
                            Ifactiontype = stepJob.Ifactiontype,
                            Startiffunctionname = stepJob.Startiffunctionname,
                            Endiffunctionname = stepJob.Endiffunctionname,
                            Preiffunctionname = stepJob.Preiffunctionname,
                            Starttime = null,
                            Startuserid = "",
                            Startmode = "",
                            Startsystem = "",
                            Startiftime = null,
                            Endtime = null,
                            Enduserid = "",
                            Endmode = "",
                            Endsystem = "",
                            Endiftime = null
                        };
                        
                        if (CommonConstant.CREATEDATATYPE_RECEIVEDTIME == viewJobTracking.Createdatatype)   // .equals( .getCREATEDATATYPE()))
                        {
                            makeViewJobParameter(viewJobTracking);
                        }

                        // 새 엔티티를 DbSet에 추가
                        dbcontext.TbViewjobtrackings.Add(viewJobTracking);

                        // 변경 사항을 데이터베이스에 저장
                        dbcontext.SaveChanges();

                        Log.InfoLog("makeViewJobTracking ViewJobTracking Insert {0} {1}" + stepJob.Jobid);

                        // CREATEDATATYPE = 'ReceiveTime' 인경우 Parameter를 생성한다.  => "ReceivedTime"
                        
                    }
                }
            }
            catch (Exception ex)
            {
                Log.ErrorLog("makeViewJobTracking Error : " + ex.Message);
            }

            Log.InfoLog("makeViewJobTracking End : " + jobOrder.Joborderid);
        }



        public void makeViewJobParameter(TbViewjobtracking viewStepJob)
        {
            try
            {
                Log.InfoLog("makeViewJobParameter Start : " + viewStepJob.Compositionid);

                using (var dbcontext = new RcmsContext())
                {
                    // 이미 생성되어 있으면 ViewJobParameter 를 생성하지 않는다.
                    var listParameter = dbcontext.TbViewjobparameters
                                                                       .Where(e => e.Joborderid == viewStepJob.Joborderid
                                                                            && e.Timekey == viewStepJob.Timekey
                                                                            && e.Compositionid == viewStepJob.Compositionid)
                                                                       .ToList();
                    if (listParameter != null)
                    {
                        if (listParameter.Count > 0)
                        {
                            // 기존 Data 삭제
                            dbcontext.TbViewjobparameters.RemoveRange(listParameter);
                            dbcontext.SaveChanges();
                            Log.InfoLog("VIEWJOBPARAMTER TABLE이 삭제되었습니다.  {0} {1} " + viewStepJob.Joborderid);
                        }
                    }

                    var listParamComp = dbcontext.TbParametercompositions
                                               .Where(e => e.Compositionid == viewStepJob.Compositionid)
                                               .OrderBy(e => e.Parameterlevel)
                                               .ThenBy(e => e.Orderindex)
                                               .ToList();

                    if(listParamComp == null)
                    {
                        Log.ErrorLog("makeViewJobParameter ParameterComposition이 없습니다.{0} " + viewStepJob.Compositionid);
                        return;
                    }

                    if(listParamComp.Count == 0)
                    {
                        Log.ErrorLog("makeViewJobParameter ParameterComposition이 없습니다.{0} " + viewStepJob.Compositionid);
                        return;
                    }

                    var setParam = new List<TbViewjobparameter>();

                    foreach (var paramComp in listParamComp)
                    {
                        Log.InfoLog("Parameter : " + paramComp.Parameterid);


                        var equipmentTagComposition = dbcontext.TbEquipmenttagcompositions.Where(e => e.Equipmentid == viewStepJob.Equipmentid && e.Parameterid == paramComp.Parameterid).FirstOrDefault();
                        var equipmentReciveTagComposition = dbcontext.TbEquipmenttagcompositions.Where(e => e.Equipmentid == viewStepJob.Equipmentid && e.Parameterid == paramComp.Receiveid).FirstOrDefault();

                        if (equipmentTagComposition == null)
                        {
                            Log.ErrorLog($"makeViewJobParameter : '{viewStepJob.Equipmentid}/{paramComp.Parameterid}' Parameterid가 없습니다.{0} ");
                            continue;
                        }

                        // Get TagID
                        var sTagID = equipmentTagComposition.Tagid;

                        if (string.IsNullOrEmpty(sTagID))
                        {
                            Log.ErrorLog("makeViewJobParameter TagID가 없습니다.{0} " + viewStepJob.Equipmentid);
                            continue;
                        }

                        var jobOrder = dbcontext.TbJoborders
                            .Where(e => e.Joborderid == viewStepJob.Joborderid)
                            .FirstOrDefault();

                        if (jobOrder == null)
                        {
                            Log.ErrorLog("makeViewJobParameter JobOrder가 없습니다.{0} " + viewStepJob.Joborderid);
                            continue;
                        }

                        var sTagValue = getParameterValue(jobOrder, viewStepJob, paramComp);

                        var viewJobParameter = new TbViewjobparameter
                        {
                            Joborderid = viewStepJob.Joborderid,
                            Timekey = viewStepJob.Timekey,
                            Compositionid = viewStepJob.Compositionid,
                            Actiontype = paramComp.Actiontype,
                            Parameterid = paramComp.Parameterid,
                            Parameterlevel = paramComp.Parameterlevel,
                            Tagid = sTagID,       // EQUIPMENTTAGCOMPOSITION
                            Tagvalue = sTagValue,    // 
                            Dataactiontype = paramComp.Dataactiontype,
                            Dataprocesstype = paramComp.Dataprocesstype,
                            Description = string.Empty,
                            Receivedid = equipmentReciveTagComposition == null ? paramComp.Receiveid: equipmentReciveTagComposition.Tagid,
                            Datafailtarget = paramComp.Datafailtarget,
                            Datatarget = paramComp.Datatarget,
                            Parameterstatus = "Processing"
                        };

                        setParam.Add(viewJobParameter);
                        // viewjobparameter add & save logic 추가.

                    }


                    if(setParam.Count == listParamComp.Count)
                    {
                        dbcontext.TbViewjobparameters.AddRange(setParam);
                        dbcontext.SaveChanges();
                    }
                    else
                    {
                        Log.ErrorLog("makeViewJobParameter param 데이터 오류 {0} " + viewStepJob.Joborderid);
                    }
                }
            } catch (Exception ex)
            {
                Log.ErrorLog("makeViewJobParameter Error : " + ex.Message);
            }
        }

        public ReceivedIdInforamtion getParameterReceivedIdInfo(string value)
        {
            ReceivedIdInforamtion returnVal = null;
            try
            {
                if (value.Substring(0, 1) == "@")
                {
                    value = value.Substring(1);

                    if (value.Contains('.'))
                    {
                        returnVal = new ReceivedIdInforamtion(value.Split("."));
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return returnVal;
        }

        public string getParameterValue(TbJoborder jobOrder, TbViewjobtracking viewJobTracking, TbParametercomposition parameterComposition)
        {
            string sReturn = string.Empty;
            try
            {

                if (CommonConstant.CREATEDATAMETHOD_FIXEDVALUE == parameterComposition.Createdatamethod)
                {
                    var receivedIdInfo = getParameterReceivedIdInfo(parameterComposition.Fixedstartvalue);
                    if (receivedIdInfo != null)
                    {
                        switch (receivedIdInfo.Tablename)
                        {
                            case "JOBORDER":
                                sReturn = getParameterValueByJobOrderReceiveID(jobOrder, receivedIdInfo.ReceivedId);
                                break;
                            case "VIEWJOBTRACKING":
                                sReturn = getParameterValueByViewJobTrackingReceiveID(viewJobTracking,
                                    receivedIdInfo.ReceivedId);
                                break;
                            default:
                                sReturn = string.Empty;
                                break;
                        }
                    }
                    else
                    {
                        sReturn = parameterComposition.Fixedstartvalue; //.getFIXEDVALUE();
                    }
                }

                if (CommonConstant.CREATEDATAMETHOD_INRECEIVED == parameterComposition.Createdatamethod)
                {
                    // JOBORDER RECEIVED DATA
                    string sReceiveID = parameterComposition.Receiveid; //.getRECEIVEID();
                    if (string.IsNullOrEmpty(sReceiveID))
                    {
                        sReceiveID = parameterComposition.Parameterid; //.getKeyPARAMETERID();
                    }

                    sReturn = getParameterValueByJobOrderReceiveID(jobOrder, sReceiveID);
                }

                if (CommonConstant.CREATEDATAMETHOD_MAKEFUNCTION == parameterComposition.Createdatamethod)
                {
                    sReturn = getParameterValueByMakeFunctionName(jobOrder, parameterComposition);

                    //String sMakeFunctionName = parameterComposition.getMAKEFUNCTIONNAME();
                    //sReturn = getParameterValueByMakeFunctionName(jobOrder, sMakeFunctionName);
                }
            }
            catch (Exception ex)
            {

            }

            return sReturn;
        }


        public string getParameterValueByViewJobTrackingReceiveID(TbViewjobtracking? viewJobTracking, string receiveID)
        {
            string sReturn = string.Empty;

            if(viewJobTracking != null)
            {
                switch (receiveID)
                {
                    case "STEPJOBID":
                        sReturn = viewJobTracking.Stepjobid;
                        break;
                }
            }

            return sReturn;
        }

        public string getParameterValueByJobOrderReceiveID(TbJoborder? jobOrder, string receiveID)
        {
            string sReturn = string.Empty;

            if (jobOrder != null)
            {
                switch (receiveID)
                {
                    case "SPREADERSIZE":
                        sReturn = jobOrder.Spreadersize;
                        break;
                    case "FROMBAY":
                        sReturn = jobOrder.Frombay;
                        break;
                    case "FROMBLOCK":
                        sReturn = jobOrder.Fromblock;
                        break;
                    case "FROMTIER":
                        sReturn = jobOrder.Fromtier;
                        break;
                    case "FROMROW":
                        sReturn = jobOrder.Fromrow;
                        break;
                    case "TOBAY":
                    case "craneHandlingBayNumber":
                        sReturn = jobOrder.Tobay;
                        break;
                    case "TOBLOCK":
                        sReturn = jobOrder.Toblock;
                        break;
                    case "EQUIPMENTID":
                        sReturn = jobOrder.Equipmentid;
                        break;
                    case "JOBORDERID":
                        sReturn = jobOrder.Joborderid;
                        break;
                    case "JOBTYPE":
                        sReturn = jobOrder.Jobtype;
                        break;
                }
            }

            return sReturn;
        }


        public string getParameterValueByMakeFunctionName(TbJoborder jobOrder, TbParametercomposition parameterComposition)
        {
            string? sReturn = "";

            //MakeFunction MakeFunctionService = new MakeFunction();

            string? makeFunctionName = parameterComposition.Makefunctionname;
            string? parameterValue = parameterComposition.Fixedstartvalue;

            if (parameterComposition.Fixedstartvalue != null && parameterComposition.Fixedstartvalue.Contains('@'))
            {
                if (parameterComposition.Fixedstartvalue.Substring(0, 1) == "@")
                {
                    parameterValue = parameterComposition.Fixedstartvalue.Substring(1);
                }
            }

            //getStepJobID
            //getStepJobShortName
            //getToGantryPosition
            //getSpreaderRow
            //getSpreaderRowPosition
            //getSpreaderSafeHeight

            if (makeFunctionName != null)
            {
                switch (makeFunctionName)
                {
                    case CommonConstant.F_GETSTEPJOBID:
                        sReturn = MakeFunction.getStepJobID(jobOrder, parameterComposition);
                        break;
                    case CommonConstant.F_GETSTEPJOBSHORTNAME:
                        sReturn = MakeFunction.getStepJobShortName(jobOrder, parameterComposition);
                        break;
                    case CommonConstant.F_GETFROMTROLLEYPOSITION:
                        sReturn = MakeFunction.getFromTrolleyPosition(jobOrder);
                        break;
                    case CommonConstant.F_GETFROMGANTRYPOSITION:
                        sReturn = MakeFunction.getFromGantryPosition(jobOrder);
                        break;
                    case CommonConstant.F_GETFROMHOISTPOSITION:
                        sReturn = MakeFunction.getFromHoistPosition(jobOrder);
                        break;
                    case CommonConstant.F_GETTOGANTRYPOSITION:
                        sReturn = MakeFunction.getToGantryPosition(jobOrder);
                        break;
                    case CommonConstant.F_GETTOTROLLEYPOSITION:
                        sReturn = MakeFunction.getToTrolleyPosition(jobOrder);
                        break;
                    case CommonConstant.F_GETTOHOISTPOSITION:
                        sReturn = MakeFunction.getToHoistPosition(jobOrder);
                        break;
                    case CommonConstant.F_GETSPREADERROWPOSITION:
                        sReturn = MakeFunction.getSpreaderRowPosition(jobOrder);
                        break;
                    case CommonConstant.F_GETSPREADERROW:
                        sReturn = MakeFunction.getSpreaderRow(jobOrder);
                        break;
                    case CommonConstant.F_GETSPREADERSAFEHEIGHT:
                        sReturn = MakeFunction.getSpreaderSafeHeight(jobOrder);
                        break;
                    case CommonConstant.F_GETSPREADERSIZE:
                        sReturn = MakeFunction.getSpreaderSize(jobOrder);
                        break;
                }
            }

            /*
           if (CommonConstant.F_GETFROMGANTRYPOSITION==(makeFunctionName))  // getFromGantryPosition
           {
               sReturn = MakeFunctionService.getFromGantryPosition(jobOrder);
           }
           if (CommonConstant.F_GETFROMTROLLEYPOSITION==(makeFunctionName))  // getFromTrolleyPosition
           {
               sReturn = MakeFunctionService.getFromTrolleyPosition(jobOrder);
           }
           if (CommonConstant.F_GETFROMHOISTPOSITION==(makeFunctionName))  // getFromHoistPosition
           {
               sReturn = MakeFunctionService.getFromHoistPosition(jobOrder);
           }

           if (CommonConstant.F_GETTOTROLLEYPOSITION==(makeFunctionName))  // getToTrolleyPosition
           {
               sReturn = MakeFunctionService.getToTrolleyPosition(jobOrder);
           }
           if (CommonConstant.F_GETTOHOISTPOSITION==(makeFunctionName))  // getToHoistPosition
           {
               sReturn = MakeFunctionService.getToHoistPosition(jobOrder);
           }
           if (CommonConstant.F_GETINVENTORYLIST==(makeFunctionName))  // getInventoryList
           {
               sReturn = MakeFunctionService.getInventoryList(jobOrder);
           }

           if (CommonConstant.F_GETFROMSTACKINGROW01==(makeFunctionName))  // getFromStackingRow01
           {
               sReturn = MakeFunctionService.getStackingRow(jobOrder, "FROM", 1);
           }
           if (CommonConstant.F_GETFROMSTACKINGROW02==(makeFunctionName))  // getFromStackingRow02
           {
               sReturn = MakeFunctionService.getStackingRow(jobOrder, "FROM", 2);
           }
           if (CommonConstant.F_GETFROMSTACKINGROW03==(makeFunctionName))  // getFromStackingRow03
           {
               sReturn = MakeFunctionService.getStackingRow(jobOrder, "FROM", 3);
           }
           if (CommonConstant.F_GETFROMSTACKINGROW04==(makeFunctionName))  // getFromStackingRow04
           {
               sReturn = MakeFunctionService.getStackingRow(jobOrder, "FROM", 4);
           }
           if (CommonConstant.F_GETFROMSTACKINGROW05==(makeFunctionName))  // getFromStackingRow05
           {
               sReturn = MakeFunctionService.getStackingRow(jobOrder, "FROM", 5);
           }
           if (CommonConstant.F_GETFROMSTACKINGROW06==(makeFunctionName))  // getFromStackingRow06
           {
               sReturn = MakeFunctionService.getStackingRow(jobOrder, "FROM", 6);
           }
           if (CommonConstant.F_GETFROMSTACKINGROW07==(makeFunctionName))  // getFromStackingRow07
           {
               sReturn = MakeFunctionService.getStackingRow(jobOrder, "FROM", 7);
           }
           if (CommonConstant.F_GETFROMSTACKINGROW08==(makeFunctionName))  // getFromStackingRow08
           {
               sReturn = MakeFunctionService.getStackingRow(jobOrder, "FROM", 8);
           }
           if (CommonConstant.F_GETFROMSTACKINGROW09==(makeFunctionName))  // getFromStackingRow09
           {
               sReturn = MakeFunctionService.getStackingRow(jobOrder, "FROM", 9);
           }
           if (CommonConstant.F_GETFROMSTACKINGROW10==(makeFunctionName))  // getFromStackingRow10
           {
               sReturn = MakeFunctionService.getStackingRow(jobOrder, "FROM", 10);
           }

           if (CommonConstant.F_GETTOSTACKINGROW01==(makeFunctionName))  // getToStackingRow01
           {
               sReturn = MakeFunctionService.getStackingRow(jobOrder, "TO", 1);
           }
           if (CommonConstant.F_GETTOSTACKINGROW02==(makeFunctionName))  // getToStackingRow02
           {
               sReturn = MakeFunctionService.getStackingRow(jobOrder, "TO", 2);
           }
           if (CommonConstant.F_GETTOSTACKINGROW03==(makeFunctionName))  // getToStackingRow03
           {
               sReturn = MakeFunctionService.getStackingRow(jobOrder, "TO", 3);
           }
           if (CommonConstant.F_GETTOSTACKINGROW04==(makeFunctionName))  // getToStackingRow04
           {
               sReturn = MakeFunctionService.getStackingRow(jobOrder, "TO", 4);
           }
           if (CommonConstant.F_GETTOSTACKINGROW05==(makeFunctionName))  // getToStackingRow05
           {
               sReturn = MakeFunctionService.getStackingRow(jobOrder, "TO", 5);
           }
           if (CommonConstant.F_GETTOSTACKINGROW06==(makeFunctionName))  // getToStackingRow06
           {
               sReturn = MakeFunctionService.getStackingRow(jobOrder, "TO", 6);
           }
           if (CommonConstant.F_GETTOSTACKINGROW07==(makeFunctionName))  // getToStackingRow07
           {
               sReturn = MakeFunctionService.getStackingRow(jobOrder, "TO", 7);
           }
           if (CommonConstant.F_GETTOSTACKINGROW08==(makeFunctionName))  // getToStackingRow08
           {
               sReturn = MakeFunctionService.getStackingRow(jobOrder, "TO", 8);
           }
           if (CommonConstant.F_GETTOSTACKINGROW09==(makeFunctionName))  // getToStackingRow09
           {
               sReturn = MakeFunctionService.getStackingRow(jobOrder, "TO", 9);
           }
           if (CommonConstant.F_GETTOSTACKINGROW10==(makeFunctionName))  // getToStackingRow10
           {
               sReturn = MakeFunctionService.getStackingRow(jobOrder, "TO", 10);
           }

           if (CommonConstant.F_GETRCS==(makeFunctionName))  // getRCS
           {
               sReturn = MakeFunctionService.getRCS(jobOrder);
           }
           if (CommonConstant.F_GETCCTVLIST==(makeFunctionName))  // getCCTVList
           {
               sReturn = MakeFunctionService.getCCTVList(jobOrder);
           }
           if (CommonConstant.F_GETTWISTLOCKCCTVLIST==(makeFunctionName))  // getTwistLockCCTVList
           {
               sReturn = MakeFunctionService.getTwistLockCCTVList(jobOrder);
           }
           if (CommonConstant.F_GETTWISTLOCKCCTVHTTPLIST==(makeFunctionName))  // getTwistLockCCTVHttpList
           {
               sReturn = MakeFunctionService.getTwistLockCCTVHttpList(jobOrder);
           }

           if (CommonConstant.F_GETSPREADERROW==(makeFunctionName))  // getSpreaderRow
           {
               sReturn = MakeFunctionService.getSpreaderRow(jobOrder);
           }
           if (CommonConstant.F_GETSPREADERROWPOSITION==(makeFunctionName))  // getSpreaderRowPosition
           {
               sReturn = MakeFunctionService.getSpreaderRowPosition(jobOrder);
           }
           if (CommonConstant.F_CLEARANCEUPDATE==(makeFunctionName))  // getClearanceUpdate
           {
               sReturn = MakeFunctionService.getClearanceUpdate(jobOrder);
           }




           */

            return sReturn;
        }




        //public List<TbViewjobtracking> getCurrentViewJobTracking(TbJoborder jobOrder)
        public TbViewjobtracking getCurrentViewJobTracking(TbJoborder jobOrder)
        {
            TbViewjobtracking currentViewJobTracking = null;
            List<TbViewjobtracking> listStepJob = null;

            using (var dbcontext = new RcmsContext())
            {
                // 1. Current ViewJobTracking 정보를 가져온다. (StepJobStatus = 'StartRequest') 
                /*
                TbViewjobtracking startRequestInfo = new TbViewjobtracking();
                List<TbViewjobtracking> listStartRequest = dbcontext.TbViewjobtrackings
                                                         .Where(e => e.Joborderid == jobOrder.Joborderid
                                                                && e.Equipmentid == jobOrder.Equipmentid
                                                                && e.Jobid == jobOrder.Jobid
                                                                && e.Stepjobstatus == CommonConstant.STEPJOBSTATUS_STARTREQUEST)
                                                         .OrderBy(e => e.Stepsequence)
                                                         .ToList();

                if (listStartRequest.Count() > 0)
                {
                    currentViewJobTracking = listStartRequest[0];
                }
                */

                if (currentViewJobTracking == null)
                {
                    // 2. Current ViewJobTracking 정보를 가져온다. (Wait Step Job)
                    TbViewjobtracking dataInfo = new TbViewjobtracking();
                    listStepJob = dbcontext.TbViewjobtrackings
                                                         .Where(e => e.Joborderid == jobOrder.Joborderid
                                                                && e.Equipmentid == jobOrder.Equipmentid
                                                                && e.Jobid == jobOrder.Jobid
                                                                && e.Stepjobstatus == CommonConstant.STEPJOBSTATUS_WAIT)
                                                         .OrderBy(e => e.Stepsequence)
                                                         .ToList();

                    if (listStepJob.Count() > 0)
                    {
                        // Wait중인 ViewJobTracking 의 Step JOb에 대해서 ViewJobParameter 생성
                        currentViewJobTracking = listStepJob[0];
                    }


                }
                /* */
            }
            return currentViewJobTracking;
            //return currentViewJobTracking;
        }

        public void CurrentStepJobRequest(string message)
        {
            Log.InfoLog("##### CurrentStepJobRequest Start #####################");

            //String siteID = ConvertUtil.Object2String(MessageParse.getParam(recvDoc, "SITEID"));

            
            using(var dbcontext = new RcmsContext())
            {
                // EIS 에 StepJob Parameter 정보를 내려줘야 하는 JobOrder 목록을 가져온다.
                List<TbJoborder> listJobOrder = dbcontext.TbJoborders
                                                            .Where(e => e.Jobstatus == CommonConstant.JOBSTATUS_START)
                                                            .ToList();

                // (StartRequest/Start Status Step Job)
                for (int i = 0; i < listJobOrder.Count(); i++)
                {
                    try
                    {
                        TbJoborder jobInfo = listJobOrder[i];//.get(i);
                        Log.InfoLog("##### make EIS StepJobRequest Message Start #####################");
                        Log.InfoLog(" JOBORDERID  : " + jobInfo.Joborderid);
                        Log.InfoLog(" EQUIPMENTID : " + jobInfo.Equipmentid);
                        Log.InfoLog(" JOBID       : " + jobInfo.Jobid);

                        TbViewjobtracking currentViewJobTracking = getCurrentViewJobTracking(jobInfo);

                        if (currentViewJobTracking == null)
                        {
                            Log.InfoLog(" EIS StepJobRequest Data does not Exist ! " + jobInfo.Joborderid);
                        }
                        else
                        {
                            // Wait중인 ViewJobTracking 의 Step JOb에 대해서 ViewJobParameter 생성
                            //EISService.sendStepJobRequestMessage(currentViewJobTracking);
                            EISman.sendStepJobRequestMessage(currentViewJobTracking);
                        }

                        // 하나씩 처리한다.
                        //MESFrameProxy.getTxManager().commitForce();
                    }
                    catch (Exception ex)
                    {
                        Log.ErrorLog(ex.Message);
                        //MESFrameProxy.getTxManager().rollbackForce();
                    }
                    finally
                    {
                        Log.InfoLog("##### End. #######################################");
                    }

                }
            }
        }

        private TbEquipmentinfohistory CreateEquipmentInfoHistory(string eventName, string eventType, string sJobOrderID, string sCompositionID, TbEquipmentinfo equipInfo)
        {
            return new TbEquipmentinfohistory()
            {
                Equipmentid = equipInfo.Equipmentid,
                Timekey = DateTime.Now.ToString("yyyyMMddHHmmssfff"),
                Equipmentstatus = equipInfo.Equipmentstatus,
                Commstatus = equipInfo.Commstatus,
                Operationmode = equipInfo.Operationmode,
                Automaticstatus = equipInfo.Automaticstatus,
                Pickupflag = equipInfo.Pickupflag,
                Arrivedvehicleflag = equipInfo.Arrivedvehicleflag,
                Arrivedvehicleid = equipInfo.Arrivedvehicleid,
                Joborderid = equipInfo.Joborderid,
                Compositionid = equipInfo.Compositionid,
                Blockid = equipInfo.Blockid,
                Bayid = equipInfo.Bayid,
                Lastupdatetime = equipInfo.Lastupdatetime,
                Lastupdateuserid = equipInfo.Lastupdateuserid,
                Eventname = eventName,
                Eventtype = eventType,
                Eventtime = DateTime.Now,
                Eventuserid = "ECS",
                Eventcomment = string.Format("[JOBORDERID={0}][COMPOSITIONID={1}]", sJobOrderID, sCompositionID)
            };
        }

        private TbJoborderhistory CreateJobOrderHistory(string eventName, string eventType, string sCompositionID, TbJoborder jobOrder)
        {
            return new TbJoborderhistory()
            {
                Timekey = DateTime.Now.ToString("yyyyMMddHHmmssfff"),
                Joborderid = jobOrder.Joborderid,
                Jobid = jobOrder.Jobid,
                Jobstatus = jobOrder.Jobstatus,
                Jobtype = jobOrder.Jobtype,
                Equipmentid = jobOrder.Equipmentid,
                Remotestationid = jobOrder.Remotestationid,
                Containerid = jobOrder.Containerid,
                Containeriso = jobOrder.Containeriso,
                Containersize = jobOrder.Containersize,
                Containerheight = jobOrder.Containerheight,
                Containerweight = jobOrder.Containerweight,
                Containerdoordir = jobOrder.Containerdoordir,
                Spreadersize = jobOrder.Spreadersize,
                Containertype = jobOrder.Containertype,
                Containeropr = jobOrder.Containeropr,
                Containerclass = jobOrder.Containerclass,
                Containercargotype = jobOrder.Containercargotype,
                Containerfullmty = jobOrder.Containerfullmty,
                Vehicleid = jobOrder.Vehicleid,
                Vehicletype = jobOrder.Vehicletype,
                Vehicleposition = jobOrder.Vehicleposition,
                Fromlocationtype = jobOrder.Fromlocationtype,
                Fromblock = jobOrder.Fromblock,
                Frombay = jobOrder.Frombay,
                Fromrow = jobOrder.Fromrow,
                Fromtier = jobOrder.Fromtier,
                Fromlandtype = jobOrder.Fromlandtype,
                Fromclearlance = jobOrder.Fromclearlance,
                Tolocationtype = jobOrder.Tolocationtype,
                Toblock = jobOrder.Toblock,
                Tobay = jobOrder.Tobay,
                Torow = jobOrder.Torow,
                Totier = jobOrder.Totier,
                Tolandtype = jobOrder.Tolandtype,
                Toclearlance = jobOrder.Toclearlance,
                Sendtimekey = jobOrder.Sendtimekey,
                Sendjobstatus = jobOrder.Sendjobstatus,
                Sendtopic = jobOrder.Sendtopic,
                Recvtime = jobOrder.Recvtime,
                Starttime = jobOrder.Starttime,
                Endtime = jobOrder.Endtime,
                Compositionid = jobOrder.Compositionid,
                Rejectcode = jobOrder.Rejectcode,
                Rejectcomment = jobOrder.Rejectcomment,
                Lastupdatetime = jobOrder.Lastupdatetime,
                Lastupdateuserid = jobOrder.Lastupdateuserid,
                Eventname = eventName,
                Eventtype = eventType,
                Eventtime = DateTime.Now,
                Eventuserid = "ECS",
                Eventcomment = string.Format("[COMPOSITIONID={0}]", sCompositionID)
            };
        }


        public void stepJobStart(string message)
        {
            var sJobOrderID = ConvertUtil.GetXMLRecord(message ,"JOBORDERID");
            var sEquipmentID = ConvertUtil.GetXMLRecord(message, "EQUIPMENTID");
            var sStepJobID = ConvertUtil.GetXMLRecord(message, "STEPJOBID");
            var sStepSequence = ConvertUtil.GetXMLRecord(message, "STEPSEQUENCE");
            var sCompositionID = ConvertUtil.GetXMLRecord(message, "COMPOSITIONID");

            using (var context = new RcmsContext())
            {
                var equipInfo = context.TbEquipmentinfos.Where(e => e.Equipmentid == sEquipmentID).FirstOrDefault();
                var viewJobTracking = context.TbViewjobtrackings.Where(e => e.Joborderid == sJobOrderID
                                                                            && e.Equipmentid == sEquipmentID
                                                                            && e.Stepjobid == sStepJobID
                                                                            && e.Stepsequence == int.Parse(sStepSequence)).FirstOrDefault();
                var jobOrder = context.TbJoborders.Where(e => e.Joborderid == sJobOrderID).FirstOrDefault();

                if (equipInfo == null)
                    return;

                if (viewJobTracking == null)
                    return;

                if (jobOrder == null)
                    return;

                if (string.IsNullOrEmpty(sCompositionID) && viewJobTracking != null)
                    sCompositionID = viewJobTracking.Compositionid;

                //Equipment Info History Create
                context.TbEquipmentinfohistories.Add(CreateEquipmentInfoHistory("StepJobStart", "UPDATE", sJobOrderID, sCompositionID, equipInfo));

                //Equipment Info Update
                equipInfo.Joborderid = sJobOrderID;
                equipInfo.Compositionid = sCompositionID;
                equipInfo.Lastupdateuserid = "ECS";
                equipInfo.Lastupdatetime = DateTime.Now;
                
                //Job Order History Create
                context.TbJoborderhistories.Add(CreateJobOrderHistory("StepJobStart", "UPDATE", sCompositionID, jobOrder));

                jobOrder.Lastupdateuserid = "ECS";
                jobOrder.Lastupdatetime = DateTime.Now;
                jobOrder.Starttime = DateTime.Now;
                jobOrder.Compositionid = sCompositionID;
                jobOrder.Jobstatus = CommonConstant.JOBSTATUS_START;

                viewJobTracking.Stepjobstatus = CommonConstant.STEPJOBSTATUS_START;
                viewJobTracking.Starttime = DateTime.Now;
                viewJobTracking.Startmode = CommonConstant.EQPOPERATIONMODE_AUTO;
                viewJobTracking.Startsystem = "EIS";
                viewJobTracking.Startuserid = sEquipmentID;
                
                // StepJob Start 시 Interface 하도록 설정되어 있으면 Interface 함수 수행
                if ((CommonConstant.IFACTIONTYPE_START == (viewJobTracking.Ifactiontype)) || (CommonConstant.IFACTIONTYPE_BOTH == (viewJobTracking.Ifactiontype)))
                {
                    // IFFUNCTIONNAME 수행
                    if (InterfaceManager.getInstance().ExecuteIFFunction(viewJobTracking))
                    {
                        viewJobTracking.Startiftime = DateTime.Now;
                        Log.InfoLog(viewJobTracking.Startiffunctionname  + " START_IF_TIME : " + viewJobTracking.Starttime);
                    }
                }

                context.SaveChanges();
            }
        }

        public void stepJobParameterStatusUpdate(string message)
        {
            string sJobOrderID = ConvertUtil.GetXMLRecord(message, "JOBORDERID");
            string sParameterStatus = ConvertUtil.GetXMLRecord(message, "PARAMETERSTATUS");
            string sParameterID = ConvertUtil.GetXMLRecord(message, "PARAMETERID");
            string sTagId = ConvertUtil.GetXMLRecord(message, "TAGID");
            string sCompositionID = ConvertUtil.GetXMLRecord(message, "COMPOSITIONID");


            using (var context = new RcmsContext())
            {
                var viewjobParameter = context.TbViewjobparameters.Where(e => e.Joborderid == sJobOrderID
                                                                            && e.Compositionid == sCompositionID
                                                                            && e.Parameterid == sParameterID
                                                                            && e.Tagid == sTagId).FirstOrDefault();

                if (viewjobParameter == null)
                    return;

                viewjobParameter.Parameterstatus = sParameterStatus;

                context.SaveChanges();
            }
        }

        public void stepJobEnd(string message)
        {

            string sJobOrderID = ConvertUtil.GetXMLRecord(message, "JOBORDERID");
            string sEquipmentID = ConvertUtil.GetXMLRecord(message, "EQUIPMENTID");
            string sStepJobID = ConvertUtil.GetXMLRecord(message, "STEPJOBID");
            string sStepSequence = ConvertUtil.GetXMLRecord(message, "STEPSEQUENCE");
            string sCompositionID = ConvertUtil.GetXMLRecord(message, "COMPOSITIONID");

            using (var context = new RcmsContext())
            {
                var equipInfo = context.TbEquipmentinfos.Where(e => e.Equipmentid == sEquipmentID).FirstOrDefault();
                var viewJobTracking = context.TbViewjobtrackings.Where(e => e.Joborderid == sJobOrderID
                                                                            && e.Equipmentid == sEquipmentID
                                                                            && e.Stepjobid == sStepJobID
                                                                            && e.Stepsequence == int.Parse(sStepSequence)).FirstOrDefault();
                var jobOrder = context.TbJoborders.Where(e => e.Joborderid == sJobOrderID).FirstOrDefault();

                if (equipInfo == null)
                    return;

                if (viewJobTracking == null)
                    return;

                if (jobOrder == null)
                    return;

                if (string.IsNullOrEmpty(sCompositionID) && viewJobTracking != null)
                    sCompositionID = viewJobTracking.Compositionid;

                //Equipment Info History Create
                context.TbEquipmentinfohistories.Add(CreateEquipmentInfoHistory("StepJobEnd", "UPDATE", sJobOrderID, sCompositionID, equipInfo));

                //Equipment Info Update
                equipInfo.Joborderid = sJobOrderID;
                equipInfo.Compositionid = "";
                equipInfo.Lastupdateuserid = "ECS";
                equipInfo.Lastupdatetime = DateTime.Now;


                //Job Order History Create
                context.TbJoborderhistories.Add(CreateJobOrderHistory("StepJobEnd", "UPDATE", sCompositionID, jobOrder));

                jobOrder.Lastupdateuserid = "ECS";
                jobOrder.Lastupdatetime = DateTime.Now;
                jobOrder.Compositionid = "";

                viewJobTracking.Stepjobstatus = CommonConstant.STEPJOBSTATUS_COMPLETED;
                viewJobTracking.Endtime = DateTime.Now;
                viewJobTracking.Endmode = CommonConstant.EQPOPERATIONMODE_AUTO;
                viewJobTracking.Endsystem = "EIS";
                viewJobTracking.Enduserid = sEquipmentID;

                // StepJob Start 시 Interface 하도록 설정되어 있으면 Interface 함수 수행
                if ((CommonConstant.IFACTIONTYPE_END == viewJobTracking.Ifactiontype)
                    || (CommonConstant.IFACTIONTYPE_BOTH == viewJobTracking.Ifactiontype)
                    || (CommonConstant.IFACTIONTYPE_EXECUTE == viewJobTracking.Ifactiontype))
                {

                    // IFFUNCTIONNAME 수행
                    if (InterfaceManager.getInstance().ExecuteIFFunction(viewJobTracking))
                    {
                        viewJobTracking.Endiftime = DateTime.Now;//.setENDIFTIME(DateUtil.getCurrentTimestamp());
                        Log.InfoLog(viewJobTracking.Startiffunctionname + " END_IF_TIME : " + viewJobTracking.Endiftime);
                    }
                }

                context.SaveChanges();

                TbViewjobtracking? nextViewJobTracking = JobOrderMan.GetNextViewJobTracking(viewJobTracking);

                if (nextViewJobTracking != null)
                {
                    StepJobMan.StepJobStartRequest(nextViewJobTracking);
                }
                else
                {
                    JobOrderMan.JobOrderCompleted(viewJobTracking);
                }

                //if (listTracking.size() == 1)
                /*if (viewJob != null)
                {

                    //VIEWJOBTRACKING currentTracking = listTracking.get(0);
                    JobOrderMan.StepJobEnd(eqpInfo, viewJob);

                    //// StepJob End 처리 완료
                    //MESFrameProxy.getTxManager().commitForce();

                    // TxnStartJobOrder 호출할지 여부
                    // RCS 할당 해제시 RCS 할당 대기중인 Job 처리를 위해 호출해야 함.
                    // Job Order Completed 되어 해당 Crane 다음 Job Order 수행하기 위해 호출해야 함.
                    //boolean bStartJobOrder = false;
                    string sAfterExecuteTxnName = "";
                    // ViewJobParameter에 RCSID가 존재하면 할당된 RCS 작업 완료 처리 
                    string sRCSID = JobOrderMan.getRCSID(viewJob);
                    if (!string.IsNullOrEmpty(sRCSID))
                    {
                        // Monitoring service에 ActiveMQ Message  :::: MONService.sendDeassignedToRCS(eqpInfo);
                        //bStartJobOrder = true;
                        // TxnAssignToRCS
                        sAfterExecuteTxnName = "AssignToRCS";
                    }

                    // Next Step Job 처리
                    if (nextTracking == null)
                    {
                        // 해당 StepJob 모두 완료되었을때 처리
                        // ViewJobTracking의 StepJobStatus가 모두 Completed 일때
                        // JobOrder 의 JObStatus 변경
                        // -- 해당 EQUIPMENTID 상태 변경은 여기서 처리하지 말고 EIS 에서 ChangeEquipmentStatus 메세지를 받아 처리한다.
                        if (JobOrderMan.JobOrderCompleted(viewJob))
                        {
                            //bStartJobOrder = true;
                            // 완료된 JobOrder의 Crane은 대기중인 JobOrder 를 찾아 수행한다.
                            // 놀고 있는 Crane 에 대해서만 체크하도록 개선 필요 
                            // TxnStartJobOrder
                            sAfterExecuteTxnName = "StartJobOrder";
                        }
                    }
                    else
                    {
                        // 다은 Step EIS 에 내려준다.
                        // 현재 진행할 StepJob이 존재하는 경우
                        //List<TbViewjobtracking> listnextTracking = new List<TbViewjobtracking>();
                        //listnextTracking.Add(nextTracking);
                        //StepJobMan.StepJobStartRequest(listnextTracking);
                        
                    }

                    //// StepJob End 후 다은 공정 처리 완료1
                    //MESFrameProxy.getTxManager().commitForce();


                    if (sAfterExecuteTxnName == "StartJobOrder")
                    {

                    }
                    else if(sAfterExecuteTxnName == "AssignToRCS")
                    {
                        //JobOrderMan.deAssignedRCS(viewJob);
                    }

                    // JobOrder Completed 되면 해당 Crane은 가용한 Crane이므로 다음 JobOrder수행하도록 처리
                    // RCSID 가 없어 대기중인 Job Order에 대해서 가용한 RCS 가 생겼으므로 할당 받을수 있도록 처리
                    // wait  JobOrderService.executeTransaction(sAfterExecuteTxnName);

                }
                else
                {
                    // Error 처리
                    Log.ErrorLog("VIEWJOBTRACKING 정보가 존재하지 않거나 2개 이상 조회되었습니다.");
                    Log.ErrorLog("StepJobStart Failed ! : " + message);
                }*/
            }
        }

        // Add StepJobOrder
        public static void AddStepJobOrder(ref TbJoborder stepJobOrder)
        {
            lock (lockobject)
            {
                m_StepJobOrderList.Add(stepJobOrder);
            }
        }


        // Remove StepJobOrder
        public static void RemoveFromList(ref TbJoborder stepJobOrder)
        {
            lock (lockobject)
            {
                // Delete Process
                Debug.WriteLine($"{m_StepJobOrderList[0].Joborderid} removed from list.");

                int cnt = m_StepJobOrderList.Count;

                for(int i =0;i<cnt; i++)
                {
                    TbJoborder joborder1 = m_StepJobOrderList[i];

                    if(joborder1.Joborderid == stepJobOrder.Joborderid)
                    {
                        m_StepJobOrderList.RemoveAt(i);
                        Debug.WriteLine($"{stepJobOrder.Joborderid} removed from list.");
                        return;
                    }
                }

            }

        }


        // Processing StepJobOrderList
        public static void ProcessingStepJobOrderList()
        {
            while (true)
            {
                lock (lockobject)
                {

                    //Task t1 = new Task(new Action(ProcessItemsAsync));
                    //t1.Start();

                    if (m_StepJobOrderList.Count > 0)
                    {
                        int cnt = m_StepJobOrderList.Count;

                        for (int i = 0; i < cnt; i++)
                        {
                            Debug.WriteLine("{0} {1}: jobId {2} ", i, cnt, m_StepJobOrderList[i].Joborderid);
                        }

                        TbJoborder joborder1 =  m_StepJobOrderList[0];

                        ProcessingStepJobOrderList1(ref joborder1);
                    }
                    else
                    {
                        Debug.WriteLine("stepJobOrderList is empty.");
                    }
                }
                Thread.Sleep(1000); 
            }
        }


        // stepjob 처리 후 EIS
        private static void ProcessingStepJobOrderList1(ref TbJoborder jorder)
        {

            Debug.WriteLine($"{jorder.Joborderid} process start");

        }



        //private static async Task ProcessItemsAsync()
        //{
        //    await Task.Run(() =>
        //    {
        //        lock (lockobject)
        //        {
        //            if (m_StepJobOrderList.Count > 0)
        //            {
        //                int cnt = m_StepJobOrderList.Count;

        //                for (int i = 0; i < cnt; i++)
        //                {
        //                    Debug.WriteLine("{0} {1}: jobId {2} ", i, cnt, m_StepJobOrderList[i].Jobid.ToString());
        //                }
        //            }
        //            else
        //            {
        //                Debug.WriteLine("List is empty.");
        //            }
        //        }

        //        Thread.Sleep(3000);
        //    });
        //}

        public void Function1()
        {
            // Function1 구현
            MessageBox.Show("Executing Function1");
        }

        public void Function2()
        {
            // 스레드를 시작합니다.
            Thread monitorThread = new Thread(new ThreadStart(ProcessingStepJobOrderList));
            monitorThread.Start();

            // Function2 구현
            //MessageBox.Show("Executing Function2");
        }

        public void Function3()
        {
            // Function3 구현
            MessageBox.Show("Executing Function3");
        }



    }
}
