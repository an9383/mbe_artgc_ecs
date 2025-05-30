using System;
using System.Collections.Generic;

namespace KR.MBE.RCMS.Models;

public partial class TbParameterBack250109
{
    public string Parameterid { get; set; } = null!;

    public string? Parametername { get; set; }

    public string? Parametertype { get; set; }

    public int? Orderindex { get; set; }

    public string? Description { get; set; }

    public DateTime? Lastupdatetime { get; set; }

    public string? Lastupdateuserid { get; set; }
}
