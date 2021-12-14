using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using TodoApp.Model;

namespace TodoApp.Tests.UnitTest
{
    [TestFixture]
    public class TodoListWriterTest
    {

        [Test]
        public void Write()
        {
            var filePath = @"C:\todo_ListWriter.json";
            TodoListWriter writer = new(filePath);

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
