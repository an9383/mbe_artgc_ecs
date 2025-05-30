using System;
using System.Collections.Generic;

namespace ARTGC.Models;

/// <summary>
/// ID Definition
/// </summary>
public partial class TbIdclass
{
    /// <summary>
    /// ID Class ID
    /// </summary>
    public string Idclassid { get; set; } = null!;

    /// <summary>
    /// ID Class Name
    /// </summary>
    public string? Idclassname { get; set; }

    /// <summary>
    /// ID Length
    /// </summary>
    public int? Idlength { get; set; }

    /// <summary>
    /// ID Class Description 
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Valid State
    /// </summary>
    public string? Validstate { get; set; }

    /// <summary>
    /// 생성자
    /// </summary>
    public string? Createuserid { get; set; }

    /// <summary>
    /// 생성일시
    /// </summary>
    public DateTime? Createtime { get; set; }

    /// <summary>
    /// 마지막수정자
    /// </summary>
    public string? Lastupdateuserid { get; set; }

    /// <summary>
    /// 마지막수정일시
    /// </summary>
    public DateTime? Lastupdatetime { get; set; }
}
