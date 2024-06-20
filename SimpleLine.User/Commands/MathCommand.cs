using SimpleLineLibrary.Setup.Attributes;

namespace SimpleLineLibrary.Example.Commands
{
    [CommandDefinitions]
    public class MathCommand
    {
        [Command("sum")]
        [Description("Calculate sum of two numbers")]
        public void Sum(
            [CustomKeys("-x", "--x")] int x,
            [CustomKeys("-y", "--y")] int y)
        {
            Console.WriteLine(x + y);
        }

        [Command("multiply")]
        [Description("Calculate multiply of two numbers")]
        public void Multiply(
            [CustomKeys("-x", "--x")] int x,
            [CustomKeys("-y", "--y")] int y)
        {
            Console.WriteLine(x * y);
        }
    }
}
