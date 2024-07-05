using SimpleLineLibrary.Models;

namespace SimpleLineLibrary.Services.CommandParsing.HelpBlocks
{
    internal class SubcommandBlock : HelpBlock
    {
        public SubcommandBlock(Command com) : base("Subcommands", 
        () =>
        {
            var val = com.Children.Values;
            
            var lines = val.Select(x => x.Uid + " " + x.GetHelpBlock("Description")?.Body ?? string.Empty);

            return lines.Any() ? string.Join("\n\r    ", lines) : "nothing";
        }, 3) {}
    }
}