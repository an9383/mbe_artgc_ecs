using System;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ARTGC
{
   

    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Set Global Exception Handler
            Application.ThreadException += Application_ThreadException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = e.ExceptionObject as Exception;
            MessageBox.Show("Non-UI Thread Exception:\n" + ex?.Message, "Unhandled Domain Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            MessageBox.Show("UI Thread Exception:\n" + e.Exception.Message, "Unhandled UI Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}