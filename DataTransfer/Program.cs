using System;

using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace DataTransfer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool instanceCountOne = false;

            Process[] p = System.Diagnostics.Process.GetProcessesByName("htas");

            if (p.Length == 0)
            {


                Application.Exit();
                return;


            }

            using (Mutex mtex = new Mutex(true, "DataTransferwithoutTm", out instanceCountOne))
            {
                if (instanceCountOne)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new AdminPanel());
                    mtex.ReleaseMutex();
                }
                else
                {
                    MessageBox.Show("An application instance is already running");
                }
            }
        }
    }
}
