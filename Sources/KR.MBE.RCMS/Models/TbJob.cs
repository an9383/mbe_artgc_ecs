using System;
using System.Collections.Generic;

namespace KR.MBE.RCMS.Models;

/// <summary>
/// TOS에서 지시 내려지는 Job 정의
/// </summary>
public partial class TbJob
{
    /// <summary>
    /// Job ID
    /// </summary>
    public string Jobid { get; set; } = null!;

    /// <summary>
    /// Job 명
    /// </summary>
    public string? Jobname { get; set; }

    /// <summary>
    /// 비고
    /// </summary>
    public string? Description { get; set; }

    public string Commonyn { get; set; } = null!;

    public string Usechassisupdate { get; set; } = null!;

    public string Usercs { get; set; } = null!;

    /// <summary>
    /// 마지막수정일시
    /// </summary>
    public DateTime? Lastupdatetime { get; set; }

    /// <summary>
    /// 마지막수정자
    /// </summary>
    public string? Lastupdateuserid { get; set; }
}
