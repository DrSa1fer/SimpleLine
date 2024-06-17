using SimpleLineLibrary;

internal class Program
{
    private static void Main(string[] args) => 
        new SimpleLine(new()).Run(args, typeof(Program).Assembly);            
}