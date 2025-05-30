using System;
using System.Collections.Generic;

namespace ARTGC.Models_scaffold;

/// <summary>
/// 크레인, RCS 등 관리가 필요한 장비
/// </summary>
public partial class TbEquipmenthistory
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
    /// 장비명
    /// </summary>
    public string? Equipmentname { get; set; }

    /// <summary>
    /// 장비구분 [ Crane | Station | Device | … ]
    /// </summary>
    public string? Equipmenttype { get; set; }

    /// <summary>
    /// 장비상세구분 [ RTGC | RMGC | RCS | CCTV |  … ]
    /// </summary>
    public string? Equipmentdetailtype { get; set; }

    /// <summary>
    /// 상위 장비ID
    /// </summary>
    public string? Superequipmentid { get; set; }

    /// <summary>
    /// 사용여부
    /// </summary>
    public string? Useflag { get; set; }

    /// <summary>
    /// Auto 여부
    /// </summary>
    public string? Autoflag { get; set; }

    /// <summary>
    /// 인터페이스 모드 [ None | TAG | MSG | … ]
    /// </summary>
    public string? Ifmode { get; set; }

    /// <summary>
    /// Local IP Address
    /// </summary>
    public string? Ipaddress { get; set; }

    /// <summary>
    /// Local Port
    /// </summary>
    public string? Port { get; set; }

    /// <summary>
    /// Client ID
    /// </summary>
    public string? Clientid { get; set; }

    /// <summary>
    /// 최대 TrolleyPosition
    /// </summary>
    public int? Maxtrolleyposition { get; set; }

    /// <summary>
    /// 최대 HoistPosition
    /// </summary>
    public int? Maxhoistposition { get; set; }

    public string? Spreaderdefaultrow { get; set; }

    public int? Spreadersafeheight { get; set; }

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
