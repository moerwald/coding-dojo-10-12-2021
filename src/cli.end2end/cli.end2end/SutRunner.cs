using NUnit.Framework;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace TodoApp.End2EndTests
{
    public static class SutRunner
    {
        public static string Run(string args)
        {
            // use ProcessStartInfo class.
            ProcessStartInfo startInfo = new()
            {
                CreateNoWindow = false,
                UseShellExecute = false
            };

            // Get path to exe
            var pathToTestDll = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var pathToExt = Path.Combine(pathToTestDll, @"..\..\..\..\..\cli\bin\Debug\net5.0\cli.exe");
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                pathToExt = Path.Combine(pathToTestDll, @"..\..\..\..\..\cli\bin\Debug\net5.0\ubuntu-x64\publish\cli");
            }

            startInfo.FileName = pathToExt;

            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.RedirectStandardOutput = true;

            // set arguments.
            startInfo.Arguments = args;

            var processStdout = string.Empty;
            try
            {
                // start with the info we specified.
                using Process process = Process.Start(startInfo);
                // Redirect stdout to reader
                using (StreamReader reader = process.StandardOutput)
                {
                    processStdout = reader.ReadToEnd();
                }

                process.WaitForExit();
            }
            catch (Exception ex)
            {
                // Log error.
                Assert.Fail(ex.ToString());
            }

            return processStdout;
        }
    }
}
