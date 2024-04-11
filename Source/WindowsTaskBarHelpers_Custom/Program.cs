using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsTaskbarHelpers_Notepad
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
            var app = Environment.GetCommandLineArgs().Skip(1).Take(1).Single();
            var args = Environment.GetCommandLineArgs().Skip(2);

            // Open program
            Process.Start(app, string.Join(" ", args));
        }
    }
}
