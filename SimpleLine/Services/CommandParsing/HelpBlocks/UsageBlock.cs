using SimpleLineLibrary.Models;

namespace SimpleLineLibrary.Services.CommandParsing.HelpBlocks
{
    internal class UsageBlock : HelpBlock
    {
        public UsageBlock(CommandNode com, params string[] x) : base("Usage",
        () =>
        {
            var stack = new Stack<string>();
            var c = com;

            foreach (var a in x)
            {
                stack.Push(a);
            }

            do
            {
                stack.Push(c.Uid);
                c = c.Parent;
            }
            while (c is not null);

            return string.Join(" ", stack);

        }, 0)
        { }
    }
}