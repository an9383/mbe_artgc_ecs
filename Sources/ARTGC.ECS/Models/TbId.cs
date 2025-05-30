using System;
using System.Collections.Generic;

namespace ARTGC.Models;

/// <summary>
/// ID Create Rule Detail Definition
/// </summary>
public partial class TbId
{
    /// <summary>
    /// ID Class ID
    /// </summary>
    public string Idclassid { get; set; } = null!;

    /// <summary>
    /// Sequence
    /// </summary>
    public int Sequence { get; set; }

    /// <summary>
    /// ID Definition ID
    /// </summary>
    public string Iddefid { get; set; } = null!;

    /// <summary>
    /// ID Definition Name
    /// </summary>
    public string? Iddefname { get; set; }

    /// <summary>
    /// ID Definition Description
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// ID Definition Category
    /// </summary>
    public string? Iddefcategory { get; set; }

    /// <summary>
    /// ID Definition Type
    /// </summary>
    public string? Iddeftype { get; set; }

    /// <summary>
    /// Length
    /// </summary>
    public int? Length { get; set; }

    /// <summary>
    /// String Format
    /// </summary>
    public string? Format { get; set; }

    /// <summary>
    /// ID 제외문자 (콤마로 구분)
    /// </summary>
    public string? Exceptionchars { get; set; }

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
