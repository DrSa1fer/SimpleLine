using System.Diagnostics;
using SimpleLineLibrary;

internal class Program
{
    private static void Main(string[] args)
    {
        var s = new Stopwatch();

        s.Start();
        var conf = Configuration.Default(typeof(Program).Assembly);

        SimpleLine.Build(conf).Run(new string[] { "test", "test", "test", "test", "foo", "100", "&", "nknkjj", "&", "asfsdff", "&", "World", "&", "nknk" });

        s.Stop();

        System.Console.WriteLine(s.Elapsed);
    }   
}