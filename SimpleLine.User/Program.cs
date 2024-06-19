using SimpleLineLibrary;
using SimpleLineLibrary.Setup;

internal class Program
{
    private static void Main(string[] args)
    {
        var conf = new Configuration(typeof(Program).Assembly);        

        SimpleLine.Build(conf).Run(new string[]
        {
            "test", "sub", 

            "-t", "1", 
            "-t", "9", 
            "-t", "8", 
            "-t", "4"
        });          
    }   
}