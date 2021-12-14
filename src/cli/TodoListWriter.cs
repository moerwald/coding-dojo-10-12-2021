using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using TodoApp.Model;

namespace TodoApp
{
    public class TodoListWriter : ITodoListWriter
    {
        private readonly string _filepath;

        public TodoListWriter(string filepath) 
            => 
            _filepath = filepath ?? throw new NullReferenceException(nameof(filepath));

        public void WriteAll(List<Todo> lstTodos) 
            => 
            File.WriteAllText(_filepath, JsonConvert.SerializeObject(lstTodos));
    }

}