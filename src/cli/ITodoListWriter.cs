using cli.Model;
using System.Collections.Generic;

public interface ITodoListWriter
{
    void WriteAll(List<Todo> lstTodos);
}