using SimpleLineLibrary.Models;

namespace SimpleLineLibrary.Services.CommandParsing.HelpBlocks
{
    internal class SubcommandBlock : HelpBlock
    {
        public SubcommandBlock(Command com) : base("Subcommands", 
        com.Children.Values
            .Select(x => x.Uid + " " + x.GetHelpBlock("Description")?.Body.FirstOrDefault()), 3) 
        {}
    }
}