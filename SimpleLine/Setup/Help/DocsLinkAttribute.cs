namespace SimpleLineLibrary.Setup.Help
{
    /// <summary>
    /// Attribute make
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class DocsLinkAttribute : HelpBlockAttribute
    {
        public DocsLinkAttribute(string link, int order = 10) 
            : base("Docs", link, order)
        {
        }        
    }
}