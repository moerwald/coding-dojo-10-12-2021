using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using TodoApp.Model;

namespace TodoApp
{

    public class TodoListReader : ITodoListReader
    {
        private readonly string _filepath;

        public TodoListReader(string filepath) => _filepath = filepath ?? throw new NullReferenceException(nameof(filepath));

        public List<Todo> ReadAll() =>
            JsonConvert.DeserializeObject<List<Todo>>(File.ReadAllText(_filepath));
    }
}
