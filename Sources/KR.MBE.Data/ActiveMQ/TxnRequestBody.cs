using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace KR.MBE.Data.ActiveMQ
{
    public class SingleOrArrayConverter<T> : JsonConverter
    {
        public override bool CanConvert(Type objectType) =>
            (objectType == typeof(List<T>));

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);
            if (token.Type == JTokenType.Array)
                return token.ToObject<List<T>>();
            return new List<T> { token.ToObject<T>() };
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) =>
            serializer.Serialize(writer, value);
    }


    public class DataList
    {
        [JsonProperty("DATAINFO")]
        [JsonConverter(typeof(SingleOrArrayConverter<Hashtable>))]
        public List<Hashtable> dataInfos { get; set; }
    }

    [DataContract]
    public class TxnRequestBody
    {
        [DataMember(Name = "LANGUAGE")]
        public string language { get; set; }

        [DataMember(Name = "EVENTUSER")]
        public string eventUser { get; set; }

        [DataMember(Name = "PKCOLUMNIDLIST")]
        public List<string> pkColumnList { get; set; } = new List<string>();

        [DataMember(Name = "DATALIST")]
        public DataList dataList { get; set; }
    }
}
