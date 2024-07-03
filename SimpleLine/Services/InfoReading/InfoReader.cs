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

            var parc = command;
            do
            {
                stack.Push(parc.Uid);
                parc = parc.Parent;
            }
            while (parc is not null);


            mb
            .StartBlock("Usage:")
                .WriteLine($"{string.Join(" ", stack)} [options]")
            .CloseBlock();

            mb
            .StartBlock("Description:")
                .WriteLine($"{(command.Description.Length > 0 ? command.Description : "nothing")}")
            .CloseBlock();

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
            
            if(command.Children.Any())
            {
                mb.StartBlock("Subcommands:");
                foreach(var c in command.Children.Values)
                {
                    mb.WriteLine($"{c.Uid} - {c.Description}");
                }
                mb.CloseBlock();
            }

            if(command.DocsLink.Length > 0)
            {
                mb
                .StartBlock("Docs:")
                    .WriteLine(command.DocsLink)
                .CloseBlock();
            }

            return mb.ToString();
        }
    }
}
