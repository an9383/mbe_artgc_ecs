using System;
using System.Collections.Generic;

namespace ARTGC.Models;

/// <summary>
/// Bay 정의
/// </summary>
public partial class TbBayhistory
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
    /// TimeKey
    /// </summary>
    public string Timekey { get; set; } = null!;

    /// <summary>
    /// Bay 명
    /// </summary>
    public string? Bayname { get; set; }

    /// <summary>
    /// Bay Size [ 20ft | 40ft | 45ft | ... ]
    /// </summary>
    public string? Baysize { get; set; }

    /// <summary>
    /// Bay 순서
    /// </summary>
    public int? Bayindex { get; set; }

    /// <summary>
    /// 사용여부
    /// </summary>
    public string? Useflag { get; set; }

    /// <summary>
    /// Gantry Position
    /// </summary>
    public int? Gantryposition { get; set; }

    /// <summary>
    /// 상대좌표 X
    /// </summary>
    public int? Posx { get; set; }

    /// <summary>
    /// 상태좌표 Y
    /// </summary>
    public int? Posy { get; set; }

    /// <summary>
    /// Bay Width (mm)
    /// </summary>
    public int? Baywidth { get; set; }

    /// <summary>
    /// Bay Height (mm)
    /// </summary>
    public int? Bayheight { get; set; }

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
