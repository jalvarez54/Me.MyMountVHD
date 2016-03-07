using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WindowsService
{
    public partial class MyMountVHDService : ServiceBase
    {
        public MyMountVHDService()
        {
            InitializeComponent();
            Init();
        }

        private static Process myProcess = new Process();
        private static System.Diagnostics.EventLog eventLog;
        private static string vhdFolder = System.Configuration.ConfigurationManager.AppSettings.Get("vhdFolder");
        private static string diskpartArgument = string.Format(@"{0}\MountMyVHDs.txt", vhdFolder);
        private static string logFile = string.Format(@"{0}\MountMyVHDs.log", vhdFolder);

        public static void Init()
        {
            eventLog = new System.Diagnostics.EventLog();

            if (!System.Diagnostics.EventLog.SourceExists("MyMountVHDWindowsServiceSource"))
            {
                System.Diagnostics.EventLog.CreateEventSource(
                   "MyMountVHDWindowsServiceSource", "MyMountVHDWindowsServiceLog");
            }
            eventLog.Source = "MyMountVHDWindowsServiceSource";
            eventLog.Log = "MyMountVHDWindowsServiceLog";
        }


        protected override void OnStart(string[] args)
        {
            MyTrace("Begin");
            ExecuteCommand();
            myProcess.Close();

        }

        protected override void OnStop()
        {
            MyTrace("End");
        }


        /// <summary>
        /// Unique execute command.
        /// </summary>
        /// <param name="arguments"></param>
        /// <returns></returns>
        private static void ExecuteCommand()
        {
            try
            {
                myProcess.StartInfo.FileName = "cmd.exe";
                myProcess.StartInfo.UseShellExecute = false;
                myProcess.StartInfo.Arguments = @"/c diskpart /s " + diskpartArgument;
                myProcess.StartInfo.RedirectStandardOutput = true;
                myProcess.StartInfo.StandardOutputEncoding = System.Text.Encoding.GetEncoding(850);

                myProcess.Start();

                string error = myProcess.StandardOutput.ReadToEnd();
                System.IO.File.WriteAllText(logFile, error);
                myProcess.WaitForExit();
                MyTrace("diskpart Return= " + error);
            }
            catch (Exception ex)
            {
                MyTrace(ex.Message);
            }

            MyTrace(myProcess.ExitCode.ToString());

        }

        private static void MyTrace(string message)
        {
            StackTrace stackTrace = new StackTrace();
            StackFrame stackFrame = stackTrace.GetFrame(1);
            MethodBase methodBase = stackFrame.GetMethod();

            eventLog.WriteEntry(string.Format("{0}: {1}", methodBase, message));

        }

    }
}
