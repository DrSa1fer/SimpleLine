using SimpleLineLibrary;
using SimpleLineLibrary.Example.Commands;

internal class Program
{
    private static void Main(string[] args)
    {
        var conf = Configuration.Default(typeof(Program).Assembly);
        
        conf.OnSimpleLineException = e =>
        {
            System.Console.WriteLine(e.Message);
            System.Console.WriteLine(e.InnerException?.StackTrace);
        };

        conf.AddTypeForConverting(x => 
        {
            return new DataSize()
            {
                Count = 1,
                Multiplier = 1
            };
        });

        /*conf.AddTypeForConverting(x =>
        {
            return x == "1" ? FindFilter.All : FindFilter.NoAll;
        });*/

        SimpleLine.Run(args, conf);
    }   
}