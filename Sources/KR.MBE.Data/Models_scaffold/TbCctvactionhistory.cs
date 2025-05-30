using System;
using System.Collections.Generic;

namespace ARTGC.Models_scaffold;

public partial class TbCctvactionhistory
{
    public string Cctvactionid { get; set; } = null!;

    public string Timekey { get; set; } = null!;

    public string? Cctvactionname { get; set; }

    public string? Description { get; set; }

    public DateTime? Lastupdatetime { get; set; }

    public string? Lastupdateuserid { get; set; }

    public string? Eventname { get; set; }

    public string? Eventtype { get; set; }

    public DateTime? Eventtime { get; set; }

    public string? Eventuserid { get; set; }

    public string? Eventcomment { get; set; }
}
