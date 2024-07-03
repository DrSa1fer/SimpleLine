namespace SimpleLineLibrary.Setup
{
    /// <summary>
    /// Marks a method as a command so that the library can use this
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class CommandAttribute : Attribute
    {
        internal string Command { get; }

        public CommandAttribute()
        {
            Command = string.Empty;
        }
        public CommandAttribute(string command)
        {
            Command = command;
        }
    }
}