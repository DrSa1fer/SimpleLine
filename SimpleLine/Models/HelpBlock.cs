namespace SimpleLineLibrary.Models
{
    internal class HelpBlock
    {
        public string Header { get; }
        public string Body { get; }
        public int Priority { get; }

        public HelpBlock(string header, string body, int priority)
        {
            Header = header;
            Body = body;
            Priority = priority;
        }
    }
}