using cli.Model;
using System.Collections.Generic;

namespace cli.test.UnitTest
{
    public class FakeWriter : ITodoListWriter
    {
        public bool Called { get; private set; } = false;

        public List<Todo> LstTodos { get; private set; }

        public void WriteAll(List<Todo> lstTodos)
        {
            LstTodos = lstTodos;
            Called = true;
        }
    }

}
