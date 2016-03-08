using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication
{
    static class Program
    {
        public static bool IsConsole = false;

        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                IsConsole = true;
                Helper.AllocConsole();
                ConsoleWork(args);
                Helper.FreeConsole();
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FormMain());
            }
        }

        static void ConsoleWork(string[] args)
        {
            FormMain formMain = new FormMain();
            formMain.Initialization();
            switch (args[0])
            {
                case "-attach":
                    try
                    {
                        formMain.Attach();

                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }
                    break;
                case "-detach":
                    try
                    {
                        formMain.Detach();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                default:
                    Console.WriteLine("Error: params= -attach or -detach");
                    break;
            }

            Console.ReadKey();

        }
    }

    static class Helper
    {

        [DllImport("kernel32.dll")]
        public static extern Boolean AllocConsole();

        [DllImport("kernel32.dll")]
        public static extern Boolean FreeConsole();
    }
}
