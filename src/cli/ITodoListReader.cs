using cli.Model;
using System.Collections.Generic;

public interface ITodoListReader
{
    List<Todo> ReadAll();
}