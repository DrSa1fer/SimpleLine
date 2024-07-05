namespace SimpleLineLibrary.Models
{
    internal class HelpBlock
    {
        public string Header { get; }
        public string Body => _body();
        public int Order { get; }

        private readonly Func<string> _body;

        public HelpBlock(string header, Func<string> body, int order)
        {
            Header = header;
            Order = order;

            _body = body;
        }

        public HelpBlock(string header, string body, int order)
        {
            Header = header;
            Order = order;
            
            _body = () => body;
        }
    }
}