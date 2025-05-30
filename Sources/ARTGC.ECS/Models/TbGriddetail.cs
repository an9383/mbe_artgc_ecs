using System;
using System.Collections.Generic;

namespace ARTGC.Models;

/// <summary>
/// 그리드상세정의
/// </summary>
public partial class TbGriddetail
{
    /// <summary>
    /// Grid ID
    /// </summary>
    public string Gridid { get; set; } = null!;

    /// <summary>
    /// Grid Column ID
    /// </summary>
    public string Gridcolumnid { get; set; } = null!;

    /// <summary>
    /// Grid Column 명칭
    /// </summary>
    public string? Gridcolumnname { get; set; }

    /// <summary>
    /// PK 여부
    /// </summary>
    public string? Primarykeyflag { get; set; }

    /// <summary>
    /// Nullable 여부
    /// </summary>
    public string? Notnullflag { get; set; }

    /// <summary>
    /// Columns Width Size
    /// </summary>
    public int? Gridcolumnsize { get; set; }

    /// <summary>
    /// Visible 처리 Flag
    /// </summary>
    public string? Visibleflag { get; set; }

    /// <summary>
    /// Edit 처리 Flag
    /// </summary>
    public string? Editflag { get; set; }

    /// <summary>
    /// Sort 처리 Flag
    /// </summary>
    public string? Sortflag { get; set; }

    /// <summary>
    /// Cell Type
    /// </summary>
    public string? Celltype { get; set; }

    /// <summary>
    /// 기본값
    /// </summary>
    public string? Defaultvalue { get; set; }

    /// <summary>
    /// Cell Combo EnumID
    /// </summary>
    public string? Comboenumid { get; set; }

    /// <summary>
    /// CellType 이 ComboBox인 경우
    /// </summary>
    public string? Combolist { get; set; }

    /// <summary>
    /// Position (Sort Index)
    /// </summary>
    public int? Position { get; set; }

    /// <summary>
    /// 가로정렬 [ Left | Right | Center | ... ]
    /// </summary>
    public string? Align { get; set; }

    /// <summary>
    /// Grid가 위치한 Class 명칭
    /// </summary>
    public string? Classname { get; set; }

    /// <summary>
    /// 비고
    /// </summary>
    public string? Description { get; set; }
}
