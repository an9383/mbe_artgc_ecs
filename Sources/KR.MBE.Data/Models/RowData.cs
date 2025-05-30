using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KR.MBE.Data.Models
{
    public class RowData
    {
        public string? BlockId { get; set; }
        public string? BayId { get; set; }
        public string? RowId { get; set; }
        public int? TrolleyPosition { get; set; }
        public int? NextTrolleyPosition { get; set; }
        public int? CenterPosition { get; set; }
    }
}
