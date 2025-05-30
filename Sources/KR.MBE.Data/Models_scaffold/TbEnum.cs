using System;
using System.Collections.Generic;

namespace ARTGC.Models_scaffold;

/// <summary>
/// Enumeration 정의
/// </summary>
public partial class TbEnum
{
    /// <summary>
    /// Enumeration ID (A type name to categonize)
    /// </summary>
    public string Enumid { get; set; } = null!;

    /// <summary>
    /// Enumeration Name (A description)
    /// </summary>
    public string? Enumname { get; set; }

    /// <summary>
    /// An access type.
    /// </summary>
    public string? Accesstype { get; set; }

    /// <summary>
    /// Enumeration Group
    /// </summary>
    public string? Enumgroup { get; set; }

    /// <summary>
    /// Constant Flag [ Yes | No ]
    /// </summary>
    public string? Constantflag { get; set; }

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
