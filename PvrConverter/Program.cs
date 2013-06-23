using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PvrConverter
{
    static class Program
    {
        [DllImport("kernel32.dll")]
        static extern bool FreeConsole();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Do we have any command line arguments?
            if (args.Length != 0)
            {
                // Arguments are present. The form will close itself and
                // leave only the command line available.
                Application.Run(new MainForm(args));
            }
            else
            {
                // We want a GUI, so detatch from the console to hide it.
                FreeConsole();
                Application.Run(new MainForm());
            }
        }
    }
}
