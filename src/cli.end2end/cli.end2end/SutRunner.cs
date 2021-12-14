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
                UseShellExecute = false
            };

            // Get path to exe
            var pathToTestDll = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string pathToExt = string.Empty;
            
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                startInfo.CreateNoWindow = false;
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;

                pathToExt = Path.Combine(pathToTestDll, @"..\..\..\..\..\cli\bin\Debug\net5.0\TodoApp.exe");
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                pathToExt = Path.Combine(pathToTestDll, @"..\..\..\..\..\cli\bin\Debug\net5.0\ubuntu-x64\publish\TodoApp");
            }

            startInfo.FileName = pathToExt;

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
