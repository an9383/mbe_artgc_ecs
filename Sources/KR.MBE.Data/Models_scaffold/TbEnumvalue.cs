using System;
using System.Collections.Generic;

namespace ARTGC.Models_scaffold;

/// <summary>
/// Enumeration Value Definition (a value of a type)
/// </summary>
public partial class TbEnumvalue
{
    /// <summary>
    /// Enumeration ID (A type name to categonize)
    /// </summary>
    public string Enumid { get; set; } = null!;

    /// <summary>
    /// Enumeration Value
    /// </summary>
    public string Enumvalue { get; set; } = null!;

    /// <summary>
    /// Enumeration Value Description (a name of Value)
    /// </summary>
    public string? Enumvaluename { get; set; }

    /// <summary>
    /// default flag [ Yes | No ]
    /// </summary>
    public string? Defaultflag { get; set; }

    /// <summary>
    /// Position (Sort Index)
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
