namespace SimpleLineLibrary.Setup
{
    [AttributeUsage(AttributeTargets.Method)]
    public class DocsLinkAttribute : Attribute
    {
        internal string Url { get; }
        
        public DocsLinkAttribute(string url)
        {
            Url = url;
        }        
    }
}