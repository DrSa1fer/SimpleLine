using SimpleLineLibrary.Models;

namespace SimpleLineLibrary.Services.CommandParsing.HelpBlocks
{
    internal class UsageBlock : HelpBlock
    {
        public UsageBlock(Command com) : base("Usage", 
        () => 
        {
            var stack = new Stack<string>();
            var c = com;
            
            do
            {
                stack.Push(c.Uid);
                c = c.Parent;
            }
            while (c is not null);

            return string.Join(" ", stack); 

        }, 0) { }
    }
}