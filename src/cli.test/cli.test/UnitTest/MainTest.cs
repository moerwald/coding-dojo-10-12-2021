using FluentAssertions;
using NUnit.Framework;
using System;
using System.IO;

namespace TodoApp.Tests.UnitTest
{
    [TestFixture]
    public class MainTest
    {
        readonly StringWriter _stringWriter = new();

        [SetUp]
        public void Setup()
        {
            Console.SetOut(_stringWriter);
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
