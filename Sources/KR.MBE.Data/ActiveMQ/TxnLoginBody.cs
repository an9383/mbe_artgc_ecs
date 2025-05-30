using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace KR.MBE.Data.ActiveMQ
{
    [DataContract]
    public class TxnLoginBody
    {
        [DataMember(Name = "LANGUAGE")]
        public string language { get; set; }

        [DataMember(Name = "SITEID")]
        public string siteId { get; set; }

        [DataMember(Name = "USERID")]
        public string userId { get; set; }

        [DataMember(Name = "USERPASSWORD")]
        public string userPassword { get; set; }


        [DataMember(Name = "EVENTUSER")]
        public string eventUser { get; set; }
    }
}
