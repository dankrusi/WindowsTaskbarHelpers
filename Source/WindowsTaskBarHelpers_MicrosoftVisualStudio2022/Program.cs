using Microsoft.Win32;
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

            var vsPath = "devenv.exe";
            try {
                vsPath = GetVisualStudio2022Path();
            } catch(Exception ex) {
                
            }
            // Open program
            //TODO: use vswhere.exe https://stackoverflow.com/questions/847048/finding-the-path-where-visual-studio-is-installed
            Process.Start("C:\\Program Files\\Microsoft Visual Studio\\2022\\Community\\Common7\\IDE\\devenv.exe", string.Join(" ", args));
        }

        static string GetVisualStudio2022Path() {
            const string vs2022RegistryKey = @"SOFTWARE\Microsoft\VisualStudio\SxS\VS7";
            const string vs2022Edition = "17.0"; // This refers to Visual Studio 2022

            // Open the registry key for Visual Studio 2022
            using(RegistryKey key = Registry.LocalMachine.OpenSubKey(vs2022RegistryKey)) {
                if(key != null) {
                    // Attempt to get the installation path for version 17.0 (Visual Studio 2022)
                    string installPath = key.GetValue(vs2022Edition) as string;
                    return installPath;
                }
            }

            return null; // Visual Studio 2022 not found
        }
    }
}
