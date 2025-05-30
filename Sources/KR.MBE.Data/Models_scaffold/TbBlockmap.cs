using System;
using System.Collections.Generic;

namespace ARTGC.Models_scaffold;

/// <summary>
/// Block Group 정의
/// </summary>
public partial class TbBlockmap
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
    /// 마지막수정일시
    /// </summary>
    public DateTime? Lastupdatetime { get; set; }

    /// <summary>
    /// 마지막수정자
    /// </summary>
    public string? Lastupdateuserid { get; set; }
}
