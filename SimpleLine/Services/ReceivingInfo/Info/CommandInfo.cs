using SimpleLineLibrary.Models;
using SimpleLineLibrary.Utils.MessageBuilders;

namespace SimpleLineLibrary.Services.ReceivingInfo.Info
{
    internal class CommandInfo : BaseInfo
    {
        internal IEnumerable<HandlerInfo> Handlers { get; }

        internal string Uid { get; }
        internal string Name { get; }
        internal string Description { get; }

        internal CommandInfo(Command command, string program, string vers)
            : base(program, vers)
        {
            Uid = command.Uid;
            Name = command.Name;
            Description = command.Description;

            Handlers = command.Handlers.Select(x => new HandlerInfo(x, program, vers));
        }

        public override string ToString()
        {
            var mb = new MessageBuilder()

            .AddHeader($"{Program} #{Version}")

            .StartBlock("command:")
                .WriteLine($"[release] {Uid} - {Description}")
            .CloseBlock()

            .StartBlock("usage:")
                .WriteLine($"{Program} {Uid} " +
                $"{(Handlers.FirstOrDefault(x => x.HasKey) == null ? "" : "<key> ")}" +
                $"[parameters]")
            .CloseBlock();

            mb.StartBlock("overrides:");


            foreach (var h in Handlers)
            {
                mb.StartBlock($"$ {Uid}{(h.HasKey ? $" {h.Key}" : "")}" +
                    $"{(h.Description.Length > 0 ? $" - {h.Description}" : "")}", false);

                if (h.Parameters.Any())
                {


                    foreach (var p in h.Parameters)
                    {
                        var req = p.IsRequired ? "req" : "opt";
                        var keys = $"{p.ShortKey}|{p.LongKey}";
                        var type = p.ValueType.Name.ToLower();
                        var desc = p.Description.Length > 0 ? $" - {p.Description}" : "";

                        var str =
                            $"[{req}] {keys} <{type}>{desc}";

                        mb.WriteLine(str);
                    }
                }
                else
                {
                    mb.WriteLine("[no parameters]");
                }

                mb.CloseBlock();
            }

            mb.CloseBlock();

            mb.StartBlock("docs:")
                .WriteLine("...")
            .CloseBlock()
            .SkipLine()
            .AddFooter("by simpleline");

            return mb.ToString();
        }
    }
}