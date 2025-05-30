using System;
using System.Collections.Generic;

namespace ARTGC.Models_scaffold;

/// <summary>
/// Block Group 정의 이력
/// </summary>
public partial class TbBlockmaphistory
{
    /// <summary>
    /// Block Group ID
    /// </summary>
    public string Blockgroupid { get; set; } = null!;

    /// <summary>
    /// Block ID
    /// </summary>
    public string Blockid { get; set; } = null!;

    /// <summary>
    /// TimeKey
    /// </summary>
    public string Timekey { get; set; } = null!;

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
