using cli.Model;
using FluentAssertions;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cli.test.End2End
{
    [TestFixture]
    public class ReadDummyData
    {
        readonly StringWriter _writer = new();

        [SetUp]
        public void Setup()
        {
            var todo = new Todo() { Id = 1, Title = "Dummy", IsCompleted = false };
            File.WriteAllText(@"c:\todo.json", JsonConvert.SerializeObject(todo));
            Console.SetOut(_writer);
        }


        [Test]
        public void ShowTodos()
        {
            Program.Main(new[] { "Show" });
            var output = _writer.ToString();
            output.Should().Be("1 Dummy false");
        }
    }
}
