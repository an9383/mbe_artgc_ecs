using System;

namespace KR.MBE.CommonLibrary
{
    /// <summary>
    /// LogManager에 대한 요약 설명입니다.
    /// </summary>
    public class Log
    {

        private static readonly log4net.ILog m_log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Default 생성자
        /// </summary>
        public Log()
        {
        }

        public static void InfoLog(String sLogMessage)
        {
            m_log.Info(sLogMessage);
            System.Diagnostics.Debug.WriteLine("[Info] " + sLogMessage);
        }

        public static void DebugLog(String sLogMessage)
        {
            m_log.Debug(sLogMessage);
            System.Diagnostics.Debug.WriteLine("[Debug] " + sLogMessage);
        }

        public static void ErrorLog(String sLogMessage)
        {
            m_log.Error(sLogMessage);
            System.Diagnostics.Debug.WriteLine("[Error] " + sLogMessage);
        }

        public static void FatalLog(String sLogMessage)
        {
            m_log.Fatal(sLogMessage);
            System.Diagnostics.Debug.WriteLine("[Fatal] " + sLogMessage);
        }

        public static void WarningLog(String sLogMessage)
        {
            m_log.Warn(sLogMessage);
            System.Diagnostics.Debug.WriteLine("[Warning] " + sLogMessage);
        }


    }

}
