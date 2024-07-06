namespace SimpleLineLibrary.Setup.Help
{
    /// <summary>
    /// Attribute make
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class DocsLinkAttribute : HelpBlockAttribute
    {
        public DocsLinkAttribute(string link) : base("Docs", link, 10)
        {
        }        
    }
}