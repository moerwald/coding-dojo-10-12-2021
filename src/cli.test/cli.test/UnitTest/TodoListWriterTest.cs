using cli.Model;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Program;
using System.IO;
using Newtonsoft.Json;

namespace cli.test.UnitTest
{
    [TestFixture]
    public class TodoListWriterTest
    {

        [Test]
        public void Write()
        {
            var filePath = @"C:\todo_ListWriter.json";
            TodoListWriter writer = new TodoListWriter(filePath);

            var lstTodos = new List<Todo>
            {
                new Todo{ Id = 1, Title = "Dummy", IsCompleted = false},
                new Todo{ Id = 2, Title = "Dummy2", IsCompleted = false}
            };

            writer.WriteAll(lstTodos);

            // Read written stuff and assert
            var actTodoList = JsonConvert.DeserializeObject<List<Todo>>(File.ReadAllText(filePath));
            actTodoList.Should().BeEquivalentTo(lstTodos);
        }
    }
}
