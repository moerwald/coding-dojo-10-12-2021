
using cli.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public static partial class Program
{
    public class TodoListReader : ITodoListReader
    {
        private string filepath;

        public TodoListReader(string filepath)
        {
            this.filepath = filepath ?? throw new NullReferenceException(nameof(filepath));

            // Todo check for existense
        }

        public List<Todo> ReadAll() =>
            JsonConvert.DeserializeObject<List<Todo>>(File.ReadAllText(this.filepath));
    }
}