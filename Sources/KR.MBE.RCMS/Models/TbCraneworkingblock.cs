using System;
using System.Collections.Generic;

namespace KR.MBE.RCMS.Models;

/// <summary>
/// 크레인의 작업 Block 설정 (동일 Block Group 내 Block만 가능)
/// </summary>
public partial class TbCraneworkingblock
{
    /// <summary>
    /// 크레인ID
    /// </summary>
    public string Equipmentid { get; set; } = null!;

    /// <summary>
    /// Block ID
    /// </summary>
    public string Blockid { get; set; } = null!;

    /// <summary>
    /// 마지막수정일시
    /// </summary>
    public DateTime? Lastupdatetime { get; set; }

    /// <summary>
    /// 마지막수정자
    /// </summary>
    public string? Lastupdateuserid { get; set; }
}
