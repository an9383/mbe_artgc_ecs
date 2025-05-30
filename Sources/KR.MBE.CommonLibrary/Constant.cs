using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KR.MBE.CommonLibrary
{
    public class CommonConstant
    {
        /*********************
         * PLANT ID Information
         * PLANT Table 조회
         */
        //public const string SITEID = SiteConstant.getSiteID();

		// * ****************************** _IFSYSTEM ************************************
		public const string ISSYSTEM_TOS = "TOS";
	
		// * ****************************** _ROWSTATUS ************************************
		public const string ROWSTATUS_CREATE = "C";
		public const string ROWSTATUS_DELETE = "D";
		public const string ROWSTATUS_UPDATE = "U";
	

		// * ***************************** 버전 ************************************
		// * 기본 버젼 : 00001
		public const string  VERSION_DEFAULT						= "00001";
		// * ProductSpec 기본 Version : 00001
		public const string  PRODUCT_VERSION_DEFAULT				= "00001";

		// * ***************************** FLAG ************************************
		// * 플래그 - 예/아니오 택일 플래그 - 예(Yes) : Y
		public const string  FLAG_YN_YES							= "Y";
		public const string  FLAG_YESNO_YES						= "Yes";
		// * 플래그 - 예/아니오 택일 플래그 - 아니오(No) : N
		public const string  FLAG_YN_NO							= "N";
		public const string  FLAG_YESNO_NO						= "No";

		// * ****************************** Data 생성방법 ************************************
		public const string CREATEDATAMETHOD_FIXEDVALUE = "FixedValue";
		public const string CREATEDATAMETHOD_INRECEIVED = "InReceived";
		public const string CREATEDATAMETHOD_MAKEFUNCTION = "MakeFunction";
	
		// * ****************************** 입력구분 ************************************
		public const string INPUTTYPE_PC = "PC";
		public const string INPUTTYPE_MOBILE = "Mobile";
	
	
		// * ****************************** Bay Direction ************************************
		public const string BAYDIR_HORIZONTAL = "Horizontal";
		public const string BAYDIR_VERTICAL = "Vertical";

		// * ****************************** Bay Size ************************************
		public const string BAYSIZE_20ft = "20ft";
		public const string BAYSIZE_40ft = "40ft";
		public const string BAYSIZE_45ft = "45ft";
	
		// * ****************************** Container ISO Length ************************************
		public const string CONTAINERISO_LENGTH_20ft = "2";
		public const string CONTAINERISO_LENGTH_40ft = "4";
		public const string CONTAINERISO_LENGTH_45ft5 = "5";
		public const string CONTAINERISO_LENGTH_45ft = "L";
		public const string CONTAINERISO_LENGTH_48ft = "M";
	
		// * ****************************** Container ISO Height ************************************
		public const string CONTAINERISO_HEIGHT_86 = "2";
		public const string CONTAINERISO_HEIGHT_96 = "5";

		// * ****************************** Container Height Code ************************************
		public const string CONTAINER_HEIGHT_NONE = "0";
		public const string CONTAINER_HEIGHT_86 = "1";
		public const string CONTAINER_HEIGHT_96 = "2";
		public const string CONTAINER_HEIGHT_8 = "3";

		// * ****************************** Container Door Direction ************************************
		public const string CONTAINER_DOORDIR_LOWERBAY = "1";
		public const string CONTAINER_DOORDIR_HIGHERBAY = "2";

		// * ****************************** Spreader Size ************************************
		public const string SPREADER_SIZE_Undefined = "-1";
		public const string SPREADER_SIZE_NoSpreader = "0";
		public const string SPREADER_SIZE_20ft = "20";
		public const string SPREADER_SIZE_40ft = "40";
		public const string SPREADER_SIZE_45ft = "45";
		public const string SPREADER_SIZE_Moving = "59";

		// * ****************************** Row Direction ************************************
		public const string ROWDIR_TOLANDSIDE = "toLandSide";
		public const string ROWDIR_TOWATERSIDE = "toWaterSide";
	
		// * ****************************** Row Name Rule ************************************
		public const string ROWNAMERULE_NUMERIC10 = "Numeric10";
		public const string ROWNAMERULE_ALPHABETIC = "Alphabetic";
	
		// * ****************************** Job Status ************************************
		public const string JOBSTATUS_WAIT = "Wait";
		public const string JOBSTATUS_START = "Start";
		public const string JOBSTATUS_COMPLETED = "Completed";
		public const string JOBSTATUS_DELETED = "Deleted";
		public const string JOBSTATUS_REJECT = "Reject";
		public const string JOBSTATUS_HOLD = "Hold";    

		// * ****************************** Step Job Status ************************************
		public const string STEPJOBSTATUS_WAIT = "Wait";
		public const string STEPJOBSTATUS_STARTREQUEST = "StartRequest";
		public const string STEPJOBSTATUS_START = "Start";
		public const string STEPJOBSTATUS_COMPLETED = "Completed";

		// * ****************************** Step Job Opdateion Mode ************************************
		public const string STEPJOBOPERATIONMODE_AUTO = "Auto";
		public const string STEPJOBOPERATIONMODE_MANUAL = "Manual";

		// * ****************************** Step Job Type ************************************
		public const string STEPJOBTYPE_STARTEND = "StartEnd";
		public const string STEPJOBTYPE_EXECUTE = "Execute";

		// * ****************************** Create Data Type ************************************
		public const string CREATEDATATYPE_REALTIME = "RealTime";
		public const string CREATEDATATYPE_RECEIVEDTIME = "ReceivedTime";
	
		// * ****************************** Equipment Type ************************************
		public const string EQPTYPE_CRANE = "Crane";
		public const string EQPTYPE_STATION = "Station";
		public const string EQPTYPE_DEVICE = "Device";

		// * ****************************** Equipment DetailType ************************************
		public const string EQPDETAILTYPE_RTGC = "RTGC";
		public const string EQPDETAILTYPE_RMGC = "RMGC";
		public const string EQPDETAILTYPE_RCS = "RCS";
		public const string EQPDETAILTYPE_CCTV = "CCTV";

		// * ****************************** Equipment Status ************************************
		public const string EQUIPMENTSTATUS_IDLE = "Idle";
        public const string EQUIPMENTSTATUS_MOVE = "Move";
        public const string EQUIPMENTSTATUS_LOADING = "Loading";
        public const string EQUIPMENTSTATUS_LOADED = "Loaded";
        public const string EQUIPMENTSTATUS_LOADEDMOVE = "LoadedMove";
        public const string EQUIPMENTSTATUS_UNLOADING = "Unloading";
        public const string EQUIPMENTSTATUS_UNLOADED = "Unloaded";
        public const string EQUIPMENTSTATUS_HOLD = "Hold";
		public const string EQUIPMENTSTATUS_MAINT = "Maint";	// 유지

		// * ****************************** Equipment Comm Status ************************************
		public const string EQPCOMMSTATUS_ONLINE = "Online";
		public const string EQPCOMMSTATUS_OFFLINE = "Offline";
	
		// * ****************************** Equipment Operation Mode ************************************
		public const string EQPOPERATIONMODE_AUTO = "Auto";
		public const string EQPOPERATIONMODE_MANUAL = "Manual";
		public const string EQPOPERATIONMODE_TRANSITION = "Transition";		// 이행
		public const string EQPOPERATIONMODE_MAINTENANCE = "Maintenance";

		// * ****************************** Create Data Method ************************************
		public const string F_GETFROMGANTRYPOSITION = "getFromGantryPosition";
		public const string F_GETFROMTROLLEYPOSITION = "getFromTrolleyPosition";
		public const string F_GETFROMHOISTPOSITION = "getFromHoistPosition";

		public const string F_GETTOGANTRYPOSITION = "getToGantryPosition";
		public const string F_GETTOTROLLEYPOSITION = "getToTrolleyPosition";
		public const string F_GETTOHOISTPOSITION = "getToHoistPosition";
	
		public const string F_GETINVENTORYLIST = "getInventoryList";

		public const string F_GETFROMSTACKINGROW01 = "getFromStackingRow01";
		public const string F_GETFROMSTACKINGROW02 = "getFromStackingRow02";
		public const string F_GETFROMSTACKINGROW03 = "getFromStackingRow03";
		public const string F_GETFROMSTACKINGROW04 = "getFromStackingRow04";
		public const string F_GETFROMSTACKINGROW05 = "getFromStackingRow05";
		public const string F_GETFROMSTACKINGROW06 = "getFromStackingRow06";
		public const string F_GETFROMSTACKINGROW07 = "getFromStackingRow07";
		public const string F_GETFROMSTACKINGROW08 = "getFromStackingRow08";
		public const string F_GETFROMSTACKINGROW09 = "getFromStackingRow09";
		public const string F_GETFROMSTACKINGROW10 = "getFromStackingRow10";
	
		public const string F_GETTOSTACKINGROW01 = "getToStackingRow01";
		public const string F_GETTOSTACKINGROW02 = "getToStackingRow02";
		public const string F_GETTOSTACKINGROW03 = "getToStackingRow03";
		public const string F_GETTOSTACKINGROW04 = "getToStackingRow04";
		public const string F_GETTOSTACKINGROW05 = "getToStackingRow05";
		public const string F_GETTOSTACKINGROW06 = "getToStackingRow06";
		public const string F_GETTOSTACKINGROW07 = "getToStackingRow07";
		public const string F_GETTOSTACKINGROW08 = "getToStackingRow08";
		public const string F_GETTOSTACKINGROW09 = "getToStackingRow09";
		public const string F_GETTOSTACKINGROW10 = "getToStackingRow10";
	
		public const string F_GETRCS = "getRCS";
		public const string F_GETCCTVLIST = "getCCTVList";
		public const string F_GETTWISTLOCKCCTVLIST = "getTwistLockCCTVList";
		public const string F_GETTWISTLOCKCCTVHTTPLIST = "getTwistLockCCTVHttpList";
		//getTwistLockCCTVHttpList

		//2023-12-05 추가
		public const string F_GETSPREADERSAFEHEIGHT = "getSpreaderSafeHeight";
		public const string F_GETSPREADERROW = "getSpreaderRow";
		public const string F_GETSPREADERSIZE = "getSpreaderSize";
		public const string F_GETSPREADERROWPOSITION = "getSpreaderRowPosition";
		public const string F_CLEARANCEUPDATE = "getClearanceUpdate";
		public const string F_GETSTEPJOBID = "getStepJobID";


		public const string F_GETSTEPJOBSHORTNAME = "getStepJobShortName";
        // * ****************************** CCTV Action Definition ************************************
        public const string CCTVACTION_SPREADERTWISTLOCK = "SpreaderTwistLock";
	
		// * ****************************** Interface ActionType ************************************
		public const string IFACTIONTYPE_NONE = "None";
		public const string IFACTIONTYPE_START = "Start";
		public const string IFACTIONTYPE_END = "End";
		public const string IFACTIONTYPE_BOTH = "Both";
		public const string IFACTIONTYPE_EXECUTE = "Execute";
		public const string IFACTIONTYPE_TIMEOUT = "TimeOut";
	
		// * ****************************** Inventory InOutFlag ************************************
		public const string INVENTORY_INOUTFLAG_I = "I";
		public const string INVENTORY_INOUTFLAG_O = "O";
	
	
		// * ****************************** TOS Interface MessageName ************************************
		public const string IF_TOS_JOBACCEPT = "JobAccept";
		public const string IF_TOS_JOBREJECT = "JobReject";
		public const string IF_TOS_JOBCOMPLETED = "JobCompleted";
		public const string IF_TOS_JOBSTART = "JobStart";
		public const string IF_TOS_REPORT = "TOSReport";

		// * ****************************** Interface FunctionName ************************************
		public const string IFFUNCTIONNAME_NONE = "None";
		public const string IFFUNCTIONNAME_JOBCOMPLETEITV = "JobCompleteITV";
		public const string IFFUNCTIONNAME_WAITVEHICLETIMEOUT = "WaitVehicleTimeOut";
		public const string IFFUNCTIONNAME_JOBSTART = "JobStart";
		public const string IFFUNCTIONNAME_TOSREPORT = "TOSReport";
		public const string IFFUNCTIONNAME_CHASSISUPDATE = "ChassisUpdate";
	
		// * ****************************** PARAMETERIDS ************************************
		// 특별한 Parameter ID 의 경우 추가
		public const string PARAMETERTYPE_NORMAL = "Normal";
		public const string PARAMETERTYPE_RCS = "RCS";

	
		// * ****************************** ECS Constant ************************************
		// 특별한 Parameter ID 의 경우 추가
		public const string ECS_WAITINGRCSID = "WaitingRCSID";

		// * ****************************** ECSPolicy EnumValue ************************************
		// 특별한 Parameter ID 의 경우 추가
		public const string ENUMID_ECSPOLICY = "ECSPolicy";
		public const string ENUMID_TIMEOUTLIMIT = "TimeOutLimit";
		public const string ENUMVALUE_JOBCOMPLETEDINVENTORYFLAG = "JobCompletedInventoryFlag";
		public const string ENUMVALUE_TIMEOUTLIMIT_WAITINGTOVEHICLE = "WaitingToVehicle";

	

		// * ****************************** TOS Send JobStatus ************************************
		// 특별한 Parameter ID 의 경우 추가
		public const string TOSJOBSTATUS_ACTIVE = "A";
		public const string TOSJOBSTATUS_INACTIVE = "Q";
		public const string TOSJOBSTATUS_PROCESSING = "P";
		public const string TOSJOBSTATUS_BYPASS = "B";
	
		// * ****************************** TOS Send Topic ************************************
		// 특별한 Parameter ID 의 경우 추가
		public const string TOSTOPIC_JOB_CREATE = "JOB_CREATE";	// Queue Active 시
		public const string TOSTOPIC_JOB_DEL = "JOB_DEL";		// Queue Deactive시, STS 해제 시
		public const string TOSTOPIC_JOB_CHG = "JOB_CHG";		// JobDetailInfo 및 Yard Crane 할당/변경/해제시
		public const string TOSTOPIC_MCN_FTCH = "MCN_FTCH";		// ITV 할당 또는 해제
		public const string TOSTOPIC_MCN_STDN = "MCN_STDN";		// Job 완료시
	

    }
}
