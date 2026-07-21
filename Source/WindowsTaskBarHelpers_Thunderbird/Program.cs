using System;
using System.Diagnostics;
using System.Linq;

namespace WindowsTaskbarHelpers_Thunderbird
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

            // Open Thunderbird
            Process.Start("thunderbird.exe", string.Join(" ", args));
        }
    }
}
