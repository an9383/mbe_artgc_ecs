using System;
using System.Collections.Generic;

namespace ARTGC.Models_scaffold;

/// <summary>
/// TOS에서 지시 내려지는 Job 정의
/// </summary>
public partial class TbJobhistory
{
    /// <summary>
    /// Job ID
    /// </summary>
    public string Jobid { get; set; } = null!;

    /// <summary>
    /// TimeKey
    /// </summary>
    public string Timekey { get; set; } = null!;

    /// <summary>
    /// Job 명
    /// </summary>
    public string? Jobname { get; set; }

    /// <summary>
    /// 비고
    /// </summary>
    public string? Description { get; set; }

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
