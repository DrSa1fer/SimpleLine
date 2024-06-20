using SimpleLineLibrary;
using SimpleLineLibrary.Setup;

internal class Program
{
    private static void Main(string[] args)
    {
        var conf = Configuration.Default(typeof(Program).Assembly);
        SimpleLine.Build(conf).Run(new string[] { "sub", "-h", "=", "122" });          
    }   
}