using SimpleLineLibrary.Src;
using SimpleLineLibrary.Src.Entities.Commands;
using SimpleLineLibrary.Src.Entities.Parameters;
using SimpleLineLibrary.Src.Entities.Parameters.Impl;
using SimpleLineLibrary.Src.Utils.Binders;

namespace SimpleLineLibrary
{
    internal class Program
    {
        static void Main(string[] args)
        {                                   
            var simp = new SimpleLine();

            simp.RegisterCommand(new Command("multiply", "multiply two numbers"))
                .SetHandler((x, y) => {
                    Console.WriteLine(x * y);
                }, 
                new IntParameter("--left", "-l"),
                new IntParameter("--right", "-r"));

            simp.RegisterCommand(new Command("sum", "sum two numbers"))
                .SetHandler((x, y) => {
                    Console.WriteLine(x + y);
                },
                new IntParameter("--left", "-l"),
                new ValueParameter<int>(new string[] { "--right", "-r" }, new IntBinder(),"32"));

            simp.RegisterCommand(new Command("divive", "devive first number on second"))
                .SetHandler((x, y) => {                    
                    Console.WriteLine(x / y);
                },
                new IntParameter("--left", "-l"),
                new IntParameter("--right", "-r"));


            simp.Run(args);

            Console.ReadKey();
        }        
    }
}