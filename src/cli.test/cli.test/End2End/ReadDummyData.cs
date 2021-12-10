using cli.Model;
using FluentAssertions;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace cli.test.End2End
{
    [TestFixture]
    public class ReadDummyData
    {
        readonly StringWriter _writer = new();
        private string _sutResult;

        [SetUp]
        public void Setup()
        {
            var todo = new Todo() { Id = 1, Title = "Dummy", IsCompleted = false };
            File.WriteAllText(@"c:\todo.json", JsonConvert.SerializeObject(todo));
        }


        [Test]
        public void ShowTodos()
        {
            RunSut(string.Empty);
            _sutResult.Should().Be("1 Dummy false");
        }


        private void RunSut(string args)
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

            try
            {
                // start with the info we specified.
                using Process process = Process.Start(startInfo);
                // Redirect stdout to reader
                using (StreamReader reader = process.StandardOutput)
                {
                    _sutResult = reader.ReadToEnd();
                }

                process.WaitForExit();
            }
            catch(Exception ex)
            {
                // Log error.
                Assert.Fail(ex.ToString());
            }
        }
    }
}
