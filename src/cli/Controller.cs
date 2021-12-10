using cli.Model;
using System;
using System.Collections.Generic;

public static partial class Program
{
    public class Controller
    {
        private readonly ITodoListReader _reader;

        public Controller(ITodoListReader reader)
        {
            _reader = reader;
        }

        public List<Todo> HandleCommand(string command)
        {
            return ReadAll();
        }

        private List<Todo> ReadAll() => _reader.ReadAll();
    }
}