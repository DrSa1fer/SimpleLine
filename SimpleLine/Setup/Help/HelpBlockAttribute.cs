namespace SimpleLineLibrary.Setup.Help
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class HelpBlockAttribute : Attribute
    {
        internal string Header { get; }
        internal string Body { get; }
        internal int Order { get; }

        public HelpBlockAttribute(string header, string body, int order)
        {
            Header = header;
            Body = body;
            Order = order;
        }
    }
}