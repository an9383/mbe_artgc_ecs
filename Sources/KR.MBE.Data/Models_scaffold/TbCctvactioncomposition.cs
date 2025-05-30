using System;
using System.Collections.Generic;

namespace ARTGC.Models_scaffold;

public partial class TbCctvactioncomposition
{
    public string Equipmentid { get; set; } = null!;

    public string Cctvactionid { get; set; } = null!;

    public int Orderindex { get; set; }

    public string? Cctvid { get; set; }

    public string? Description { get; set; }

    public DateTime? Lastupdatetime { get; set; }

    public string? Lastupdateuserid { get; set; }
}
