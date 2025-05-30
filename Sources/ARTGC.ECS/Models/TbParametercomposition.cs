using System;
using System.Collections.Generic;

namespace ARTGC.Models;

/// <summary>
/// Job, StepJob, Parameter 구성을 관리
/// </summary>
public partial class TbParametercomposition
{
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

    public int? Orderindex { get; set; }

    /// <summary>
    /// 비고
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Data 작업구분 [ Set | Get ] 
    /// </summary>
    public string? Dataactiontype { get; set; }

    /// <summary>
    /// Data 처리구분 [ Event | Data ]
    /// </summary>
    public string? Dataprocesstype { get; set; }

    /// <summary>
    /// Data 생성방법 [ FixedValue | InReceived | MakeFunction ]
    /// </summary>
    public string? Createdatamethod { get; set; }

    /// <summary>
    /// CreateDataMethod가 FixedValue인 경우 고정값
    /// </summary>
    public string? Fixedstartvalue { get; set; }

    public string? Fixedendvalue { get; set; }

    /// <summary>
    /// CreateDataMethod가 InReceived인 경우 Receive ID 값이 없으면 Parameter ID 로 처리함.
    /// </summary>
    public string? Receiveid { get; set; }

    /// <summary>
    /// CreateDataMethod가 MakeFunction인 경우 함수명
    /// </summary>
    public string? Makefunctionname { get; set; }

    public string? Eventreportfunctionname { get; set; }

    public string? Eventreplyparametername { get; set; }

    /// <summary>
    /// Data를 Set 또는 Get 하기 위한 Device Target
    /// </summary>
    public string? Datatarget { get; set; }

    public string? Datafailtarget { get; set; }

    /// <summary>
    /// 마지막수정일시
    /// </summary>
    public DateTime? Lastupdatetime { get; set; }

    /// <summary>
    /// 마지막수정자
    /// </summary>
    public string? Lastupdateuserid { get; set; }
}
