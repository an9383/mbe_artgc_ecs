using System;
using System.Collections.Generic;

namespace ARTGC.Models;

public partial class TbParametercomposition0712
{
    public string Compositionid { get; set; } = null!;

    public string Actiontype { get; set; } = null!;

    public string Parameterid { get; set; } = null!;

    public int? Parameterlevel { get; set; }

    public int? Orderindex { get; set; }

    public string? Description { get; set; }

    public string? Dataactiontype { get; set; }

    public string? Dataprocesstype { get; set; }

    public string? Createdatamethod { get; set; }

    public string? Fixedvalue { get; set; }

    public string? Receiveid { get; set; }

    public string? Makefunctionname { get; set; }

    public string? Datatarget { get; set; }

    public DateTime? Lastupdatetime { get; set; }

    public string? Lastupdateuserid { get; set; }
}
