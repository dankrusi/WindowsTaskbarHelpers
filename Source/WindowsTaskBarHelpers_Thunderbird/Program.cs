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
            var args = new[]
            {
                "--chrome",
                "chrome://messenger/content/messenger.xhtml"
            }.Concat(Environment.GetCommandLineArgs().Skip(1));

            // Open a new Thunderbird window
            Process.Start("thunderbird.exe", string.Join(" ", args));
        }
    }
}
