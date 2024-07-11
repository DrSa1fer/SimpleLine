namespace SimpleLineLibrary.Setup.Help
{
    /// <summary>
    /// Add a description for further use by the library. Priority = 1.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class DescriptionAttribute : HelpBlockAttribute
    {
        public DescriptionAttribute(string description, int order = 1)
            : base("Description", description, order)
        {
        }
    }
}