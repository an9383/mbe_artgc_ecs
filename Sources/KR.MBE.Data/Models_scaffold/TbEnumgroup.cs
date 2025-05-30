using System;
using System.Collections.Generic;

namespace ARTGC.Models_scaffold;

/// <summary>
/// Enum Group 정의
/// </summary>
public partial class TbEnumgroup
{
    /// <summary>
    /// Enum Group ID
    /// </summary>
    public string Enumgroupid { get; set; } = null!;

    /// <summary>
    /// Enum Group 명
    /// </summary>
    public string? Enumgroupname { get; set; }

    /// <summary>
    /// 위치
    /// </summary>
    public int? Position { get; set; }

    /// <summary>
    /// 한글
    /// </summary>
    public string? Korean { get; set; }

    /// <summary>
    /// 영문
    /// </summary>
    public string? English { get; set; }

    /// <summary>
    /// 자국어1
    /// </summary>
    public string? Native1 { get; set; }

    /// <summary>
    /// 자국어2
    /// </summary>
    public string? Native2 { get; set; }
}
