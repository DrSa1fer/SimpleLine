using SimpleLineLibrary;
using SimpleLineLibrary.User.Commands;
using System.Reflection;

internal class Program
{
    private static void Main(string[] args)
    {
        var simp = new SimpleLine(new()).Run(
            new List<string>() 
            {
                "conf", "--edit",
                "-a", "meow",
                "-a", "test",
                "-a", "world!",
                "-a", "Hello",
                "-a", "Fuck",
                "-a", "_main_"
            }, 
            typeof(TestCommand).GetTypeInfo(), 
            typeof(ConfigCommand).GetTypeInfo());
    }
}