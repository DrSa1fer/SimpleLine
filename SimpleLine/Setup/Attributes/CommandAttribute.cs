namespace SimpleLineLibrary.Setup.Attributes
{
    /// <summary>
    /// Marks a class as a command so that the library can use this
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class CommandAttribute : Attribute
    {
        public CommandAttribute(string command)
        {
            Command = command;
        }

        public string Command { get; }
    }
}