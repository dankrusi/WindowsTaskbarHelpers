using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace WindowsTaskbarHelpers_Blender
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

            // Open the latest installed Blender version
            var blenderPath = FindLatestBlender();
            if (blenderPath == null) return;
            Process.Start(blenderPath, string.Join(" ", args));
        }

        /// <summary>
        /// Blender installs itself into a versioned directory (eg "Blender Foundation\Blender 4.3"),
        /// so we scan the usual install roots and pick the highest version we can find.
        /// </summary>
        private static string FindLatestBlender()
        {
            // Note: this helper runs as a 32bit process, where SpecialFolder.ProgramFiles points at
            // "Program Files (x86)". ProgramW6432 always gives us the real 64bit Program Files.
            var roots = new[]
            {
                Environment.GetEnvironmentVariable("ProgramW6432"),
                Environment.GetEnvironmentVariable("ProgramFiles"),
                Environment.GetEnvironmentVariable("ProgramFiles(x86)"),
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Programs")
            }.Where(root => !string.IsNullOrEmpty(root));

            string bestPath = null;
            Version bestVersion = null;

            foreach (var root in roots.Distinct()) {
                var foundation = Path.Combine(root, "Blender Foundation");
                if (!Directory.Exists(foundation)) continue;

                foreach (var dir in Directory.GetDirectories(foundation, "Blender*")) {
                    // Prefer the launcher, it starts Blender without a console window
                    var exe = new[] { "blender-launcher.exe", "blender.exe" }
                        .Select(name => Path.Combine(dir, name))
                        .FirstOrDefault(File.Exists);
                    if (exe == null) continue;

                    var version = ParseVersion(Path.GetFileName(dir));
                    if (bestVersion == null || version > bestVersion) {
                        bestVersion = version;
                        bestPath = exe;
                    }
                }
            }

            return bestPath;
        }

        /// <summary>
        /// Pulls the version out of a directory name such as "Blender 4.3", falling back to 0.0
        /// for unversioned installs so that any versioned install wins.
        /// </summary>
        private static Version ParseVersion(string directoryName)
        {
            var match = Regex.Match(directoryName, @"(\d+)(?:\.(\d+))?(?:\.(\d+))?");
            if (!match.Success) return new Version(0, 0);
            var major = int.Parse(match.Groups[1].Value);
            var minor = match.Groups[2].Success ? int.Parse(match.Groups[2].Value) : 0;
            var build = match.Groups[3].Success ? int.Parse(match.Groups[3].Value) : 0;
            return new Version(major, minor, build);
        }
    }
}
