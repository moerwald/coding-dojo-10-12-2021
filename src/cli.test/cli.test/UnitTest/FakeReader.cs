using cli.Model;
using System.Collections.Generic;

namespace cli.test.UnitTest
{
    public class FakeReader : ITodoListReader
    {
        public List<Todo> ReadAll() 
            => 
            new List<Todo> { new Todo { Id = 1, IsCompleted = false, Title = "Dummy" } };
    }
}
