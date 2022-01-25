using System;
using System.Runtime.InteropServices;

namespace TodoApp
{
    public static class Program
    {
        public static string JsonFilePath = @"C:\todo.json";

        public static void Main(string[] args)
        {

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                JsonFilePath = @"/tmp/todo.json";
            }

            // Test comment
            

            var controller = new Controller(
                new TodoListReader(JsonFilePath),
                new TodoListWriter(JsonFilePath));

            var listOfTodos = controller.HandleCommand(args[0]);

            var listOfString = TodoFormater.Format(listOfTodos);

            foreach (var item in listOfString)
            {
                Console.WriteLine(item);
            }
        }
    }
}