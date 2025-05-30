using System;
using System.Collections.Generic;

namespace KR.MBE.RCMS.Models;

/// <summary>
/// Dispatch Event (Message) Definition
/// </summary>
public partial class TbDispatchevent
{
    /// <summary>
    /// 구동 Server Name
    /// </summary>
    public string Servername { get; set; } = null!;

    /// <summary>
    /// Event Name ( Message Name )
    /// </summary>
    public string Eventname { get; set; } = null!;

    /// <summary>
    /// Class Name
    /// </summary>
    public string? Classname { get; set; }

    /// <summary>
    /// Send To Subject Name ( ByPass 하는 경우 실제 수행하는 Server )
    /// </summary>
    public string? Targetsubjectname { get; set; }

    /// <summary>
    /// 수행하는 공장 (옵션)
    /// </summary>
    public string? Targetsite { get; set; }

    /// <summary>
    /// 로그 저장 여부 [ Yes | No ]
    /// </summary>
    public string? Logsaveflag { get; set; }
}
