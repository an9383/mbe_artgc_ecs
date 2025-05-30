using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KR.MBE.Data.Models
{
    public class PosInfo
    {
        public string? BlockId { get; set; }
        public string? BayId { get; set; }
        public string? RowId { get; set; }
        public int? TROLLEYPOSITION { get; set; }
        public int? NextGantryPosition { get; set; }
        public int? CENTERPOSITION { get; set; }
    }
}
