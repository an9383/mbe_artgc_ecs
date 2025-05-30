using Newtonsoft.Json;
using System;
using System.Collections;
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
        /// Send move order to AYC (Yard Crane) from TOS to EIS
        /// /equipment/ayc-job/sendMoveJob
        /// OPUS (TOS) -> IoT Platform -> EIS
        /// </summary>
        [DataContract]
        public class RequestMoveJobResponse
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
