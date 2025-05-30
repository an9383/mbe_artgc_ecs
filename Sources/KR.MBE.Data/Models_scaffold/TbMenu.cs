using System;
using System.Collections.Generic;

namespace ARTGC.Models_scaffold;

/// <summary>
/// Menu Definition
/// </summary>
public partial class TbMenu
{
    /// <summary>
    /// Menu ID
    /// </summary>
    public string Menuid { get; set; } = null!;

    /// <summary>
    /// Menu Group ID
    /// </summary>
    public string? Menugroupid { get; set; }

    /// <summary>
    /// Menu Name (Description)
    /// </summary>
    public string? Menuname { get; set; }

    /// <summary>
    /// 활성상태 [ Active | Inactive ]
    /// </summary>
    public string? Activestate { get; set; }

    /// <summary>
    /// Menu Class Name
    /// </summary>
    public string? Classname { get; set; }

    /// <summary>
    /// Menu Type [ Line | Menu | … ]
    /// </summary>
    public string? Menutype { get; set; }

    /// <summary>
    /// Source Type (User Define)
    /// </summary>
    public string? Sourcetype { get; set; }

    /// <summary>
    /// Position (Sort Index)
    /// </summary>
    public int? Position { get; set; }

    /// <summary>
    /// 마지막수정일시
    /// </summary>
    public DateTime? Lastupdatetime { get; set; }

    /// <summary>
    /// 마지막수정자
    /// </summary>
    public string? Lastupdateuserid { get; set; }
}
