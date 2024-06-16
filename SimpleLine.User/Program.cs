using SimpleLineLibrary;
using SimpleLineLibrary.User.Commands;
using System.Reflection;

internal class Program
{
    private static void Main(string[] args)
    {
        var simp = new SimpleLine(new()).Run(
            new List<string>() {
                "test",
                "--test",
                "-m",
                "bye world!"
            }, 
            typeof(TestCommand).GetTypeInfo(), 
            typeof(ConfigCommand).GetTypeInfo());
    }
}