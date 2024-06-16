using SimpleLineLibrary.Setup;

namespace SimpleLineLibrary.User.Commands
{
    [Command("math")]
    public class MathCommand
    {
        private StreamWriter? _output;

        [Inject]
        public void Inject(StreamWriter output)
        {
            _output = output;
        }

        [Handler("--sum")]
        [Description("Calculate sum of two numbers")]
        public void Sum(int x, int y)
        {           
            _output?.WriteLine(">>> result: {0}", x + y);
        }

        [Handler("--multiply")]
        [Description("Calculate multiply of two numbers")]
        public void Multiply(int x, int y)
        {            
            _output?.WriteLine(">>> result: {0}", x * y);
        }
    }
}
