using System;
using System.Collections.Generic;

namespace KR.MBE.RCMS.Models;

/// <summary>
/// Job, StepJob 구성 관리
/// </summary>
public partial class TbStepcomposition
{
    /// <summary>
    /// Job ID
    /// </summary>
    public string Jobid { get; set; } = null!;

    /// <summary>
    /// Step Job ID
    /// </summary>
    public string Stepjobid { get; set; } = null!;

    /// <summary>
    /// 순서
    /// </summary>
    public int Stepsequence { get; set; }

    /// <summary>
    /// StepComposition 고유 ID
    /// </summary>
    public string? Compositionid { get; set; }

    /// <summary>
    /// 인터페이스 구분 [ None | Start | End | Both | Execute ] 
    /// </summary>
    public string? Ifactiontype { get; set; }

    /// <summary>
    /// 인터페이스 실행 함수
    /// </summary>
    public string? Startiffunctionname { get; set; }

    public string? Endiffunctionname { get; set; }

    public string? Preiffunctionname { get; set; }

    /// <summary>
    /// 비고
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// 동작모드 [ Auto | Manual ] 
    /// </summary>
    public string? Operationmode { get; set; }

    /// <summary>
    /// 데이터 생성 구분 [ RealTime | ReceivedTime ]
    /// </summary>
    public string? Createdatatype { get; set; }

    /// <summary>
    /// 마지막수정일시
    /// </summary>
    public DateTime? Lastupdatetime { get; set; }

    /// <summary>
    /// 마지막수정자
    /// </summary>
    public string? Lastupdateuserid { get; set; }
}
