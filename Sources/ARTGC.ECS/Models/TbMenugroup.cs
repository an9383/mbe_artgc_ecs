using System;
using System.Collections.Generic;

namespace ARTGC.Models;

/// <summary>
/// MENU Group Definition
/// </summary>
public partial class TbMenugroup
{
    /// <summary>
    /// Menu Group ID
    /// </summary>
    public string Menugroupid { get; set; } = null!;

    /// <summary>
    /// Menu Group Name (Description)
    /// </summary>
    public string? Menugroupname { get; set; }

    /// <summary>
    /// Menu Group Type (User Define)
    /// </summary>
    public string? Menugrouptype { get; set; }

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
