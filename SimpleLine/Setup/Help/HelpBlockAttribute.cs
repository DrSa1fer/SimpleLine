namespace SimpleLineLibrary.Setup.Help
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class HelpBlockAttribute : Attribute
    {
        public string Header { get; }
        public string Body { get; }
        public int Order { get; }

        public HelpBlockAttribute(string header, string body, int order)
        {
            Header = header;
            Body = body;
            Order = order;
        }
    }
}