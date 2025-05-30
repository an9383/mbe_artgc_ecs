using System;
using System.Collections.Generic;

namespace ARTGC.Models_scaffold;

/// <summary>
/// System Error Definition
/// </summary>
public partial class TbSystemexception
{
    /// <summary>
    /// Exception ID
    /// </summary>
    public string Exceptionid { get; set; } = null!;

    /// <summary>
    /// Locale ID
    /// </summary>
    public string Localeid { get; set; } = null!;

    /// <summary>
    /// Exception 표시
    /// </summary>
    public string? Exceptionmessage { get; set; }

    /// <summary>
    /// Exception 설명
    /// </summary>
    public string? Description { get; set; }
}
