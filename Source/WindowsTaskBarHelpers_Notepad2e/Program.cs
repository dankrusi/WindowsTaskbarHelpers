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
            // Check if shift key is pressed
            if (Control.ModifierKeys == Keys.Shift) { 
                // Elevate as admin
                var processInfo = new ProcessStartInfo {
                    UseShellExecute = true,
                    WorkingDirectory = Environment.CurrentDirectory,
                    FileName = Application.ExecutablePath,
                    Arguments = string.Join(" ", Environment.GetCommandLineArgs().Skip(1)),
                    Verb = "runas"
                };
                try {
                    Process.Start(processInfo);
                }
                catch (Exception) {
                    // The user refused to allow privileges elevation.
                    // Do nothing and return directly ...
                    return;
                }
                return;
            }

            // Get arguments
            var args = Environment.GetCommandLineArgs().Skip(1);

            // Open program
            Process.Start("notepad2.exe", string.Join(" ", args));
        }
    }
}
