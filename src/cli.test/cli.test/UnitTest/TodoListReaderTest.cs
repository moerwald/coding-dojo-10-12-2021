using cli.Model;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Program;

namespace cli.test.UnitTest
{
    [TestFixture]
    public class TodoListReaderTest
    {
        private string _filepath;

        [SetUp]
        public void Setup()
        {
            _filepath = @"c:\todo_ConvertFileEntriesToObjects.json";
            File.WriteAllText(_filepath, "[{\"Id\":1,\"Title\":\"Dummy\",\"IsCompleted\":false}, {\"Id\":2,\"Title\":\"Dummy2\",\"IsCompleted\":false}]");
        }

        [Test]
        public void ConvertFileEntriesToObjects_Should_ParseFileCorrecty()
        {
            TodoListReader reader = new TodoListReader(_filepath);
            List<Todo> todos = reader.ReadAll();

            todos.Should().HaveCount(2);

            todos.Should().BeEquivalentTo(
                new List<Todo>
                {
                    new Todo {Id = 1, Title = "Dummy", IsCompleted = false},
                    new Todo {Id = 2, Title = "Dummy2", IsCompleted = false}
                }
                );
        }

        [Test]
        public void ConvertFileEntriesToObjects_FileIsEmpty_DontFail()
        {
            var emptyPath = @"c:\todo_ConvertFileEntriesToObjects.json";
            File.WriteAllText(emptyPath, "[]");

            TodoListReader reader = new TodoListReader(_filepath);
            IEnumerable<Todo> todos = reader.ReadAll();
            todos.Should().HaveCount(0);
        }
    }
}
