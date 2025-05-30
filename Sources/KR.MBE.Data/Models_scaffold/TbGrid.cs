using System;
using System.Collections.Generic;

namespace ARTGC.Models_scaffold;

/// <summary>
/// 그리드정의
/// </summary>
public partial class TbGrid
{
    /// <summary>
    /// Grid ID
    /// </summary>
    public string Gridid { get; set; } = null!;

    /// <summary>
    /// Grid 명칭
    /// </summary>
    public string? Gridname { get; set; }

    /// <summary>
    /// Check Box 포함여부
    /// </summary>
    public string? Checkbox { get; set; }

    /// <summary>
    /// RowStatus 포함여부
    /// </summary>
    public string? Rowstatus { get; set; }

    /// <summary>
    /// Header Row Size
    /// </summary>
    public int? Headerrowsize { get; set; }

    /// <summary>
    /// Header Column Size
    /// </summary>
    public int? Headercolumnsize { get; set; }

    /// <summary>
    /// Position (Sort Index)
    /// </summary>
    public int? Position { get; set; }

    /// <summary>
    /// Grid가 위치한 Class 명칭
    /// </summary>
    public string? Classname { get; set; }

    /// <summary>
    /// 비고
    /// </summary>
    public string? Description { get; set; }
}
