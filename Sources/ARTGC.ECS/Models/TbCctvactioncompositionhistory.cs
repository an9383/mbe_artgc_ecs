using System;
using System.Collections.Generic;

namespace ARTGC.Models;

public partial class TbCctvactioncompositionhistory
{
    public string Equipmentid { get; set; } = null!;

    public string Cctvactionid { get; set; } = null!;

    public int Orderindex { get; set; }

    public string Timekey { get; set; } = null!;

    public string? Cctvid { get; set; }

    public string? Description { get; set; }

    public DateTime? Lastupdatetime { get; set; }

    public string? Lastupdateuserid { get; set; }

    public string? Eventname { get; set; }

    public string? Eventtype { get; set; }

    public DateTime? Eventtime { get; set; }

    public string? Eventuserid { get; set; }

    public string? Eventcomment { get; set; }
}
