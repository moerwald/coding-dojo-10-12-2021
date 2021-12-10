using System;

public static partial class Program
{
    public static string JsonFilePath = @"C:\todo.json";
        
    public static void Main(string[] args)
    {

        var controller = new Controller(new TodoListReader(JsonFilePath));
        var listOfTodos = controller.HandleCommand(args[0]);

        var listOfString = new TodoFormater().Format(listOfTodos);

        foreach (var item in listOfString)
        {
            Console.WriteLine(item);
        }
    }

}