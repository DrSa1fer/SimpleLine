namespace SimpleLineLibrary.Setup
{
    /// <summary>
    /// Adds a description for further use by the library
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Parameter, AllowMultiple = false, Inherited = true)]
    public class DescriptionAttribute : Attribute
    {
        internal string Description { get; }

        public DescriptionAttribute(string description)
        {
            Description = description;
        }
    }
}