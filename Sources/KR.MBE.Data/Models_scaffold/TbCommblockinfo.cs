using System;
using System.Collections.Generic;

namespace ARTGC.Models_scaffold;

/// <summary>
/// 스테이션에서 Read 할 통신영역 설정
/// </summary>
public partial class TbCommblockinfo
{
    /// <summary>
    /// Equipment ID
    /// </summary>
    public string Equipmentid { get; set; } = null!;

    /// <summary>
    /// Station ID
    /// </summary>
    public string Stationid { get; set; } = null!;

    /// <summary>
    /// 통신블럭 Index
    /// </summary>
    public int Blockno { get; set; }

    /// <summary>
    /// Address Type or 구분자
    /// </summary>
    public string? Blocktype { get; set; }

    /// <summary>
    /// Start Address(시작주소)
    /// </summary>
    public string? Startaddress { get; set; }

    /// <summary>
    /// Read Data Number(읽을 데이터 개수)
    /// </summary>
    public int? Readdatanumber { get; set; }

    /// <summary>
    /// Communication Interval(Cycle) (단위 100ms)
    /// </summary>
    public int? Comminterval { get; set; }
}
