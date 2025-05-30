using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using KR.MBE.Data.CLT.Common;

namespace KR.MBE.Data.CLT.YC
{
    public partial class YCMethod
    {
        /// <summary>
        /// If the vehicle is in the right position(CPS 00) under the AYC (Yard Crane) from TOS to EIS
        /// /equipment/ayc-job/sendClearance
        /// OPUS (TOS) -> IoT Platform -> EIS
        /// </summary>
        [DataContract]
        public class ResponseClearanceResponse
        {
            [JsonProperty("msgId")]
            public string msgId { get; set; }
            [JsonProperty("errCd")]
            public string errCd { get; set; }
            [JsonProperty("errDesc")]
            public string errDesc { get; set; }
        }
    }
}
