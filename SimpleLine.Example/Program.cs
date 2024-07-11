using SimpleLineLibrary;
using System.Diagnostics;

internal class Program
{
    private static void Main(string[] args)
    {
        var conf = Configuration.Default(typeof(Program).Assembly);
        conf.AddTypeForInjecting(() => Console.Out);       

        SimpleLine.Run(args, conf, false);
    }
}