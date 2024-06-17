using SimpleLineLibrary.Setup;

namespace SimpleLineLibrary.User.Commands
{
    [Command("math")]
    public class MathCommand
    {
        private StreamWriter? _output;

        public void Inject(StreamWriter output)
        {
            _output = output;
        }

        [Handler("--sum")]
        [Description("Calculate sum of two numbers")]
        public int Sum(
            [CustomKeys("-x", "--x")] int x,
            [CustomKeys("-y", "--y")] int y)
        {           
            return x + y;
        }

        [Handler("--multiply")]
        [Description("Calculate multiply of two numbers")]
        public int Multiply(
            [CustomKeys("-x", "--x")] int x,
            [CustomKeys("-y", "--y")] int y)
        {            
            return x * y;
        }
    }
}
