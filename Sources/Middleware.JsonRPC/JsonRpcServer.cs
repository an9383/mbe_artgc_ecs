using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Middleware.JsonRPC.Data;
using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Middleware.JsonRPC
{

    public class AbortJobRequest
    {
        public string JobId { get; set; }
        public string Reason { get; set; }
    }

    public class MoveJobRequest
    {
        public string JobId { get; set; }
        public string EquipmentId { get; set; }
        public string NewTargetYardBay { get; set; }
    }

    public class ClearanceRequest
    {
        public string AreaId { get; set; }
        public bool IsClearanceRequired { get; set; }
    }

    public class ChangeTargetRequest
    {
        public string JobId { get; set; }
        public string NewTargetId { get; set; }
    }

    // 응답 모델들
    public class AycJobResponse
    {
        public string msgId { get; set; }
        public string errCd { get; set; }
        public string errDesc { get; set; }
        //public DateTime EstimatedCompletionTime { get; set; }
    }

    public class GenericResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string TransactionId { get; set; }
    }


    //= Request Body Data Class (End)
    //=========================================================================




    // 서버 설정 및 실행 담당 클래스
    public class JsonRpcServer
    {
        private IWebHost _webHost;
        private CancellationTokenSource _cancellationTokenSource;

        public event Action<string> LogEvent;

        // 로그 메시지 발생 메서드
        private void Log(string message)
        {
            LogEvent?.Invoke(message);
            Console.WriteLine(message);
        }

        public void StartServer()
        {
            Task.Run(async () => {
                await this.StartAsync("http://0.0.0.0:8110");
            });
        }

        public void StopServer()
        {
            Task.Run(async () => {
                await this.StopAsync();
            });
        }
        


        // 서버 시작 메서드
        public async Task StartAsync(string url = "http://0.0.0.0:8110")
        {
            if (_webHost != null)
            {
                Log("서버가 이미 실행 중입니다.");
                return;
            }

            _cancellationTokenSource = new CancellationTokenSource();

            try
            {
                _webHost = CreateWebHostBuilder(url).Build();

                // 비동기로 서버 시작
                await _webHost.StartAsync(_cancellationTokenSource.Token);

                Log($"JSON-RPC 서버가 {url}에서 시작되었습니다.");
                Log("사용 가능한 엔드포인트:");
                Log("- /equipment/ayc-job");
            }
            catch (Exception ex)
            {
                Log($"서버 시작 중 오류 발생: {ex.Message}");
                throw;
            }
        }

        // 서버 중지 메서드
        public async Task StopAsync()
        {
            if (_webHost == null)
            {
                Log("서버가 실행 중이 아닙니다.");
                return;
            }

            try
            {
                await _webHost.StopAsync();
                _cancellationTokenSource.Cancel();
                _webHost.Dispose();
                _webHost = null;
                _cancellationTokenSource.Dispose();
                _cancellationTokenSource = null;

                Log("JSON-RPC 서버가 중지되었습니다.");
            }
            catch (Exception ex)
            {
                Log($"서버 중지 중 오류 발생: {ex.Message}");
                throw;
            }
        }

        // WebHost 빌더 생성 메서드 - ASP.NET Core 8.0 스타일로 수정
        private IWebHostBuilder CreateWebHostBuilder(string url)
        {
            return Microsoft.AspNetCore.WebHost.CreateDefaultBuilder()
                .UseUrls(url)
                .ConfigureServices(services => { })
                .Configure(app =>
                {
                    // 홈 페이지 경로 처리
                    app.Use(async (context, next) =>
                    {
                        if (context.Request.Path.Value == "/" || string.IsNullOrEmpty(context.Request.Path.Value))
                        {
                            context.Response.ContentType = "text/plain";
                            await context.Response.WriteAsync("AYC Job JSON-RPC 서버가 실행 중입니다.");
                            return;
                        }

                        // 다른 경로는 다음 미들웨어로 전달
                        await next();
                    });

                    // JSON-RPC 미들웨어 등록
                    app.UseMiddleware<JsonRpcMiddleware>();
                });
        }
    }


    // AYC Job 서비스 클래스
    public class AycJobService
    {
        public static string CurrentMsgId = "";
        public static string CurrentEqId = "";
        public static string CurrentjobId = "";
        public static string Current_cntrWgt = "";
        public static AycRmkLocation Current_PickupLoc = new AycRmkLocation() { loc1 = "BLOCK01", loc2 = "1", loc3 = "1", loc4 = "1", locTp = "YARD", rmk = "" };
        public static AycRmkLocation Current_Location = new AycRmkLocation() { loc1 = "BLOCK01", loc2 = "1", loc3 = "1", loc4 = "1", locTp = "YARD", rmk="" };

        private string _TOSServerUrl = "http://202.20.83.157:8110";


        // SendAycJob 처리
        public AycJobResponse ProcessAycJob(AycMsg_sendAycJob request)
        {
            Console.WriteLine($"AYC Job 요청 처리 중: JobId={request.head.msgId}, JobType={request.body.jobTp}, EquipmentId={request.body.eqId}");

            // Set Current Messag Id
            AycJobService.CurrentMsgId = request.head.msgId;
            AycJobService.CurrentEqId = request.body.eqId;
            AycJobService.CurrentjobId = request.body.jobId;
            AycJobService.Current_cntrWgt = request.body.cntrWgt;

            AycJobService.Current_PickupLoc.loc1 = request.body.pickupLoc.loc1;
            AycJobService.Current_PickupLoc.loc2 = request.body.pickupLoc.loc2;
            AycJobService.Current_PickupLoc.loc3 = request.body.pickupLoc.loc3;
            AycJobService.Current_PickupLoc.loc4 = request.body.pickupLoc.loc4;


            AycJobService.Current_Location.loc1 = request.body.setdownLoc.loc1;
            AycJobService.Current_Location.loc2 = request.body.setdownLoc.loc2;
            AycJobService.Current_Location.loc3 = request.body.setdownLoc.loc3;
            AycJobService.Current_Location.loc4 = request.body.setdownLoc.loc4;

            // 실제 비즈니스 로직 대신 샘플 응답
            return new AycJobResponse
            {
                msgId = request.head.msgId,
                errCd = "",
                errDesc = ""
            };
        }

        // SendAbortJob 처리
        public AycJobResponse ProcessAbortJob(AycMsg_sendAbortJob request)
        {
            Console.WriteLine($"Abort Job 요청 처리 중: JobId={request.head.msgId}, EquipmentId={request.body.eqId}");

            // Set Current Messag Id
            AycJobService.CurrentMsgId = request.head.msgId;
            AycJobService.CurrentEqId = request.body.eqId;
            AycJobService.CurrentjobId = request.body.jobId;


            // 실제 비즈니스 로직 대신 샘플 응답
            return new AycJobResponse
            {
                msgId = request.head.msgId,
                errCd = "",
                errDesc = ""
            };
        }

        // SendMoveJob 처리
        public AycJobResponse ProcessMoveJob(AycMsg_sendMoveJob request)
        {
            Console.WriteLine($"Move Job 요청 처리 중: JobId={request.head.msgId}, EquipmentId={request.body.eqId}");

            // Set Current Messag Id
            AycJobService.CurrentMsgId = request.head.msgId;
            AycJobService.CurrentEqId = request.body.eqId;
            AycJobService.CurrentjobId = request.body.jobId;
            AycJobService.Current_Location.loc1 = request.body.wrkLoc.loc1;
            AycJobService.Current_Location.loc2 = request.body.wrkLoc.loc2;
            AycJobService.Current_Location.loc3 = request.body.wrkLoc.loc3;
            AycJobService.Current_Location.loc4 = request.body.wrkLoc.loc4;


            // 실제 비즈니스 로직 대신 샘플 응답
            return new AycJobResponse
            {
                msgId = request.head.msgId,
                errCd = "",
                errDesc = ""
            };
        }

        // SendClearance 처리
        public AycJobResponse ProcessClearance(AycMsg_sendClearance request)
        {
            Console.WriteLine($"Clearance 요청 처리 중: JobId={request.head.msgId}, EquipmentId={request.body.eqId}");

            // Set Current Messag Id
            AycJobService.CurrentMsgId = request.head.msgId;
            AycJobService.CurrentEqId = request.body.eqId;
            AycJobService.CurrentjobId = request.body.jobId;
            AycJobService.Current_Location.loc1 = request.body.vehicleLoc.loc1;
            AycJobService.Current_Location.loc2 = request.body.vehicleLoc.loc2;
            AycJobService.Current_Location.loc3 = request.body.vehicleLoc.loc3;
            AycJobService.Current_Location.loc4 = request.body.vehicleLoc.loc4;


            // 실제 비즈니스 로직 대신 샘플 응답
            return new AycJobResponse
            {
                msgId = request.head.msgId,
                errCd = "",
                errDesc = ""
            };
        }

        // SendChangeTarget 처리
        public AycJobResponse ProcessChangeTarget(AycMsg_sendChangeTarget request)
        {
            Console.WriteLine($"Change Target 요청 처리 중: JobId={request.head.msgId}, EquipmentId={request.body.eqId}");

            // Set Current Messag Id
            AycJobService.CurrentMsgId = request.head.msgId;
            AycJobService.CurrentEqId = request.body.eqId;
            AycJobService.CurrentjobId = request.body.jobId;
            AycJobService.Current_Location.loc1 = request.body.vehicleLoc.loc1;
            AycJobService.Current_Location.loc2 = request.body.vehicleLoc.loc2;
            AycJobService.Current_Location.loc3 = request.body.vehicleLoc.loc3;
            AycJobService.Current_Location.loc4 = request.body.vehicleLoc.loc4;


            // 실제 비즈니스 로직 대신 샘플 응답
            return new AycJobResponse
            {
                msgId = request.head.msgId,
                errCd = "",
                errDesc = ""
            };
        }

        // SendChangeTarget 처리
        public AycJobResponse ProcessRequestCraneStatus(AycMsg_requestCraneStatus request)
        {
            Console.WriteLine($"Change Target 요청 처리 중: JobId={request.head.msgId}, EquipmentId={request.body.eqId}");

            // Set Current Messag Id
            AycJobService.CurrentMsgId = request.head.msgId;
            AycJobService.CurrentEqId = request.body.eqId;

            // 실제 비즈니스 로직 대신 샘플 응답
            return new AycJobResponse
            {
                msgId = request.head.msgId,
                errCd = "",
                errDesc = ""
            };
        }



    }


    // HTTP 요청을 처리하는 미들웨어
    public class JsonRpcMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly JsonSerializerOptions _jsonOptions;
        private readonly AycJobService _aycJobService;

        public JsonRpcMiddleware(RequestDelegate next)
        {
            _next = next;
            _aycJobService = new AycJobService();
            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                PropertyNameCaseInsensitive = true
            };
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Path.Value.StartsWith("/equipment/ayc-job") && !context.Request.Path.Value.StartsWith("/equipment/ayc-status"))
            {
                await _next(context);
                return;
            }

            // 요청 본문 읽기
            string requestBody;
            using (var reader = new StreamReader(context.Request.Body))
            {
                requestBody = await reader.ReadToEndAsync();
            }

            try
            {
                var rpcRequest = JsonSerializer.Deserialize<JsonRpcRequest>(requestBody, _jsonOptions);
                object result = null;

                // 요청 경로에 따라 적절한 처리 메서드 호출
                if (rpcRequest.Method.EndsWith("sendAycJob"))
                {
                    var parameters = JsonSerializer.Deserialize<AycMsg_sendAycJob[]>(
                        JsonSerializer.Serialize(rpcRequest.Params), _jsonOptions);
                    result = _aycJobService.ProcessAycJob(parameters[0]);
                }
                else if (rpcRequest.Method.EndsWith("sendAbortJob"))
                {
                    var parameters = JsonSerializer.Deserialize<AycMsg_sendAbortJob[]>(
                        JsonSerializer.Serialize(rpcRequest.Params), _jsonOptions);
                    result = _aycJobService.ProcessAbortJob(parameters[0]);
                }
                else if (rpcRequest.Method.EndsWith("sendMoveJob"))
                {
                    var parameters = JsonSerializer.Deserialize<AycMsg_sendMoveJob[]>(
                        JsonSerializer.Serialize(rpcRequest.Params), _jsonOptions);
                    result = _aycJobService.ProcessMoveJob(parameters[0]);
                }
                else if (rpcRequest.Method.EndsWith("sendClearance"))
                {
                    var parameters = JsonSerializer.Deserialize<AycMsg_sendClearance[]>(
                        JsonSerializer.Serialize(rpcRequest.Params), _jsonOptions);
                    result = _aycJobService.ProcessClearance(parameters[0]);
                }
                else if (rpcRequest.Method.EndsWith("sendChangeTarget"))
                {
                    var parameters = JsonSerializer.Deserialize<AycMsg_sendChangeTarget[]>(
                        JsonSerializer.Serialize(rpcRequest.Params), _jsonOptions);
                    result = _aycJobService.ProcessChangeTarget(parameters[0]);
                }
                else if (rpcRequest.Method.EndsWith("requestCraneStatus"))
                {
                    var parameters = JsonSerializer.Deserialize<AycMsg_requestCraneStatus[]>(
                        JsonSerializer.Serialize(rpcRequest.Params), _jsonOptions);
                    result = _aycJobService.ProcessRequestCraneStatus(parameters[0]);
                                            
                }
                else
                {
                    await _next(context);
                    return;
                }

                // JSON-RPC 응답 생성
                var rpcResponse = new JsonRpcResponse
                {
                    Result = result,
                    Id = rpcRequest.Id,
                    Jsonrpc = "2.0"
                };

                // 응답 전송
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(JsonSerializer.Serialize(rpcResponse, _jsonOptions));
            }
            catch (Exception ex)
            {
                // 오류 처리
                var errorResponse = new JsonRpcResponse
                {
                    Error = new JsonRpcError
                    {
                        Code = -32603, // Internal error
                        Message = ex.Message,
                        Data = ex.StackTrace
                    },
                    Id = null, // 요청 ID를 파싱하지 못했을 수 있음
                    Jsonrpc = "2.0"
                };

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse, _jsonOptions));
            }
        }
    }
}