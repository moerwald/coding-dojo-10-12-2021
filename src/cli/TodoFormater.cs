using cli.Model;
using System;
using System.Collections.Generic;

public static partial class Program
{
    public class TodoFormater
    {

        public TodoFormater()
        {
        }

        public IEnumerable<string> Format(List<Todo> todoLst)
        {
            foreach (var item in todoLst)
            {
                yield return $"{item.Id} {item.Title} {item.IsCompleted}" ;
            }
        }
    }
}