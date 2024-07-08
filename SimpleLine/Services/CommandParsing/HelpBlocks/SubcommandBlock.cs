using SimpleLineLibrary.Extentions;
using SimpleLineLibrary.Models;

namespace SimpleLineLibrary.Services.CommandParsing.HelpBlocks
{
    internal class SubcommandBlock : HelpBlock
    {
        public SubcommandBlock(CommandNode com) : base("Subcommands", 
        com.Children.Values
            .Select(x => x.Uid + " - " + x.Command?
                .GetHelpBlocks()
                .FirstOrDefault(x => x.Header.IsEqualsToken("Description"))?.Body
                .FirstOrDefault()), 3) 
        {}
    }
}