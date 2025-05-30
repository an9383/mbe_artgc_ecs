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
    public class GetQueryResultBody
    {
        [DataMember(Name = "LANGUAGE")]
        public string language { get; set; }

        [DataMember(Name = "QUERYID")]
        public string queryId { get; set; }

        [DataMember(Name = "SITEID")]
        public string siteId { get; set; }

        [DataMember(Name = "EVENTUSER")]
        public string eventUser { get; set; }

        [DataMember(Name = "QUERYVERSION")]
        public string queryVersion { get; set; }

        [DataMember(Name = "BINDV")] 
        public Hashtable BindDictionary { get; set; } = new Hashtable();
    }
}
