using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace WindowsTaskbarHelpers_Zed
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

            // Open Zed from its per-user installation directory
            var zedPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "Programs",
                "Zed",
                "Zed.exe");
            Process.Start(zedPath, string.Join(" ", args));
        }
    }
}
