namespace SimpleLineLibrary.Setup.Attributes
{
    /// <summary>
    /// Marks a class as a command so that the library can use this
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class CommandAttribute : Attribute
    {
        public string Command { get; }

        public CommandAttribute(string command)
        {
            Command = command;
        }
    }
}