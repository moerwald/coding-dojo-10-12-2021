using System.Collections.Generic;
using TodoApp.Model;

namespace TodoApp
{
    public interface ITodoListWriter
    {
        void WriteAll(List<Todo> lstTodos);
    }
}