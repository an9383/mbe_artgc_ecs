using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Middleware.ActiveMQ
{
    public static class ExceptionHelper
    {
        public static string FormatExceptionDetails(Exception ex)
        {
            // 기본 예외 메시지
            string message = $"Exception Message: {ex.Message}";

            // StackTrace 객체 생성 (true: 파일/라인 정보 포함하려면 PDB 필요)
            var st = new StackTrace(ex, true);
            var frame = st.GetFrame(st.FrameCount-1); // 예외가 처음 발생한 프레임

            if (frame != null)
            {
                string file = frame.GetFileName();      // 파일 경로
                int line = frame.GetFileLineNumber();   // 라인 번호
                int column = frame.GetFileColumnNumber(); // 컬럼 번호 (선택)

                message += $"\nFile: {file}";
                message += $"\nLine: {line}";
                message += $"\nColumn: {column}";
            }

            message += $"\nStackTrace:\n{ex.StackTrace}";
            return message;
        }
    }
}
