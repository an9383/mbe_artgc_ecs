using System;
using System.Collections.Generic;

namespace ARTGC.Models;

/// <summary>
/// Step Job을 수행할때 필요한 Parameter 정의
/// </summary>
public partial class TbParameter
{
    /// <summary>
    /// Parameter ID
    /// </summary>
    public string Parameterid { get; set; } = null!;

    /// <summary>
    /// Parameter 명
    /// </summary>
    public string? Parametername { get; set; }

    public string? Parametertype { get; set; }

    public int? Orderindex { get; set; }

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
