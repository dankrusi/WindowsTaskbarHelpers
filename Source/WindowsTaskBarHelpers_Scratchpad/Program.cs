using System;
using System.Diagnostics;
using System.Linq;

namespace WindowsTaskbarHelpers_Scratchpad
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

            // Open program
            Process.Start("scratchpad.exe", string.Join(" ", args));
        }
    }
}
