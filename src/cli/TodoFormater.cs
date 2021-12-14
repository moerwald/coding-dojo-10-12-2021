using System;
using System.Collections.Generic;
using TodoApp.Model;

namespace TodoApp
{
    public class TodoFormater
    {
        public static IEnumerable<string> Format(List<Todo> todoLst)
        {
            foreach (var item in todoLst)
            {
                yield return $"{item.Id} {item.Title} {item.IsCompleted}";
            }
        }
    }
}