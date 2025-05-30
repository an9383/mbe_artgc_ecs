using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Middleware.JsonRPC.Data
{
    //========================================================================
    //= Request Body Data Class (Begin)

    public class AycLocation
    {
        public string locTp { get; set; }
        public string loc1 { get; set; }
        public string loc2 { get; set; }
        public string loc3 { get; set; }
        public string loc4 { get; set; }
    }

    public class AycRmkLocation
    {
        public string locTp { get; set; }
        public string loc1 { get; set; }
        public string loc2 { get; set; }
        public string loc3 { get; set; }
        public string loc4 { get; set; }
        public string rmk { get; set; }
    }

    public class AycHeader
    {
        public string msgId { get; set; }
        public string evntTp { get; set; }
        public string timeStamp { get; set; }
        public string remark { get; set; }

    }

    public class AycBody_sendAycJob
    {
        public string eqId { get; set; }
        public string jobId { get; set; }
        public string jobTp { get; set; }
        public string cntrNo { get; set; }
        public string cntrLen { get; set; }
        public string cntrWgt { get; set; }
        public string cntrHgt { get; set; }
        public string cntrIso { get; set; }
        public string cntrCmdt { get; set; }
        public string cntrTp { get; set; }
        public string isFull { get; set; }
        public string vehicleId { get; set; }
        public string chssPos { get; set; }
        public string doorDir { get; set; }
        public AycLocation pickupLoc { get; set; }
        public string pickupLndTp { get; set; }
        public string pickupClrn { get; set; }
        public AycRmkLocation setdownLoc { get; set; }
        public string setdownLndTp { get; set; }
        public string setdownClrn { get; set; }
    }

    public class AycBody_sendAbortJob
    {
        public string eqId { get; set; }
        public string jobId { get; set; }

    }

    public class AycBody_sendMoveJob
    {
        public string eqId { get; set; }
        public string jobId { get; set; }
        public AycRmkLocation wrkLoc { get; set; }
    }

    public class AycBody_sendClearance
    {
        public string eqId { get; set; }
        public string jobId { get; set; }
        public string lndTpChassis { get; set; }
        public string clearanceChassis { get; set; }
        public AycRmkLocation vehicleLoc { get; set; }
    }

    public class AycBody_sendChangeTarget
    {
        public string eqId { get; set; }
        public string jobId { get; set; }
        public string vehicleId { get; set; }
        public AycLocation vehicleLoc { get; set; }
    }

    public class AycBody_accept
    {
        public string eqId { get; set; }
        public string jobId { get; set; }
    }

    public class AycBody_pickupDone
    {
        public string eqId { get; set; }
        public string jobId { get; set; }
        public string cntrWgt { get; set; }
        public AycLocation wrkLoc { get; set; }
    }

    public class AycBody_jobDone
    {
        public string eqId { get; set; }
        public string jobId { get; set; }
        public string cntrWgt { get; set; }
        public AycLocation wrkLoc { get; set; }
    }

    public class AycBody_abortStatus
    {
        public string eqId { get; set; }
        public string jobId { get; set; }
        public string result { get; set; }
        public string errCd { get; set; }
    }

    public class AycBody_detectVehicle
    {
        public string eqId { get; set; }
        public string jobId { get; set; }
        public string vehicleId { get; set; }
        public AycLocation vehiclekLoc { get; set; }
    }

    public class AycBody_requestCraneStatus
    {
        public string eqId { get; set; }
    }

    public class AycBody_aycStatus
    {
        public string eqId { get; set; }
        public string oprMd { get; set; }
        public string autoSts { get; set; }
        public string crnCtrl { get; set; }
        public string wrkSts { get; set; }
        public string remoteMd { get; set; }
        public string remoteId { get; set; }
        public string remoteUsrId { get; set; }
        public string jobId { get; set; }
        public string eqSts { get; set; }
    }

    public class AycBody_aycPosition
    {
        public string eqId { get; set; }
        public AycLocation wrkLoc { get; set; }
    }

    public class AycBody_aycSpreader
    {
        public string eqId { get; set; }
        public string sprdSz { get; set; }
        public string twistSts { get; set; }
    }


    public class AycBody_aycConnection
    {
        public string eqId { get; set; }
        public string connSts { get; set; }
    }

    public class AycBody_reject
    {
        public string eqId { get; set; }
        public string jobId { get; set; }
        public string errCd { get; set; }
    }


    //=================================================================
    //= AYC Message Definition - { Server Mode : Recieving Data )

    // AYC - sendAycJob
    public class AycMsg_sendAycJob
    {
        public AycHeader head { get; set; }
        public AycBody_sendAycJob body { get; set; }
    }


    // AYC - sendAbortJob
    public class AycMsg_sendAbortJob
    {
        public AycHeader head { get; set; }
        public AycBody_sendAbortJob body { get; set; }
    }


    // AYC - sendMoveJob
    public class AycMsg_sendMoveJob
    {
        public AycHeader head { get; set; }
        public AycBody_sendMoveJob body { get; set; }
    }


    // AYC - sendClearance
    public class AycMsg_sendClearance
    {
        public AycHeader head { get; set; }
        public AycBody_sendClearance body { get; set; }
    }

    // AYC - sendChangeTarget
    public class AycMsg_sendChangeTarget
    {
        public AycHeader head { get; set; }
        public AycBody_sendChangeTarget body { get; set; }
    }

    // AYC - requestCraneStatus
    public class AycMsg_requestCraneStatus
    {
        public AycHeader head { get; set; }
        public AycBody_requestCraneStatus body { get; set; }
    }


    //=================================================================
    //= AYC Message Definition - { Client Mode : Sending Data )

    // AYC - accept
    public class AycMsg_accept
    {
        public AycHeader head { get; set; }
        public AycBody_accept body { get; set; }
    }

    // AYC - pickupDone
    public class AycMsg_pickupDone
    {
        public AycHeader head { get; set; }
        public AycBody_pickupDone body { get; set; }
    }

    // AYC - jobDone
    public class AycMsg_jobDone
    {
        public AycHeader head { get; set; }
        public AycBody_jobDone body { get; set; }
    }

    // AYC - abortStatus
    public class AycMsg_abortStatus
    {
        public AycHeader head { get; set; }
        public AycBody_abortStatus body { get; set; }
    }

    // AYC - detectVehicle
    public class AycMsg_detectVehicle
    {
        public AycHeader head { get; set; }
        public AycBody_detectVehicle body { get; set; }
    }

    // AYC - aycStatus
    public class AycMsg_aycStatus
    {
        public AycHeader head { get; set; }
        public AycBody_aycStatus body { get; set; }
    }

    // AYC - aycPosition
    public class AycMsg_aycPosition
    {
        public AycHeader head { get; set; }
        public AycBody_aycPosition body { get; set; }
    }

    // AYC - aycSpreader
    public class AycMsg_aycSpreader
    {
        public AycHeader head { get; set; }
        public AycBody_aycSpreader body { get; set; }
    }

    // AYC - aycConnection
    public class AycMsg_aycConnection
    {
        public AycHeader head { get; set; }
        public AycBody_aycConnection body { get; set; }
    }

    // AYC - reject
    public class AycMsg_reject
    {
        public AycHeader head { get; set; }
        public AycBody_reject body { get; set; }
    }



}
