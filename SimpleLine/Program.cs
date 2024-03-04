using SimpleLineLibrary.Src;
using SimpleLineLibrary.Src.Entities.Commands.Handler;
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


            var a = simp.RegisterCommand("sum", "");

                a.SetHandler((left, right) =>
            {
                Console.WriteLine(left + right);
                Console.WriteLine("Run");
            },
                new IntParameter(new string[] { "right", "r" }, "right operand"),
                new IntParameter(new string[] { "left", "l"}, "left operand")
            );

            //simp.Run(new string[] {"a", "--n", "b"});
            Console.WriteLine(a.ToString());

            simp.Run(new string[] {"sum", "--right", "10", "--left", "1", "9"});
            Console.ReadKey();
        }        
    }
}