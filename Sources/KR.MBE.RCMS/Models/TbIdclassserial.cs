using System;
using System.Collections.Generic;

namespace KR.MBE.RCMS.Models;

/// <summary>
/// ID Class Sequence Management
/// </summary>
public partial class TbIdclassserial
{
    /// <summary>
    /// ID Class ID
    /// </summary>
    public string Idclassid { get; set; } = null!;

    /// <summary>
    /// Prefix Value
    /// </summary>
    public string Prefix { get; set; } = null!;

    /// <summary>
    /// Last Serial No (ID Class Last Sequence)
    /// </summary>
    public string? Lastserialno { get; set; }

    /// <summary>
    /// 생성자
    /// </summary>
    public string? Createuserid { get; set; }

    /// <summary>
    /// 생성일시
    /// </summary>
    public DateTime? Createtime { get; set; }
}
