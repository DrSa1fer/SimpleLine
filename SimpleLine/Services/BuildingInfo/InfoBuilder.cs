using SimpleLineLibrary.Utils.MessageBuilders;
using SimpleLineLibrary.Models;

namespace SimpleLineLibrary.Services.BuildingInfo
{
    internal class InfoBuilder
    {
        private readonly string _program;
        private readonly string _vers;

        public InfoBuilder(string program, string vers)
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
                    .WriteLine($"[release] {uid}{(command.Description.Length > 0 ? $" - {command.Description}" : "")}")
                .CloseBlock();

            if (h is not null)
            {
                

                mb.StartBlock("usage:");

                if (h.Parameters.Any())
                {
                    foreach (var p in h.Parameters)
                    {
                        var req = p.IsRequired ? "req" : "opt";
                        var keys = $"{p.ShortKey}|{p.LongKey}";
                        var type = p.ValueType.Name.ToLower();
                        var desc = p.Description.Length > 0 ? $" - {p.Description}" : "";

                        var str = $"[{req}] {keys} <{type}>{desc}";

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
            .AddFooter("by simpleline");

            return mb.ToString();
        }
    }
}
