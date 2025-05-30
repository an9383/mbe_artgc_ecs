using System;
using System.Collections.Generic;

namespace ARTGC.Models;

/// <summary>
/// RTGC에서 발생한 Alarm 이력 관리
/// </summary>
public partial class TbAlarmhistory
{
    /// <summary>
    /// Crane ID
    /// </summary>
    public string Equipmentid { get; set; } = null!;

    /// <summary>
    /// Alarm Timekey
    /// </summary>
    public string Alarmtimekey { get; set; } = null!;

    public string? Alarmcode { get; set; }

    /// <summary>
    /// 알람 수준 [ Info | Warning | Error | Fatal ] 
    /// </summary>
    public string? Alarmlevel { get; set; }

    /// <summary>
    /// 알람 내용
    /// </summary>
    public string? Alarmcomment { get; set; }

    /// <summary>
    /// 발생시점 Job Order ID
    /// </summary>
    public string? Joborderid { get; set; }

    /// <summary>
    /// 알람발생시 처리 구분
    /// </summary>
    public string? Alarmactiontype { get; set; }

    /// <summary>
    /// 알람일시
    /// </summary>
    public DateTime? Alarmtim { get; set; }
}
