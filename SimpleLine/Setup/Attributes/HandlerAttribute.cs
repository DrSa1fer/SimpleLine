namespace SimpleLineLibrary.Setup.Attributes
{
    /// <summary>
    /// Marks a method as a handler so that the library can use this
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class HandlerAttribute : Attribute
    {
        public HandlerAttribute()
        {
            Key = "";
        }

        public HandlerAttribute(string key)
        {
            Key = key;
        }

        public string Key { get; }
    }
}