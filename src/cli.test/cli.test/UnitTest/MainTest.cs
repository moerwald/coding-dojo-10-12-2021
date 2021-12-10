using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cli.test.UnitTest
{
    [TestFixture]
    public class MainTest
    {
        StringWriter _stringWriter = new StringWriter();

        [SetUp]
        public void Setup()
        {
            System.Console.SetOut(_stringWriter);
            File.WriteAllText(@"c:\todo_MainTest.json", "[{\"Id\":1,\"Title\":\"Dummy\",\"IsCompleted\":false}, {\"Id\":2,\"Title\":\"Dummy2\",\"IsCompleted\":false}]");
        }

        [Test]
        public void TestReadAll()
        {
            Program.JsonFilePath = @"c:\todo_MainTest.json";
            Program.Main(new[] { "ShowAll" });
            _stringWriter.ToString().Should().Be($"1 Dummy False{Environment.NewLine}2 Dummy2 False{Environment.NewLine}");
        }
    }
}
