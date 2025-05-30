using System;
using System.Collections.Generic;

namespace KR.MBE.RCMS.Models;

public partial class TbTransform
{
    public string Id { get; set; } = null!;

    public string Type { get; set; } = null!;

    public string? Useflag { get; set; }

    public int? Offsetx { get; set; }

    public int? Offsety { get; set; }

    public double? Scalex { get; set; }

    public double? Scaley { get; set; }

    public DateTime? Lastupdatetime { get; set; }

    public string? Lastupdateuserid { get; set; }
}
