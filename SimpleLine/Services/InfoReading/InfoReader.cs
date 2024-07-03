using SimpleLineLibrary.Extentions;
using SimpleLineLibrary.Models;
using SimpleLineLibrary.Utils;

namespace SimpleLineLibrary.Services.InfoReading
{
    internal class InfoReader
    {   
        public string GetInfo(Command command)
        {
            var mb = new MessageBuilder();
            
            var stack = new Stack<string>();
            var c = command;
            
            do
            {
                stack.Push(c.Uid);
                c = c.Parent;
            }
            while (c is not null);

            command.HelpBlocks.Add(new("Usage", string.Join(" ", stack), 0));
            command.HelpBlocks.Add(new("Subcommands", string.Join("\n    ", command.Children.Select(x => x.Value.Uid + " " + x.Value.HelpBlocks.FirstOrDefault(x => x.Equals("Description")))), 2));            

            var orderedBlocks = command.HelpBlocks.OrderBy(x => x.Priority);
            foreach(var b in orderedBlocks)
            {
                mb
                .StartBlock(b.Header + ":")
                    .WriteLine(b.Body)
                .CloseBlock();
            }

            if (command.Handler is not null)
            {
                mb.StartBlock("Options:");

                if (command.Handler.Parameters.Any())
                {
                    foreach (var p in command.Handler.Parameters)
                    {
                        var req = p.IsRequired ? "req" : "opt";
                        var keys = $"{p.ShortKey}|{p.LongKey}";
                        var type = p.ValueType.Name.ToLower();
                        var desc = p.Description.Length > 0 ? p.Description : "nothing";

                        var str = $"{p.Position}: [{req}] {keys} <{type}> - {desc}";

                        mb.WriteLine(str);
                    }
                }
                else
                {
                    mb.WriteLine("nothing");
                }

                mb.CloseBlock();
            }

            return mb.ToString();
        }
    }
}
