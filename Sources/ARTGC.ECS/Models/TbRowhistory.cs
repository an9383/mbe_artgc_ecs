using System;
using System.Collections.Generic;

namespace ARTGC.Models;

/// <summary>
/// Row 정의
/// </summary>
public partial class TbRowhistory
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
    /// TimeKey
    /// </summary>
    public string Timekey { get; set; } = null!;

    /// <summary>
    /// Row 명
    /// </summary>
    public string? Rowname { get; set; }

    /// <summary>
    /// Row 순서
    /// </summary>
    public int? Rowindex { get; set; }

    /// <summary>
    /// 사용여부
    /// </summary>
    public string? Useflag { get; set; }

    /// <summary>
    /// 차량 정차 여부
    /// </summary>
    public string? Workinglaneflag { get; set; }

    /// <summary>
    /// Trolley Position
    /// </summary>
    public int? Trolleyposition { get; set; }

    /// <summary>
    /// 상대좌표 X
    /// </summary>
    public int? Posx { get; set; }

    /// <summary>
    /// 상태좌표 Y
    /// </summary>
    public int? Posy { get; set; }

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
