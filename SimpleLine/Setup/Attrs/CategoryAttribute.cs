using SimpleLineLibrary.Models.Data;

namespace SimpleLineLibrary.Setup
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CategoryAttribute : Attribute
    {
        public Category Category { get; }

        public CategoryAttribute(Category category) => Category = category;
    }
}
