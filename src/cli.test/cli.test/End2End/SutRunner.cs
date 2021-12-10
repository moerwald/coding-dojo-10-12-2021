using NUnit.Framework;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace cli.test.End2End
{
    public partial class ReadDummyData
    {
        public class SutRunner
        {
            public string RunSut(string args)
            {
                // use ProcessStartInfo class.
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.CreateNoWindow = false;
                startInfo.UseShellExecute = false;

                // Get path to exe
                var pathToTestDll = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                var pathToExt = Path.Combine(pathToTestDll, @"..\..\..\..\..\cli\bin\Debug\net5.0\cli.exe");
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
}
