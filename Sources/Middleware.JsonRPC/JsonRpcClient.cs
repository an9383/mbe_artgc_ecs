using Middleware.JsonRPC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Middleware.JsonRPC
{
    // AYC Job 관련 클라이언트
    public class JsonRpcClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "http://202.20.83.157:8110";
        private readonly JsonSerializerOptions _jsonOptions;
        
        public JsonRpcClient(string baseUrl = "http://202.20.83.157:8110")
        {
            _baseUrl = baseUrl;
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
                PropertyNameCaseInsensitive = true
            };
        }

       

        private async Task<JsonRpcResponse> SendRequestAsync(string endpoint, string methodName, object parameters = null)
        {
            // URL에서 메서드 이름 추출 (마지막 부분)
            //string methodName = endpoint.Substring(endpoint.LastIndexOf('/') + 1);

            var request = new JsonRpcRequest();
            request.Method = methodName;
            request.Params = parameters;
            request.Id = Guid.NewGuid().ToString();

            var content = new StringContent(
                JsonSerializer.Serialize(request, _jsonOptions),
                Encoding.UTF8,
                "application/json");

            var response = await _httpClient.PostAsync(endpoint, content);

            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<JsonRpcResponse>(responseContent, _jsonOptions);

            if (result.Error != null)
            {
                throw new Exception($"JSON-RPC Error: {result.Error.Code} - {result.Error.Message}");
            }

            return result;
        }



        public async Task SendJRPC_MSG_reject()
        {
            try
            {
                // Message accept
                var aycHead = new AycHeader
                {
                    msgId = AycJobService.CurrentMsgId,
                    evntTp = "Reject",
                    timeStamp = JsonRpcClient.GetCurrentTimeString(),
                    remark = ""
                };

                var aycBody = new AycBody_reject
                {
                    eqId = AycJobService.CurrentEqId,
                    jobId = AycJobService.CurrentjobId,
                    errCd = "00501"
                    
                };

                var aycRequest = new AycMsg_reject
                {
                    head = aycHead,
                    body = aycBody
                };

                var aycMsgList = new List<AycMsg_reject>();
                aycMsgList.Add(aycRequest);


                var aycJobResponse = await SendRequestAsync($"{_baseUrl}/equipment/ayc-exception", "reject", aycMsgList);

                Console.WriteLine($"AYC Reject 전송 성공: {JsonSerializer.Serialize(aycJobResponse)}");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"오류 발생: {ex.Message}");
            }
        }


        public async Task SendJRPC_MSG_Connection()
        {
            try
            {
                string guidString = Guid.NewGuid().ToString();

                // Message accept
                var aycHead = new AycHeader
                {
                    msgId = guidString,
                    evntTp = "ConnectionReport",
                    timeStamp = JsonRpcClient.GetCurrentTimeString(),
                    remark = ""
                };

                var aycBody = new AycBody_aycConnection
                {
                    eqId = "ARTG01",
                    connSts = "C"
                };

                var aycRequest = new AycMsg_aycConnection
                {
                    head = aycHead,
                    body = aycBody
                };

                var aycMsgList = new List<AycMsg_aycConnection>();
                aycMsgList.Add(aycRequest);


                var aycJobResponse = await SendRequestAsync($"{_baseUrl}/equipment/ayc-status", "aycConnection", aycMsgList);

                Console.WriteLine($"AYC Connection 전송 성공: {JsonSerializer.Serialize(aycJobResponse)}");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"오류 발생: {ex.Message}");
            }
        }


        public async Task SendJRPC_MSG_aycStatus(string autoSts = "1")
        {
            try
            {
                string guidString = Guid.NewGuid().ToString();

                // Message accept
                var aycHead = new AycHeader
                {
                    msgId = guidString,
                    evntTp = "AycStatusReport",
                    timeStamp = JsonRpcClient.GetCurrentTimeString(),
                    remark = ""
                };

                var aycBody = new AycBody_aycStatus
                {
                    eqId = "ARTG01",
                    oprMd = "4",
                    autoSts = autoSts,  // 1: Wait for Job,  2 Job Active
                    crnCtrl = "On",
                    wrkSts = "Y",
                    remoteMd = "N",
                    remoteUsrId = "",
                    jobId = AycJobService.CurrentjobId,
                    eqSts = "1"     // 1: GREEN
                };

                var aycRequest = new AycMsg_aycStatus
                {
                    head = aycHead,
                    body = aycBody
                };

                var aycMsgList = new List<AycMsg_aycStatus>();
                aycMsgList.Add(aycRequest);


                var aycJobResponse = await SendRequestAsync($"{_baseUrl}/equipment/ayc-status", "aycStatus", aycMsgList);

                Console.WriteLine($"AYC aycStatus 전송 성공: {JsonSerializer.Serialize(aycJobResponse)}");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"오류 발생: {ex.Message}");
            }
        }


        public async Task SendJRPC_MSG_aycPosition()
        {
            try
            {
                string guidString = Guid.NewGuid().ToString();

                // Message accept
                var aycHead = new AycHeader
                {
                    msgId = guidString,
                    evntTp = "AycPositionReport",
                    timeStamp = JsonRpcClient.GetCurrentTimeString(),
                    remark = ""
                };

                var aycBody = new AycBody_aycPosition
                {
                    eqId = "ARTG01",
                    wrkLoc = new AycLocation
                    {
                        locTp = "YARD",
                        loc1 = "BLOCK01",
                        loc2 = "3",
                        loc3 = "2",
                        loc4 = "1"
                    }
            };

                var aycRequest = new AycMsg_aycPosition
                {
                    head = aycHead,
                    body = aycBody
                };

                var aycMsgList = new List<AycMsg_aycPosition>();
                aycMsgList.Add(aycRequest);


                var aycJobResponse = await SendRequestAsync($"{_baseUrl}/equipment/ayc-status", "aycPosition", aycMsgList);

                Console.WriteLine($"AYC aycPosition 전송 성공: {JsonSerializer.Serialize(aycJobResponse)}");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"오류 발생: {ex.Message}");
            }
        }


        public async Task SendJRPC_MSG_aySpreader()
        {
            try
            {
                string guidString = Guid.NewGuid().ToString();

                // Message accept
                var aycHead = new AycHeader
                {
                    msgId = guidString,
                    evntTp = "AycSpreaderReport",
                    timeStamp = JsonRpcClient.GetCurrentTimeString(),
                    remark = ""
                };

                var aycBody = new AycBody_aycSpreader
                {
                    eqId = "ARTG01",
                    sprdSz = "1",
                    twistSts = "1"
                };

                var aycRequest = new AycMsg_aycSpreader
                {
                    head = aycHead,
                    body = aycBody
                };

                var aycMsgList = new List<AycMsg_aycSpreader>();
                aycMsgList.Add(aycRequest);


                var aycJobResponse = await SendRequestAsync($"{_baseUrl}/equipment/ayc-status", "aycSpreader", aycMsgList);

                Console.WriteLine($"AYC aycSpreaser 전송 성공: {JsonSerializer.Serialize(aycJobResponse)}");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"오류 발생: {ex.Message}");
            }
        }



        public async Task SendJRPC_MSG_accept()
        {
            try
            {
                // Message accept
                var aycHead = new AycHeader
                {
                    msgId = AycJobService.CurrentMsgId,
                    evntTp = "AcceptReport",
                    timeStamp = JsonRpcClient.GetCurrentTimeString(),
                    remark = ""
                };

                var aycBody = new AycBody_accept
                {
                    eqId = AycJobService.CurrentEqId,
                    jobId = AycJobService.CurrentjobId
                };

                var aycRequest = new AycMsg_accept
                {
                    head = aycHead,
                    body = aycBody
                };

                var aycMsgList = new List<AycMsg_accept>();
                aycMsgList.Add(aycRequest);


                var aycJobResponse = await SendRequestAsync($"{_baseUrl}/equipment/ayc-job", "accept", aycMsgList);

                Console.WriteLine($"AYC Job accept 전송 성공: {JsonSerializer.Serialize(aycJobResponse)}");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"오류 발생: {ex.Message}");
            }
        }

        public async Task SendJRPC_MSG_pickupDone()
        {
            try
            {
                // Message accept
                var aycHead = new AycHeader
                {
                    msgId = AycJobService.CurrentMsgId,
                    evntTp = "PickUpDone",
                    timeStamp = JsonRpcClient.GetCurrentTimeString(),
                    remark = ""
                };

                var aycBody = new AycBody_pickupDone
                {
                    eqId = AycJobService.CurrentEqId,
                    jobId = AycJobService.CurrentjobId,
                    cntrWgt = AycJobService.Current_cntrWgt,
                    wrkLoc = new AycLocation ()
                };

                aycBody.wrkLoc.loc1 = AycJobService.Current_PickupLoc.loc1;
                aycBody.wrkLoc.loc2 = AycJobService.Current_PickupLoc.loc2;
                aycBody.wrkLoc.loc3 = AycJobService.Current_PickupLoc.loc3;
                aycBody.wrkLoc.loc4 = AycJobService.Current_PickupLoc.loc4;
                aycBody.wrkLoc.locTp = AycJobService.Current_PickupLoc.locTp;

                var aycRequest = new AycMsg_pickupDone
                {
                    head = aycHead,
                    body = aycBody
                };

                var aycMsgList = new List<AycMsg_pickupDone>();
                aycMsgList.Add(aycRequest);


                var aycJobResponse = await SendRequestAsync($"{_baseUrl}/equipment/ayc-job", "pickupDone", aycMsgList);

                Console.WriteLine($"AYC Pickup Done 전송 성공: {JsonSerializer.Serialize(aycJobResponse)}");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"오류 발생: {ex.Message}");
            }
        }

        public async Task SendJRPC_MSG_JobDone()
        {
            try
            {
                // Message accept
                var aycHead = new AycHeader
                {
                    msgId = AycJobService.CurrentMsgId,
                    evntTp = "JobDoneReport",
                    timeStamp = JsonRpcClient.GetCurrentTimeString(),
                    remark = ""
                };

                var aycBody = new AycBody_jobDone
                {
                    eqId = AycJobService.CurrentEqId,
                    jobId = AycJobService.CurrentjobId,
                    cntrWgt = AycJobService.Current_cntrWgt,
                    wrkLoc = new AycLocation()
                };

                aycBody.wrkLoc.loc1 = AycJobService.Current_Location.loc1;
                aycBody.wrkLoc.loc2 = AycJobService.Current_Location.loc2;
                aycBody.wrkLoc.loc3 = AycJobService.Current_Location.loc3;
                aycBody.wrkLoc.loc4 = AycJobService.Current_Location.loc4;
                aycBody.wrkLoc.locTp = AycJobService.Current_Location.locTp;

                var aycRequest = new AycMsg_jobDone
                {
                    head = aycHead,
                    body = aycBody
                };

                var aycMsgList = new List<AycMsg_jobDone>();
                aycMsgList.Add(aycRequest);


                var aycJobResponse = await SendRequestAsync($"{_baseUrl}/equipment/ayc-job", "jobDone", aycMsgList);

                Console.WriteLine($"AYC Job Done 전송 성공: {JsonSerializer.Serialize(aycJobResponse)}");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"오류 발생: {ex.Message}");
            }
        }

        public async Task SendJRPC_MSG_abortStatus()
        {
            try
            {
                // Message accept
                var aycHead = new AycHeader
                {
                    msgId = AycJobService.CurrentMsgId,
                    evntTp = "AbortReport",
                    timeStamp = JsonRpcClient.GetCurrentTimeString(),
                    remark = ""
                };

                var aycBody = new AycBody_abortStatus
                {
                    eqId = AycJobService.CurrentEqId,
                    jobId = AycJobService.CurrentjobId,
                    result = "S",
                    errCd = ""
                    
                };

                var aycRequest = new AycMsg_abortStatus
                {
                    head = aycHead,
                    body = aycBody
                };

                var aycMsgList = new List<AycMsg_abortStatus>();
                aycMsgList.Add(aycRequest);


                var aycJobResponse = await SendRequestAsync($"{_baseUrl}/equipment/ayc-job", "abortStatus", aycMsgList);

                Console.WriteLine($"AYC AbortStatus 전송 성공: {JsonSerializer.Serialize(aycJobResponse)}");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"오류 발생: {ex.Message}");
            }
        }


        public async Task SendJRPC_MSG_detectVehicle()
        {
            try
            {
                // Message accept
                var aycHead = new AycHeader
                {
                    msgId = AycJobService.CurrentMsgId,
                    evntTp = "DetectVehicle",
                    timeStamp = JsonRpcClient.GetCurrentTimeString(),
                    remark = ""
                };

                var aycBody = new AycBody_detectVehicle
                {
                    eqId = AycJobService.CurrentEqId,
                    jobId = AycJobService.CurrentjobId,
                    vehicleId = "YT001",
                    vehiclekLoc = new AycLocation ()
                };

                aycBody.vehiclekLoc.loc1 = AycJobService.Current_Location.loc1;
                aycBody.vehiclekLoc.loc2 = AycJobService.Current_Location.loc2;
                aycBody.vehiclekLoc.loc3 = AycJobService.Current_Location.loc3;
                aycBody.vehiclekLoc.loc4 = AycJobService.Current_Location.loc4;
                aycBody.vehiclekLoc.locTp = AycJobService.Current_Location.locTp;



                var aycRequest = new AycMsg_detectVehicle
                {
                    head = aycHead,
                    body = aycBody
                };

                var aycMsgList = new List<AycMsg_detectVehicle>();
                aycMsgList.Add(aycRequest);


                var aycJobResponse = await SendRequestAsync($"{_baseUrl}/equipment/ayc-job", "detectVehicle", aycMsgList);

                Console.WriteLine($"AYC Detect Vehicle 전송 성공: {JsonSerializer.Serialize(aycJobResponse)}");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"오류 발생: {ex.Message}");
            }
        }




        public static string GetCurrentTimeString()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
        }


    }
}
