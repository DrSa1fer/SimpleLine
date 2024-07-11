using SimpleLineLibrary.Models;

namespace SimpleLineLibrary.Services.CommandParsing.HelpBlocks
{
    internal class OptionBlock : HelpBlock
    {
        public OptionBlock(Command command) : base("Options",
        () =>
        {
            if (command.ChachedAction == null)
            {
                return Enumerable.Empty<string>();
            }

            if (!command.ChachedAction.Parameters.Any())
            {
                return Enumerable.Empty<string>();
            }

            var ps = command.ChachedAction.Parameters;
            var lines = new string[ps.Count];

            for (int i = 0; i < ps.Count; i++)
            {
                var p = ps[i];

                var req = p.IsRequired ? "req" : "opt";
                var keys = $"{p.ShortKey}|{p.LongKey}";
                var type = p.ValueType.Name.ToLower();
                var desc = p.Description.Length > 0 ? p.Description : "nothing";

                lines[i] = $"{p.Position}: [{req}] {keys} <{type}> - {desc}";
            }

            return lines;
        }, 4)
        { }
    }
}