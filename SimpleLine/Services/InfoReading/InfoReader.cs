using SimpleLineLibrary.Models;
using SimpleLineLibrary.Utils;

namespace SimpleLineLibrary.Services.InfoReading
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

            //mb.AddHeader($"{_program} #{_vers}").SkipLine();

            var uid = command.Uid;
            var h = command.Handler;

            mb
            .StartBlock("Usage:")
                .WriteLine("program.dll [options]")
                .WriteLine("program.dll [command] [options]")
            .CloseBlock();

            mb
            .StartBlock("Description:")
                .WriteLine($"{(command.Description.Length > 0 ? command.Description : "nothing")}")
            .CloseBlock();

            if (h is not null)
            {
                mb.StartBlock("Options:");

                if (h.Parameters.Any())
                {
                    foreach (var p in h.Parameters)
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

            

            mb
            .StartBlock("Commands:")
                .WriteLine("test")
            .CloseBlock();

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
