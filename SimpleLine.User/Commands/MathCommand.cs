using SimpleLineLibrary.Setup;

namespace SimpleLineLibrary.User.Commands
{
    [Command("math")]
    public class MathCommand
    {
        [Handler("--sum")]
        [Description("Calculate sum of two numbers")]
        public void Sum(
            [CustomKeys("-x", "--x")] int x,
            [CustomKeys("-y", "--y")] int y)
        {
            Console.WriteLine(x + y);
        }

        [Handler("--multiply")]
        [Description("Calculate multiply of two numbers")]
        public void Multiply(
            [CustomKeys("-x", "--x")] int x,
            [CustomKeys("-y", "--y")] int y)
        {
            Console.WriteLine(x * y);
        }
    }
}
