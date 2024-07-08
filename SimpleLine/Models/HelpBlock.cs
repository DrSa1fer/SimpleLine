namespace SimpleLineLibrary.Models
{
    internal class HelpBlock
    {        
        public string Header { get; }
        public IEnumerable<string> Body => _body();
        public int Order { get; }

        private readonly Func<IEnumerable<string>> _body;

        public HelpBlock(string header, Func<IEnumerable<string>> body, int order)
        {
            Header = header;
            Order = order;

            _body = body;
        }
        public HelpBlock(string header, IEnumerable<string> body, int order)
            : this(header, () => body, order)
        {
        }
        public HelpBlock(string header, Func<string> body, int order)
            : this(header, () => new string[] { body() }, order)
        {
        }
        public HelpBlock(string header, string body, int order)
            : this(header, () => new string[] { body }, order)
        {
        }
    }
}