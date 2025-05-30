using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Middleware.JsonRPC.Data
{
    // JSON-RPC 요청 및 응답 모델
    [DataContract]
    public class JsonRpcRequest
    {
        [DataMember(Name = "Jsonrpc")]
        public string Jsonrpc { get; set; } = "2.0";
        [DataMember(Name = "Method")]
        public string Method { get; set; }
        [DataMember(Name = "Params")]
        public object Params { get; set; }
        [DataMember(Name = "Id")]
        public string Id { get; set; }
    }

    [DataContract]
    public class JsonRpcResponse
    {
        [DataMember(Name = "Jsonrpc")]
        public string Jsonrpc { get; set; } = "2.0";
        [DataMember(Name = "Id")]
        public string Id { get; set; }
        [DataMember(Name = "Result")]
        public object Result { get; set; }
        [DataMember(Name = "Error")]
        public JsonRpcError Error { get; set; }
    }

    [DataContract]
    public class JsonRpcError
    {
        [DataMember(Name = "Code")]
        public int Code { get; set; }
        [DataMember(Name = "Message")]
        public string Message { get; set; }
        [DataMember(Name = "Data")]
        public object Data { get; set; }
    }
}
