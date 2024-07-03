namespace SimpleLineLibrary.Setup.Help
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class HelpBlockAttribute : Attribute
    {
        public string Header { get; }
        public string Body { get; }
        public int Priority { get; }

        public HelpBlockAttribute(string header, string body, int priority)
        {
            Header = header;
            Body = body;
            Priority = priority;
        }
    }
}