using System;
using System.Collections.Generic;

namespace ARTGC.Models_scaffold;

/// <summary>
/// 통신 프로토콜 리스트
/// </summary>
public partial class TbDriverinfo
{
    /// <summary>
    /// Driver ID
    /// </summary>
    public string Driverid { get; set; } = null!;

    /// <summary>
    /// Driver Name
    /// </summary>
    public string? Drivername { get; set; }

    /// <summary>
    /// Protocol Name
    /// </summary>
    public string? Protocol { get; set; }
}
