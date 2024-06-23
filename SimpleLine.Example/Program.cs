using SimpleLineLibrary;

internal class Program
{
    private static void Main(string[] args)
    {
        var conf = Configuration.Default(typeof(Program).Assembly);

        SimpleLine.Build(conf).Run(new string[] { "test", "foo", "100", "&", "nknkjj", "&", "asfsdff", "&", "World", "&", "nknk" });
    }   
}