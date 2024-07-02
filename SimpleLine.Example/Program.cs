using SimpleLineLibrary;

internal class Program
{
    private static void Main(string[] args)
    {
        var conf = Configuration.Default(typeof(Program).Assembly);
        
        SimpleLine.Run(args, conf);
    }   
}