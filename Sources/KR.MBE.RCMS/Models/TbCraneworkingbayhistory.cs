using System;
using System.Collections.Generic;

namespace KR.MBE.RCMS.Models;

public partial class TbCraneworkingbayhistory
{
    public string Equipmentid { get; set; } = null!;

    public string Blockid { get; set; } = null!;

    public string Bayid { get; set; } = null!;

    public string Timekey { get; set; } = null!;

    public DateTime? Lastupdatetime { get; set; }

    public string? Lastupdateuserid { get; set; }

    public string? Eventname { get; set; }

    public string? Eventtype { get; set; }

    public DateTime? Eventtime { get; set; }

    public string? Eventuserid { get; set; }

    public string? Eventcomment { get; set; }
}
