using System;
using System.Collections.Generic;

namespace ARTGC.Models;

/// <summary>
/// Block 정의
/// </summary>
public partial class TbBlock
{
    /// <summary>
    /// Block ID
    /// </summary>
    public string Blockid { get; set; } = null!;

    /// <summary>
    /// Block 명
    /// </summary>
    public string? Blockname { get; set; }

    /// <summary>
    /// Block 유형
    /// </summary>
    public string? Blocktype { get; set; }

    /// <summary>
    /// 사용여부
    /// </summary>
    public string? Useflag { get; set; }

    /// <summary>
    /// Bay 순서 증가 방향
    /// </summary>
    public string? Baydirection { get; set; }

    /// <summary>
    /// Row 순서 증가 방향
    /// </summary>
    public string? Rowdirection { get; set; }

    /// <summary>
    /// ITV의 Block 진입 방향
    /// </summary>
    public string? Itvdirection { get; set; }

    /// <summary>
    /// 기준 좌표 Block 여부 (BlockGroup 기준 한 개만 존재)
    /// </summary>
    public string? Baseflag { get; set; }

    /// <summary>
    /// Gantry Position
    /// </summary>
    public int? Gantryposition { get; set; }

    public int? Maxgantryposition { get; set; }

    public int? Maxtrolleyposition { get; set; }

    public int? Maxhoistposition { get; set; }

    /// <summary>
    /// 상대좌표 X
    /// </summary>
    public int? Posx { get; set; }

    /// <summary>
    /// 상태좌표 Y
    /// </summary>
    public int? Posy { get; set; }

    /// <summary>
    /// GPS위도
    /// </summary>
    public string? Gpslatitude { get; set; }

    /// <summary>
    /// GPS경도
    /// </summary>
    public string? Gpslongitude { get; set; }

    /// <summary>
    /// 마지막수정일시
    /// </summary>
    public DateTime? Lastupdatetime { get; set; }

    /// <summary>
    /// 마지막수정자
    /// </summary>
    public string? Lastupdateuserid { get; set; }
}
