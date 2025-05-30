using System;
using System.Collections.Generic;

namespace KR.MBE.RCMS.Models;

/// <summary>
/// Monitoring Tag Mapping
/// </summary>
public partial class TbMonitoringtagmap
{
    /// <summary>
    /// Equipment ID
    /// </summary>
    public string Equipmentid { get; set; } = null!;

    /// <summary>
    /// Form ID
    /// </summary>
    public string Formid { get; set; } = null!;

    /// <summary>
    /// Control ID
    /// </summary>
    public string Controlid { get; set; } = null!;

    /// <summary>
    /// Control 명칭
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// TAGID
    /// </summary>
    public string? Tagid { get; set; }

    /// <summary>
    /// 사용여부
    /// </summary>
    public string? Useflag { get; set; }

    /// <summary>
    /// 마지막수정일시
    /// </summary>
    public DateTime? Lastupdatetime { get; set; }

    /// <summary>
    /// 마지막수정자
    /// </summary>
    public string? Lastupdateuserid { get; set; }
}
