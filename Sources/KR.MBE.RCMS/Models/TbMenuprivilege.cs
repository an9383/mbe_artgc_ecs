using System;
using System.Collections.Generic;

namespace KR.MBE.RCMS.Models;

/// <summary>
/// 메뉴 권한 관리
/// </summary>
public partial class TbMenuprivilege
{
    /// <summary>
    /// 유저ID
    /// </summary>
    public string Userid { get; set; } = null!;

    /// <summary>
    /// Menu ID
    /// </summary>
    public string Menuid { get; set; } = null!;

    /// <summary>
    /// 클라이언트구분
    /// </summary>
    public string? Clienttype { get; set; }

    /// <summary>
    /// 저장여부
    /// </summary>
    public string? Saveflag { get; set; }
}
