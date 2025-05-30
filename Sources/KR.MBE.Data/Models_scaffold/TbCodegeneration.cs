using System;
using System.Collections.Generic;

namespace ARTGC.Models_scaffold;

public partial class TbCodegeneration
{
    public string Codegentype { get; set; } = null!;

    public int Linenumber { get; set; }

    public string? Description { get; set; }
}
