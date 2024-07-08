using SimpleLineLibrary;
using SimpleLineLibrary.Example.Commands;
using System.Diagnostics;

internal class Program
{
    private static void Main(string[] args)
    {
        var s = new Stopwatch();

        s.Start();
        var conf = Configuration.Default(typeof(Program).Assembly);       

        conf.AddTypeForInjecting(Console.Out);
        

        SimpleLine.Run(new string[] { "file", "read", "C:\\Programming Projects\\SimpleLine\\SimpleLine.Example\\bin\\Release\\net6.0\\TestFile.txt" }, conf);
        s.Stop();
        Console.WriteLine(s.Elapsed.ToString());
    }   
}