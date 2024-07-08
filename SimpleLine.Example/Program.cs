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
        

        SimpleLine.Run(args, conf);
        s.Stop();
        Console.WriteLine(s.Elapsed.ToString());
    }   
}