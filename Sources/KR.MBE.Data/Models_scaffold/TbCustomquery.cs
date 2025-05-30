using System;
using System.Collections.Generic;

namespace ARTGC.Models_scaffold;

/// <summary>
/// 사용자 Query
/// </summary>
public partial class TbCustomquery
{
    /// <summary>
    /// 쿼리ID
    /// </summary>
    public string Queryid { get; set; } = null!;

    /// <summary>
    /// 쿼리 Version
    /// </summary>
    public string Queryversion { get; set; } = null!;

    /// <summary>
    /// 수행할 쿼리
    /// </summary>
    public string? Querystring { get; set; }

    /// <summary>
    /// 쿼리구분
    /// </summary>
    public string Querytype { get; set; } = null!;

    /// <summary>
    /// 비고
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// 사용될 프로그램ID
    /// </summary>
    public string? Programid { get; set; }

    /// <summary>
    /// 사용할 Form ID
    /// </summary>
    public string? Formid { get; set; }

    /// <summary>
    /// 사용된 메뉴 ID
    /// </summary>
    public string? Menuid { get; set; }

    /// <summary>
    /// 생성일시
    /// </summary>
    public DateTime? Createtime { get; set; }

    /// <summary>
    /// 생성자
    /// </summary>
    public string? Createuserid { get; set; }
}
