using SimpleLineLibrary.Utils.MessageBuilders;

namespace SimpleLineLibrary.Models.Info
{
    public class HandlerInfo : BaseInfo
    {
        internal string Name { get; }
        internal string Description { get; }
        internal bool HasKey { get; }
        internal string Key { get; }
        internal IEnumerable<ParameterInfo> Parameters { get; }

        internal HandlerInfo(Handler handler, string program, string vers) 
            : base(program, vers)
        {
            Name = handler.Name;
            Description = handler.Description;
            Key = handler.Key;

            HasKey = handler.HasKey;

            Parameters = handler.Parameters.Select(x => new ParameterInfo(x, program, vers));
        }

        public override string ToString()
        {
            var mb = new MessageBuilder();

            mb.StartBlock();
                    
            if (Parameters.Any())
            {
                foreach (var p in Parameters)
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

            return mb.ToString();
        }
    }
}