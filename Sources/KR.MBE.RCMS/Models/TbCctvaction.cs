using System;
using System.Collections.Generic;

namespace KR.MBE.RCMS.Models;

public partial class TbCctvaction
{
    public string Cctvactionid { get; set; } = null!;

    public string? Cctvactionname { get; set; }

    public string? Description { get; set; }

    public DateTime? Lastupdatetime { get; set; }

    public string? Lastupdateuserid { get; set; }
}
