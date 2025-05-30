using System;
using System.Collections;
using KR.MBE.CommonLibrary;
using KR.MBE.Message;
using KR.MBE.Data;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Reflection.PortableExecutable;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics.Eventing.Reader;
using System.Text;
using KR.MBE.Data.Models;
using KR.MBE.RCMS.Models;


namespace DataProcess
{
    public class PLCManager
    {

        public PLCManager()
        {
        }

        public void savePLCReadData(string message)
        {
            // ActiveMQ Message Format.
            // {"EQUIPMENTID":"CR001","STATIONID":"ST001","TAGID":"CR001_MW3550","BEFOREVALUE":"1","VALUE":"0","SCALEVALUE":""}

            // JSON 데이터를 JObject로 변환
            var jsonObj = JObject.Parse(message);

            // 변환된 데이터를 저장할 리스트
            var listdata = new List<Dictionary<string, string>>();

            // JSON 데이터를 탐색하여 Dictionary로 변환하고 리스트에 추가
            Util.FlattenJson(jsonObj, listdata);

            // 2.listdata -> TAG(RCMS DB)
            // DbSet<TbTag> TbTags { get; set; }

            //TbTag plcData = new TbTag();
            //plcData = plcDataMap(listdata);
            //DbSet<TbTag> plcData = plcDataMap(listdata);
            //plcDataMap(listdata);

            using (var dbContext = new RcmsContext())
            {
                //listdata[0]["TAGID"]              "CR001_MW3550"  string
                //listdata[0]["VALUE"]	            "1" string
                //listdata[0]["BEFOREVALUE"]	    "0" string
                var tagID = listdata[0]["TAGID"];
                var tagValue = listdata[0]["VALUE"];
                var beforeValue = listdata[0]["BEFOREVALUE"];

                var tag = dbContext.TbTags.Where(x => x.Tagid == tagID).FirstOrDefault();

                if (tag != null)
                {
                    tag.Tagvalue = tagValue;

                    var eqpTagComposition = dbContext.TbEquipmenttagcompositions.Where(x => x.Tagid == tagID).FirstOrDefault();

                    if (eqpTagComposition != null)
                    {
                        switch (eqpTagComposition.Parameterid)
                        {
                            case "commonCurrentOperationModeCR":
                                SetCraneCurrentOperationMode(eqpTagComposition.Equipmentid, tagValue);
                                break;
                            case "commonCurrentStepJobIdCR":
                                SetCraneCurrentJobId(eqpTagComposition.Equipmentid, tagValue);
                                break;
                            case "commonCurrentContainerStatusCR": // 레거시 코드
                            case "commonCurrentCraneStatusCR":
                                SetCraneCurrentStatus(eqpTagComposition.Equipmentid, tagValue);
                                break;
                        }
                    }
                    // Update Value 
                    //Debug.WriteLine("TAGID {0}, TAGVALUE {1}", tagID, tagValue);

                    dbContext.SaveChanges();
                }


            }
        }

        private void SetCraneCurrentStatus(string eqpId, string value)
        {
            try
            {
                using (var context = new RcmsContext())
                {
                    var eqpInfo = context.TbEquipmentinfos.Where(x => x.Equipmentid == eqpId).FirstOrDefault();
                    var beforeStatus = eqpInfo.Equipmentstatus;
                    var afterStatus = string.Empty;

                    if (eqpInfo != null)
                    {
                        switch (value)
                        {
                            case "1":
                                eqpInfo.Equipmentstatus = afterStatus = CommonConstant.EQUIPMENTSTATUS_MOVE;
                                break;
                            case "2":
                                eqpInfo.Equipmentstatus = afterStatus = CommonConstant.EQUIPMENTSTATUS_LOADING;
                                break;
                            case "3":
                                eqpInfo.Equipmentstatus = afterStatus = CommonConstant.EQUIPMENTSTATUS_LOADED;
                                break;
                            case "4":
                                eqpInfo.Equipmentstatus = afterStatus = CommonConstant.EQUIPMENTSTATUS_LOADEDMOVE;
                                break;
                            case "5":
                                eqpInfo.Equipmentstatus = afterStatus = CommonConstant.EQUIPMENTSTATUS_UNLOADING;
                                break;
                            case "6":
                                eqpInfo.Equipmentstatus = afterStatus = CommonConstant.EQUIPMENTSTATUS_UNLOADED;
                                break;
                            case "7":
                                eqpInfo.Equipmentstatus = afterStatus = CommonConstant.EQUIPMENTSTATUS_HOLD;
                                break;
                            case "8":
                                eqpInfo.Equipmentstatus = afterStatus = CommonConstant.EQUIPMENTSTATUS_MAINT;
                                break;
                            case "0":
                            default:
                                eqpInfo.Equipmentstatus = afterStatus = CommonConstant.EQUIPMENTSTATUS_IDLE;
                                break;
                        }

                        eqpInfo.Lastupdatetime = DateTime.Now;
                        eqpInfo.Lastupdateuserid = eqpInfo.Equipmentid;
                    }

                    if (!string.IsNullOrEmpty(afterStatus))
                    {
                        Debug.WriteLine("[Equipment Status Has been Changed][Equipment Id={0}][Before={1}][Now={2}]", eqpId, beforeStatus, afterStatus);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void SetCraneCurrentJobId(string eqpId, string value)
        {
            try
            {
                using (var context = new RcmsContext())
                {
                    var eqpInfo = context.TbEquipmentinfos.Where(x => x.Equipmentid == eqpId).FirstOrDefault();
                    var beforeJobId = string.IsNullOrEmpty(eqpInfo.Joborderid) ? "Idle" : eqpInfo.Joborderid;
                    var beforeCompositionId = string.IsNullOrEmpty(eqpInfo.Compositionid) ? "Idle" : eqpInfo.Compositionid;
                    var afterJobId = "Idle";
                    var afterCompositionId = "Idle";

                    if (eqpInfo != null)
                    {
                        var stepJobInfo = context.TbViewjobtrackings.Where(x => x.Jobid == value).FirstOrDefault();

                        if (stepJobInfo != null)
                        {
                            afterJobId = stepJobInfo.Joborderid;
                            afterCompositionId = stepJobInfo.Compositionid;
                        }

                        eqpInfo.Lastupdatetime = DateTime.Now;
                        eqpInfo.Lastupdateuserid = eqpInfo.Equipmentid;
                    }

                    if (afterJobId != "Idle")
                    {
                        Debug.WriteLine("[Equipment Job Order(include Step Job) Has been Changed][Equipment Id={0}][Before Job Order Id={1}][Before Step Job={2}][Now Job Oder Id={3}][Now Step Job={4}]", eqpId, beforeJobId, beforeCompositionId, afterJobId, afterCompositionId);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void SetCraneCurrentOperationMode(string eqpId, string value)
        {
            try
            {
                using (var context = new RcmsContext())
                {
                    var eqpInfo = context.TbEquipmentinfos.Where(x => x.Equipmentid == eqpId).FirstOrDefault();
                    var beforeMode = eqpInfo.Operationmode;
                    var afterMode = string.Empty;
                    if (eqpInfo != null)
                    {
                        switch (value)
                        {
                            case "1":
                                eqpInfo.Operationmode = afterMode = CommonConstant.EQPOPERATIONMODE_AUTO;
                                break;
                            case "2":
                                eqpInfo.Operationmode = afterMode = CommonConstant.EQPOPERATIONMODE_MANUAL;
                                break;
                            case "3":
                                eqpInfo.Operationmode = afterMode = CommonConstant.EQPOPERATIONMODE_TRANSITION;
                                break;
                            case "4":
                                eqpInfo.Operationmode = afterMode = CommonConstant.EQPOPERATIONMODE_MAINTENANCE;
                                break;
                        }

                        eqpInfo.Lastupdatetime = DateTime.Now;
                        eqpInfo.Lastupdateuserid = eqpInfo.Equipmentid;
                    }

                    if (!string.IsNullOrEmpty(afterMode))
                    {
                        Debug.WriteLine("[Equipment Operation Mode Has been Changed][Equipment Id={0}][Before={1}][Now={2}]", eqpId, beforeMode, afterMode);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}
