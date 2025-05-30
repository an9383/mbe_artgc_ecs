using System;
using System.Diagnostics;
using System.Collections;
using KR.MBE.CommonLibrary;
using KR.MBE.Message;
using KR.MBE.Data;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using static KR.MBE.Data.Constant;
using System.ComponentModel;
using Apache.NMS.ActiveMQ.Commands;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using log4net;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Globalization;
using Apache.NMS;
using KR.MBE.Data.Models;
using KR.MBE.RCMS.Models;


namespace DataProcess
{
    public class EISManager
    {


        public StepJobManager stepjobMan = new StepJobManager();

        public EISManager()
        {

        }

        public void sendStepJobRequestMessage(TbViewjobtracking ViewStepJob)
        {
            string sBodyList = "";

            sBodyList += "			<JOBORDERID>" + ViewStepJob.Joborderid  + "</JOBORDERID>\r\n";
            sBodyList += "			<EQUIPMENTID>" + ViewStepJob.Equipmentid  + "</EQUIPMENTID>\r\n";
            sBodyList += "			<STEPJOBID>" + ViewStepJob.Stepjobid  + "</STEPJOBID>\r\n";
            sBodyList += "			<STEPJOBTYPE>" + ViewStepJob.Stepjobtype  + "</STEPJOBTYPE>\r\n";
            sBodyList += "			<STEPSEQUENCE>" + ViewStepJob.Stepsequence  + "</STEPSEQUENCE>\r\n";
            sBodyList += "			<COMPOSITIONID>" + ViewStepJob.Compositionid  + "</COMPOSITIONID>\r\n";
            sBodyList += "			<STEPJOBSTATUS>" + ViewStepJob.Stepjobstatus + "</STEPJOBSTATUS>\r\n";

            //TbViewjobparameter  dataInfo = new VIEWJOBPARAMETER();
            //dataInfo.setKeySITEID(viewStepJob.getKeySITEID());
            //dataInfo.setKeyJOBORDERID(viewStepJob.getKeyJOBORDERID());
            //dataInfo.setKeyCOMPOSITIONID(viewStepJob.getCOMPOSITIONID());  // MV-1000-Gantry2
            //List<VIEWJOBPARAMETER> listviewJobParameter = (List<VIEWJOBPARAMETER>)dataInfo.excuteDML(SqlConstant.DML_SELECTLIST, "ORDER BY ACTIONTYPE, PARAMETERLEVEL");
            string sDataList = "";

            using (var dbcontext = new RcmsContext())
            {
                List<TbViewjobparameter> listviewJobParameter = dbcontext.TbViewjobparameters
                                                                        .Where(e => e.Joborderid == ViewStepJob.Joborderid
                                                                                &&  e.Compositionid == ViewStepJob.Compositionid)
                                                                        .OrderBy(e => e.Parameterlevel)
                                                                        .ToList();

                if (listviewJobParameter.Count() > 0)            // MV (3)
                {
                    for (int i = 0; i < listviewJobParameter.Count(); i++)
                    {
                        TbViewjobparameter parameter = listviewJobParameter[i];

                        string? sDataType = "";
                        string? sAddress = "";
                        string? sStringLen = "";

                        if (!string.IsNullOrEmpty(parameter.Tagid))
                        {

                            TbTag? tagInfo = dbcontext.TbTags
                                                        .Where(e => e.Equipmentid == ViewStepJob.Equipmentid
                                                                && e.Tagid == parameter.Tagid)
                                                        .FirstOrDefault();

                            if(tagInfo != null)
                            {
                                sDataType = tagInfo.Datatype;
                                sAddress = tagInfo.Address;
                                sStringLen = tagInfo.Stringlen.ToString();
                            }

                        }


                        sDataList += "			<DATAINFO>\r\n";
                        sDataList += "				<ACTIONTYPE>" + parameter.Actiontype + "</ACTIONTYPE>\r\n";
                        sDataList += "				<PARAMETERID>" + parameter.Parameterid  + "</PARAMETERID>\r\n";
                        sDataList += "				<PARAMETERLEVEL>" + parameter.Parameterlevel.ToString() + "</PARAMETERLEVEL>\r\n";
                        sDataList += "				<TAGID>" + parameter.Tagid  + "</TAGID>\r\n";
                        sDataList += "				<DATATYPE>" + sDataType + "</DATATYPE>\r\n";
                        sDataList += "				<ADDRESS>" + sAddress + "</ADDRESS>\r\n";
                        sDataList += "				<STRINGLEN>" + sStringLen + "</STRINGLEN>\r\n";
                        sDataList += "				<TAGVALUE>" + parameter.Tagvalue  + "</TAGVALUE>\r\n";
                        sDataList += "				<DATAACTIONTYPE>" + parameter.Dataactiontype  + "</DATAACTIONTYPE>\r\n";
                        sDataList += "				<DATAPROCESSTYPE>" + parameter.Dataprocesstype  + "</DATAPROCESSTYPE>\r\n";
                        sDataList += "				<RECEIVEDID>" + parameter.Receivedid + "</RECEIVEDID>\r\n";
                        sDataList += "				<DATATARGET>" + parameter.Datatarget + "</DATATARGET>\r\n";
                        sDataList += "				<DATAFAILTARGET>" + parameter.Datafailtarget + "</DATAFAILTARGET>\r\n";
                        sDataList += "				<PARAMETERSTATUS>" + parameter.Parameterstatus + "</PARAMETERSTATUS>\r\n";
                        sDataList += "			</DATAINFO>\r\n";
                    }
                }
            }

            string sMessageName = "StepJobRequest";
            //string sMsg = "	<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n"
            //        + "	<message>\r\n"
            //        + "		<header>\r\n"
            //        + "			<messagename>" + sMessageName + "</messagename>\r\n"
            //        + "			<replysubject></replysubject>\r\n"
            //        + "			<sourcesubject></sourcesubject>\r\n"
            //        + "			<targetsubject></targetsubject>\r\n"
            //        + "			<transactionid></transactionid>\r\n"
            //        + "		</header>\r\n"
            //        + "		<body>\r\n"
            //        + sBodyList
            //        + "			<DATALIST>\r\n"
            //        + sDataList
            //        + "			</DATALIST>\r\n"
            //        + "		</body>\r\n"
            //        + "	</message>\r\n"
            //+ "";

            string sMsg = sBodyList
                    + "			<DATALIST>\r\n"
                    + sDataList
                    + "			</DATALIST>\r\n";

            //Log.InfoLog("Send EIS : " + EISTopic + "," + TargetSubjectName);
            Log.InfoLog(sMsg);

            // TO EIS
            MessageHandler.SendMessageAsync(sMessageName, sMsg);

            // TO ECS
            //MessageHandler.SendMessageAsyncEco(sMessageName, sMsg);

            //MESFrameProxy.getMessageService().send(TargetSubjectName, EISTopic, null, sMsg);
        }


        //sendStepJobRequestMessage












    }
}
