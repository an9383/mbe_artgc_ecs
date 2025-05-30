using System;
using System.Collections.Generic;

namespace ARTGC.Models;

/// <summary>
/// Step Job을 수행하기 위한 Parameter 정보를 생성 관리
/// </summary>
public partial class TbViewjobparameter
{
    /// <summary>
    /// TOS로 부터 내려받은 Job Order ID
    /// </summary>
    public string Joborderid { get; set; } = null!;

    /// <summary>
    /// ViewJobTracking의 TimeKey
    /// </summary>
    public string Timekey { get; set; } = null!;

    /// <summary>
    /// StepComposition 고유 ID
    /// </summary>
    public string Compositionid { get; set; } = null!;

    /// <summary>
    /// 작업구분 [ Start | End | Execute ]
    /// </summary>
    public string Actiontype { get; set; } = null!;

    /// <summary>
    /// Parameter ID
    /// </summary>
    public string Parameterid { get; set; } = null!;

    /// <summary>
    /// Parameter Level
    /// </summary>
    public int? Parameterlevel { get; set; }

    /// <summary>
    /// Tag ID
    /// </summary>
    public string? Tagid { get; set; }

    /// <summary>
    /// Tag 값
    /// </summary>
    public string? Tagvalue { get; set; }

    /// <summary>
    /// Data 작업구분 [ Set | Get ] 
    /// </summary>
    public string? Dataactiontype { get; set; }

    /// <summary>
    /// Data 처리구분 [ Event | Data ]
    /// </summary>
    public string? Dataprocesstype { get; set; }

    /// <summary>
    /// 비고
    /// </summary>
    public string? Description { get; set; }

    public string? Receivedid { get; set; }

    public string? Datatarget { get; set; }

    public string? Datafailtarget { get; set; }

    public string? Parameterstatus { get; set; }
}
