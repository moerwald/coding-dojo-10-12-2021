using System.Collections.Generic;
using TodoApp.Model;

namespace TodoApp
{
    public interface ITodoListReader
    {
        List<Todo> ReadAll();
    }
}