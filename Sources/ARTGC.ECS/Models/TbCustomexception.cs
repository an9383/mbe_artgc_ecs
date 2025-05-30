using System;
using System.Collections.Generic;

namespace ARTGC.Models;

/// <summary>
/// 사용자메시지
/// </summary>
public partial class TbCustomexception
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
    /// Exception 구분 [ Info | Warning | Error | … ]
    /// </summary>
    public string Exceptiontype { get; set; } = null!;

    /// <summary>
    /// Exception 설명
    /// </summary>
    public string? Description { get; set; }
}
