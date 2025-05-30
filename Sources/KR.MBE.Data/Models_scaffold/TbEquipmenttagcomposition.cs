using System;
using System.Collections.Generic;

namespace ARTGC.Models_scaffold;

/// <summary>
/// 장비별 Paremeter Tag 설정
/// </summary>
public partial class TbEquipmenttagcomposition
{
    /// <summary>
    /// 장비 ID
    /// </summary>
    public string Equipmentid { get; set; } = null!;

    /// <summary>
    /// Parameter ID
    /// </summary>
    public string Parameterid { get; set; } = null!;

    /// <summary>
    /// Tag ID
    /// </summary>
    public string Tagid { get; set; } = null!;

    /// <summary>
    /// 비고
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// 마지막수정일시
    /// </summary>
    public DateTime? Lastupdatetime { get; set; }

    /// <summary>
    /// 마지막수정자
    /// </summary>
    public string? Lastupdateuserid { get; set; }
}
