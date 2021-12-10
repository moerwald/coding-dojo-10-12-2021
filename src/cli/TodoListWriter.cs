
using cli.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

public static partial class Program
{
    public class TodoListWriter : ITodoListWriter
    {
        private string filepath;

        public TodoListWriter(string filepath)
        {
            this.filepath = filepath ?? throw new NullReferenceException(nameof(filepath));
        }

        public void WriteAll(List<Todo> lstTodos)
        {
            File.WriteAllText(filepath, JsonConvert.SerializeObject(lstTodos));
        }
    }

}