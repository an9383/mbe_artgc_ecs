using System;
using System.Collections.Generic;

namespace KR.MBE.RCMS.Models;

/// <summary>
/// 즐겨찾기메뉴관리
/// </summary>
public partial class TbMenufavorite
{
    /// <summary>
    /// 유저ID
    /// </summary>
    public string Userid { get; set; } = null!;

    /// <summary>
    /// Menu ID
    /// </summary>
    public string Menuid { get; set; } = null!;
}
