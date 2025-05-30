using System;
using System.Collections.Generic;

namespace ARTGC.Models_scaffold;

/// <summary>
/// TOS로부터 수신한 Job Order의 현재 상태 및 진행 이력
/// </summary>
public partial class TbJoborderhistory
{
    /// <summary>
    /// Job Order ID
    /// </summary>
    public string Joborderid { get; set; } = null!;

    /// <summary>
    /// TimeKey
    /// </summary>
    public string Timekey { get; set; } = null!;

    /// <summary>
    /// Job ID
    /// </summary>
    public string? Jobid { get; set; }

    /// <summary>
    /// Job 상태 [ Wait | Start | Completed | Deleted | … ] 
    /// </summary>
    public string? Jobstatus { get; set; }

    /// <summary>
    /// Job 구분 [ GI | GO | DS | LD | … ]
    /// </summary>
    public string? Jobtype { get; set; }

    /// <summary>
    /// 크레인 ID
    /// </summary>
    public string? Equipmentid { get; set; }

    /// <summary>
    /// 원격운전 Station ID
    /// </summary>
    public string? Remotestationid { get; set; }

    /// <summary>
    /// 컨테이너 ID
    /// </summary>
    public string? Containerid { get; set; }

    /// <summary>
    /// 컨테이너 ISO (Container Size &amp; Type 규격)
    /// </summary>
    public string? Containeriso { get; set; }

    /// <summary>
    /// 컨테이너 Size [ 20ft | 40ft | 45ft | 48ft ]
    /// </summary>
    public string? Containersize { get; set; }

    /// <summary>
    /// 컨테이너 Height [ 0:Undefined | 1:8&apos;6&apos;&apos; | 2:9&apos;6&apos;&apos; | 3:8&apos; ]
    /// </summary>
    public string? Containerheight { get; set; }

    /// <summary>
    /// 컨테이너 Weight (kg)
    /// </summary>
    public string? Containerweight { get; set; }

    /// <summary>
    /// 컨테이너 Door Direction [ 1:TowardLowerBay | 2:TowardHigherBay ]
    /// </summary>
    public string? Containerdoordir { get; set; }

    /// <summary>
    /// Spreader Size [ -1:Undefined | 0:NoSpreader | 1:20ft | 2:40ft | 3:45ft | 19:Moving ]
    /// </summary>
    public string? Spreadersize { get; set; }

    /// <summary>
    /// 컨테이너 구분
    /// </summary>
    public string? Containertype { get; set; }

    /// <summary>
    /// 컨테이너 Operator Code
    /// </summary>
    public string? Containeropr { get; set; }

    /// <summary>
    /// 컨테이너 Class
    /// </summary>
    public string? Containerclass { get; set; }

    /// <summary>
    /// 컨테이너 Cargo Type
    /// </summary>
    public string? Containercargotype { get; set; }

    /// <summary>
    /// 컨테이너 Full Empty
    /// </summary>
    public string? Containerfullmty { get; set; }

    /// <summary>
    /// 차량 ID
    /// </summary>
    public string? Vehicleid { get; set; }

    /// <summary>
    /// 차량 Type
    /// </summary>
    public string? Vehicletype { get; set; }

    /// <summary>
    /// 차량위치
    /// </summary>
    public string? Vehicleposition { get; set; }

    /// <summary>
    /// From Location Block
    /// </summary>
    public string? Fromblock { get; set; }

    /// <summary>
    /// From Location Bay
    /// </summary>
    public string? Frombay { get; set; }

    /// <summary>
    /// From Location Row
    /// </summary>
    public string? Fromrow { get; set; }

    /// <summary>
    /// From Location Tier
    /// </summary>
    public string? Fromtier { get; set; }

    /// <summary>
    /// To Location Block
    /// </summary>
    public string? Toblock { get; set; }

    /// <summary>
    /// To Location Bay
    /// </summary>
    public string? Tobay { get; set; }

    /// <summary>
    /// To Location Row
    /// </summary>
    public string? Torow { get; set; }

    /// <summary>
    /// To Location Tier
    /// </summary>
    public string? Totier { get; set; }

    /// <summary>
    /// Interface Send Timekey (14자리)
    /// </summary>
    public string? Sendtimekey { get; set; }

    /// <summary>
    /// Interface Job Status
    /// </summary>
    public string? Sendjobstatus { get; set; }

    /// <summary>
    /// Interface Topic
    /// </summary>
    public string? Sendtopic { get; set; }

    /// <summary>
    /// Job 수신일시
    /// </summary>
    public DateTime? Recvtime { get; set; }

    /// <summary>
    /// Job 시작일시
    /// </summary>
    public DateTime? Starttime { get; set; }

    /// <summary>
    /// Job 종료일시
    /// </summary>
    public DateTime? Endtime { get; set; }

    /// <summary>
    /// 현재진행중인 Step Job의 Composition ID
    /// </summary>
    public string? Compositionid { get; set; }

    /// <summary>
    /// Reject 사유코드
    /// </summary>
    public string? Rejectcode { get; set; }

    /// <summary>
    /// Reject Comment
    /// </summary>
    public string? Rejectcomment { get; set; }

    /// <summary>
    /// 마지막수정일시
    /// </summary>
    public DateTime? Lastupdatetime { get; set; }

    /// <summary>
    /// 마지막수정자
    /// </summary>
    public string? Lastupdateuserid { get; set; }

    /// <summary>
    /// Event Name
    /// </summary>
    public string? Eventname { get; set; }

    /// <summary>
    /// Event Type
    /// </summary>
    public string? Eventtype { get; set; }

    /// <summary>
    /// Event Time
    /// </summary>
    public DateTime? Eventtime { get; set; }

    /// <summary>
    /// Event User
    /// </summary>
    public string? Eventuserid { get; set; }

    /// <summary>
    /// Event Description 
    /// </summary>
    public string? Eventcomment { get; set; }
}
