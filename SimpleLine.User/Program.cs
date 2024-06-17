using SimpleLineLibrary;
using SimpleLineLibrary.User.Commands;
using System.Collections;
using System.Reflection;

internal class Program
{
    private static void Main(string[] args)
    {

        var simp = new SimpleLine(new());

        var res = simp.Run(new List<string>()
        {
                //"file", "--read", "-p", "C:\\Users\\Данил\\OneDrive\\Рабочий стол\\Идеи проектов\\PhysicProject.txt"
            "math", "--multiply", "10", "20"
        }, typeof(Program).Assembly);

        Console.WriteLine(res);
    }
}