using System;
using System.Collections.Generic;
using System.Linq;
using TodoApp.Model;

namespace TodoApp
{
    public class Controller
    {
        private readonly ITodoListReader _reader;
        private readonly ITodoListWriter _writer;

        public Controller(ITodoListReader reader, ITodoListWriter writer)
        {
            _reader = reader;
            _writer = writer;
        }

        public List<Todo> HandleCommand(string command, string? title = null)
            => command switch
            {
                "ShowAll" => ReadAll(),
                "Add" => Add(title),
                _ => throw new NotImplementedException()
            };

        private List<Todo> Add(string title)
        {
            var todos = _reader.ReadAll();
            var actId = todos.OrderBy(t => t.Id).Last()?.Id ?? 0;

            var actTodo = new Todo { Id = ++actId, Title = title, IsCompleted = false };

            todos.Add(actTodo);

            _writer.WriteAll(todos);
            return new List<Todo> { actTodo };
        }

        private List<Todo> ReadAll() => _reader.ReadAll();
    }
}