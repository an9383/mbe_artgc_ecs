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
    public class GetInventoryForBody
    {
        [DataMember(Name = "BINDV")]
        public Hashtable BindDictionary { get; set; } = new Hashtable();
    }
}
