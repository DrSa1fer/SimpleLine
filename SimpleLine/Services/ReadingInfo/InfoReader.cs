using SimpleLineLibrary.Utils.MessageBuilders;
using SimpleLineLibrary.Models;

namespace SimpleLineLibrary.Services.ReadingInfo
{
    internal class InfoReader
    {
        private readonly string _program;
        private readonly string _vers;

        public InfoReader(string program, string vers)
        {
            _program = program;
            _vers = vers;
        }
        
        public string GetInfo(Command command)
        {
            var mb = new MessageBuilder();

            mb.AddHeader($"{_program} #{_vers}");

            var uid = command.Uid;
            var h = command.Handler;

            mb
                .StartBlock("command:")
                    .WriteLine($"{uid} - {(command.Description.Length > 0 ? command.Description : "no description")}")
                .CloseBlock();

            if (h is not null)
            {
                mb.StartBlock("parameters:");

                if (h.Parameters.Any())
                {
                    foreach (var p in h.Parameters)
                    {
                        var req = p.IsRequired ? "req" : "opt";
                        var keys = $"{p.ShortKey}|{p.LongKey}";
                        var type = p.ValueType.Name.ToLower();
                        var desc = p.Description.Length > 0 ? p.Description : "no description";

                        var str = $"[{req}] {keys} <{type}> - {desc}";

                        mb.WriteLine(str);
                    }
                }
                else
                {
                    mb.WriteLine("[no parameters]");
                }

                mb.CloseBlock();
            }

            mb
            .StartBlock("docs:")
                 .WriteLine("...")
            .CloseBlock()
                .SkipLine()
            .AddFooter("simpleline");

            return mb.ToString();
        }
    }
}
