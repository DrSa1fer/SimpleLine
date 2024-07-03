namespace SimpleLineLibrary.Setup
{
    /// <summary>
    /// Marks a class as a command definition holder so that the library can use this
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class CommandsDefinitionsAttribute : Attribute
    {
        internal string Command { get; }

        public CommandsDefinitionsAttribute() 
        {
            Command = string.Empty;
        }

        public CommandsDefinitionsAttribute(string rootCommand)
        {
            Command = rootCommand;
        }
    }
}