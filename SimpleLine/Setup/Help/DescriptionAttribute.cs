namespace SimpleLineLibrary.Setup.Help
{
    /// <summary>
    /// Add a description for further use by the library. Priority = 1.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Parameter, AllowMultiple = false, Inherited = true)]
    public class DescriptionAttribute : HelpBlockAttribute
    {
        public DescriptionAttribute(string description) : base("Description", description, 1)
        {
        }
    }
}