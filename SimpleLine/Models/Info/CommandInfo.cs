namespace SimpleLineLibrary.Models.Info
{
    public class CommandInfo : BaseInfo
    {
        public string Name { get; }
        public IEnumerable<HandlerInfo> HandlersInfo { get; }

        internal CommandInfo(Command command)
        {
        }

        public override string ToString()
        {
            var enter = Environment.NewLine;

            var str = $"{Name} info:{enter}";

            foreach (var h in HandlersInfo)
            {
                str += $"\t{h}{enter}";
            }

            return str;
        }
    }
}