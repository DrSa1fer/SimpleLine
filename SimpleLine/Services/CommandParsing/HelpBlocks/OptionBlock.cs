using SimpleLineLibrary.Models;

namespace SimpleLineLibrary.Services.CommandParsing.HelpBlocks
{
    internal class OptionBlock : HelpBlock
    {
        public OptionBlock(Command command) : base("Options",  
        () => 
        {
            var res = string.Empty;

            if(command.Handler == null)
            {
                return res;
            }

            if (!command.Handler.Parameters.Any())
            {
                res += "nothing";
                return res;
            }

            foreach (var p in command.Handler.Parameters)
            {
                var req = p.IsRequired ? "req" : "opt";
                var keys = $"{p.ShortKey}|{p.LongKey}";
                var type = p.ValueType.Name.ToLower();
                var desc = p.Description.Length > 0 ? p.Description : "nothing";

                var str = $"{p.Position}: [{req}] {keys} <{type}> - {desc}";

                res+= str + "\n    ";
            }
            
            return res;
        }, 4) { }
    }
}