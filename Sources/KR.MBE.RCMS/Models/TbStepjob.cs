using System;
using System.Collections.Generic;

namespace KR.MBE.RCMS.Models;

/// <summary>
/// Job을 수행하기 위한 Step Job 정의
/// </summary>
public partial class TbStepjob
{
    /// <summary>
    /// Step Job ID
    /// </summary>
    public string Stepjobid { get; set; } = null!;

    /// <summary>
    /// Step Job 명
    /// </summary>
    public string? Stepjobname { get; set; }

    /// <summary>
    /// Step Job 구분 [ StartEnd | Execute ]
    /// </summary>
    public string? Stepjobtype { get; set; }

    public int? Orderindex { get; set; }

    public string? Shortname { get; set; }

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
}
