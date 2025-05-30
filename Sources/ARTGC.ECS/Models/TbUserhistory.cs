using System;
using System.Collections.Generic;

namespace ARTGC.Models;

/// <summary>
/// 사용자정보
/// </summary>
public partial class TbUserhistory
{
    /// <summary>
    /// User ID
    /// </summary>
    public string Userid { get; set; } = null!;

    /// <summary>
    /// TimeKey
    /// </summary>
    public string Timekey { get; set; } = null!;

    /// <summary>
    /// User Password
    /// </summary>
    public string? Userpassword { get; set; }

    /// <summary>
    /// User Name
    /// </summary>
    public string? Username { get; set; }

    /// <summary>
    /// 사용여부
    /// </summary>
    public string? Useflag { get; set; }

    /// <summary>
    /// Email
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// 사원번호
    /// </summary>
    public string? Employeenumber { get; set; }

    /// <summary>
    /// 관리자권한
    /// </summary>
    public string? Adminflag { get; set; }

    /// <summary>
    /// 사용자그룹
    /// </summary>
    public string? Usergroupid { get; set; }

    /// <summary>
    /// 소속부서
    /// </summary>
    public string? Department { get; set; }

    /// <summary>
    /// 직위
    /// </summary>
    public string? Workposition { get; set; }

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
