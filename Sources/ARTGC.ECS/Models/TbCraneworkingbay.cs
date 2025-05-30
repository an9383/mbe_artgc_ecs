using System;
using System.Collections.Generic;

namespace ARTGC.Models;

public partial class TbCraneworkingbay
{
    public string Equipmentid { get; set; } = null!;

    public string Blockid { get; set; } = null!;

    public string Bayid { get; set; } = null!;

    public DateTime? Lastupdatetime { get; set; }

    public string? Lastupdateuserid { get; set; }
}
