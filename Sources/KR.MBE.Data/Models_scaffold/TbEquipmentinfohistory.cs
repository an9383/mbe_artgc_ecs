using System;
using System.Collections.Generic;

namespace ARTGC.Models_scaffold;

/// <summary>
/// 장비 (크레인/RCS) Current 상태 정보 이력
/// </summary>
public partial class TbEquipmentinfohistory
{
    /// <summary>
    /// 장비ID
    /// </summary>
    public string Equipmentid { get; set; } = null!;

    /// <summary>
    /// TimeKey
    /// </summary>
    public string Timekey { get; set; } = null!;

    /// <summary>
    /// 상태 [ Idle |  Run | Hold ]
    /// </summary>
    public string? Equipmentstatus { get; set; }

    /// <summary>
    /// 통신상태 [ Online | Offline ]
    /// </summary>
    public string? Commstatus { get; set; }

    /// <summary>
    /// 동작모드 [ Auto | Manual ] 
    /// </summary>
    public string? Operationmode { get; set; }

    /// <summary>
    /// ARTG Status
    /// </summary>
    public string? Automaticstatus { get; set; }

    /// <summary>
    /// Container Pickup Flag
    /// </summary>
    public string? Pickupflag { get; set; }

    /// <summary>
    /// Vehicle Arrived Flag
    /// </summary>
    public string? Arrivedvehicleflag { get; set; }

    /// <summary>
    /// Arrived Vehicle ID
    /// </summary>
    public string? Arrivedvehicleid { get; set; }

    /// <summary>
    /// 현재 진행중인 JOB Order ID
    /// </summary>
    public string? Joborderid { get; set; }

    /// <summary>
    /// 현재 진행중인 Step Job 의 CompositionID
    /// </summary>
    public string? Compositionid { get; set; }

    /// <summary>
    /// Crane 장비 현재 Block 위치
    /// </summary>
    public string? Blockid { get; set; }

    /// <summary>
    /// Crane 장비 현재 Bay 위치
    /// </summary>
    public string? Bayid { get; set; }

    /// <summary>
    /// 마지막수정일시
    /// </summary>
    public DateTime? Lastupdatetime { get; set; }

    /// <summary>
    /// 마지막수정자
    /// </summary>
    public string? Lastupdateuserid { get; set; }

    /// <summary>
    /// Event Name
    /// </summary>
    public string? Eventname { get; set; }

    /// <summary>
    /// Event Type
    /// </summary>
    public string? Eventtype { get; set; }

    /// <summary>
    /// Event Time
    /// </summary>
    public DateTime? Eventtime { get; set; }

    /// <summary>
    /// Event User
    /// </summary>
    public string? Eventuserid { get; set; }

    /// <summary>
    /// Event Description
    /// </summary>
    public string? Eventcomment { get; set; }
}
