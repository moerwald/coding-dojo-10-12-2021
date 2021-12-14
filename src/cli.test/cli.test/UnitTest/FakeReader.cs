using System.Collections.Generic;
using TodoApp.Model;

namespace TodoApp.Tests.UnitTest
{
    public class FakeReader : ITodoListReader
    {
        public List<Todo> ReadAll()
            =>
            new() { new Todo { Id = 1, IsCompleted = false, Title = "Dummy" } };
    }
}
