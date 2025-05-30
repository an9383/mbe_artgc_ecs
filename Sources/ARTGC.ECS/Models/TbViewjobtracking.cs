using System;
using System.Collections.Generic;

namespace ARTGC.Models;

/// <summary>
/// Job을 수행하기 위한 Step Job 진행 정보를 생성 관리
/// </summary>
public partial class TbViewjobtracking
{
    /// <summary>
    /// TOS로 부터 내려받은 Job Order ID
    /// </summary>
    public string Joborderid { get; set; } = null!;

    /// <summary>
    /// Timekey
    /// </summary>
    public string Timekey { get; set; } = null!;

    /// <summary>
    /// Job을 수행할 Crane ID
    /// </summary>
    public string Equipmentid { get; set; } = null!;

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
    public int? Stepsequence { get; set; }

    /// <summary>
    /// Step Job 구분 [ StartEnd | Execute ]
    /// </summary>
    public string? Stepjobtype { get; set; }

    /// <summary>
    /// StepComposition 고유 ID
    /// </summary>
    public string? Compositionid { get; set; }

    /// <summary>
    /// 상태 [ Wait | StartRequest | Start | Completed ]
    /// </summary>
    public string? Stepjobstatus { get; set; }

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
    /// 시작 일시
    /// </summary>
    public DateTime? Starttime { get; set; }

    /// <summary>
    /// 시작 작업자
    /// </summary>
    public string? Startuserid { get; set; }

    /// <summary>
    /// 시작 동작모드 [ Auto | Manual ]
    /// </summary>
    public string? Startmode { get; set; }

    /// <summary>
    /// 시작 작업시스템
    /// </summary>
    public string? Startsystem { get; set; }

    /// <summary>
    /// 완료 일시
    /// </summary>
    public DateTime? Startiftime { get; set; }

    /// <summary>
    /// 완료 작업자
    /// </summary>
    public DateTime? Endtime { get; set; }

    /// <summary>
    /// 완료 동작모드 [ Auto | Manual ]
    /// </summary>
    public string? Enduserid { get; set; }

    /// <summary>
    /// 완료 작업시스템
    /// </summary>
    public string? Endmode { get; set; }

    /// <summary>
    /// 시작 인터페이스 일시
    /// </summary>
    public string? Endsystem { get; set; }

    /// <summary>
    /// 완료 인터페이스 일시
    /// </summary>
    public DateTime? Endiftime { get; set; }
}
