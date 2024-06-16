namespace SimpleLineLibrary.Setup
{
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