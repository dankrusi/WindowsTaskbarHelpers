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
            var args = Environment.GetCommandLineArgs().Skip(1);

            // Open program
            //TODO: use vswhere.exe https://stackoverflow.com/questions/847048/finding-the-path-where-visual-studio-is-installed
            Process.Start("C:\\Program Files (x86)\\Microsoft Visual Studio\\2019\\Community\\Common7\\IDE\\devenv.exe", string.Join(" ", args));
        }
    }
}
