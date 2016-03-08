using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VHDLib;

namespace WindowsFormsApplication
{


    public partial class FormMain : Form
    {
        private VHDLibrary vhdLibrary;
        private static string vhdFolder = System.Configuration.ConfigurationManager.AppSettings.Get("vhdFolder");
        private static string vhdFiles = System.Configuration.ConfigurationManager.AppSettings.Get("vhdFiles");
        private static string[] vhdFileList;

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            Initialization();
        }

        private void buttonAttach_Click(object sender, EventArgs e)
        {
            Attach();
        }

        private void buttonDetach_Click(object sender, EventArgs e)
        {
            Detach();
        }

        public void Initialization()
        {
            vhdFileList = vhdFiles.Split(',');
            vhdLibrary = new VHDLibrary();
        }
        public void Attach()
        {
            foreach (var item in vhdFileList)
            {
                FileInfo vhdFile = new FileInfo(string.Format(@"{0}\{1}.vhd", vhdFolder, item));
                if (vhdFile.Exists)
                {
                    try
                    {
                        vhdLibrary.Attach(vhdFile);
                        MyTrace(vhdFile.Name);

                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }

        public void Detach()
        {
            foreach (var item in vhdFileList)
            {
                FileInfo vhdFile = new FileInfo(string.Format(@"{0}\{1}.vhd", vhdFolder, item));
                if (vhdFile.Exists)
                {
                    try
                    {
                        vhdLibrary.Detach(vhdFile);
                        MyTrace(vhdFile.Name);


                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }

        }

        private void MyTrace(string message)
        {
            StackTrace stackTrace = new StackTrace();
            StackFrame stackFrame = stackTrace.GetFrame(1);
            MethodBase methodBase = stackFrame.GetMethod();

            string messageToShow = string.Format("{0}: {1} ==> {2}\r\n", DateTime.Now, methodBase, message);

            if (!Program.IsConsole)
            {
                textBoxMessage.Text += messageToShow;
            }
            else
            {
                Console.WriteLine(messageToShow);
            }
        }
    }
}
