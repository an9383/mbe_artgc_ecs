using System;
using System.Collections.Generic;

namespace KR.MBE.RCMS.Models;

/// <summary>
/// Tier 정의
/// </summary>
public partial class TbTierhistory
{
    /// <summary>
    /// Block ID
    /// </summary>
    public string Blockid { get; set; } = null!;

    /// <summary>
    /// Bay ID
    /// </summary>
    public string Bayid { get; set; } = null!;

    /// <summary>
    /// Row ID
    /// </summary>
    public string Rowid { get; set; } = null!;

    /// <summary>
    /// Tier ID
    /// </summary>
    public string Tierid { get; set; } = null!;

    /// <summary>
    /// TimeKey
    /// </summary>
    public string Timekey { get; set; } = null!;

    /// <summary>
    /// Tier 명
    /// </summary>
    public string? Tiername { get; set; }

    /// <summary>
    /// Tier 순서
    /// </summary>
    public int? Tierindex { get; set; }

    /// <summary>
    /// 사용여부
    /// </summary>
    public string? Useflag { get; set; }

    /// <summary>
    /// Hoist Position (바닥기준, 8ft 6inch 기준)
    /// </summary>
    public int? Hoistposition { get; set; }

    /// <summary>
    /// 상대좌표 X
    /// </summary>
    public int? Posx { get; set; }

    /// <summary>
    /// 상태좌표 Y
    /// </summary>
    public int? Posy { get; set; }

    /// <summary>
    /// 상태좌표 Z
    /// </summary>
    public int? Posz { get; set; }

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
