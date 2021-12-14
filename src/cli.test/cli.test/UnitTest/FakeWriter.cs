using System.Collections.Generic;
using TodoApp.Model;

namespace TodoApp.Tests.UnitTest
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
