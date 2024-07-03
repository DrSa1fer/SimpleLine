using System.Diagnostics;
using SimpleLineLibrary;

internal class Program
{
    private static void Main(string[] args)
    {
        var s = new Stopwatch();

        s.Start();
        var conf = Configuration.Default(typeof(Program).Assembly);
        
        SimpleLine.Run(args, conf);

        s.Stop();
        Console.WriteLine(s.Elapsed);
    }   
}