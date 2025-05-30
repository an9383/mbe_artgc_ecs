using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KR.MBE.Data.Models
{
    public class BayData
    {
        public string? BlockId { get; set; }
        public string? BayId { get; set; }
        public int? GantryPosition { get; set; }
        public int? NextGantryPosition { get; set; }
        public int? CenterPosition { get; set; }
    }
}
