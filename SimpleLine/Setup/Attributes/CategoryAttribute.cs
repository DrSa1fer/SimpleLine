namespace SimpleLineLibrary.Setup.Attributes
{
    /// <summary>
    /// Adds a category for further use by the library
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method,
        AllowMultiple = false, Inherited = true)]
    public class CategoryAttribute : Attribute
    {
        // public Category Category { get; }

        //public CategoryAttribute(Category category) => Category = category;
    }
}