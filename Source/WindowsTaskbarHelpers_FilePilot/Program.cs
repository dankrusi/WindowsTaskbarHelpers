using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsTaskbarHelpers_Explorer
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Get arguments
            var args = Environment.GetCommandLineArgs().Skip(1);

            // Open fpilot
            Process.Start("fpilot.exe", string.Join(" ", args));
        }
    }
}
