namespace SimpleLineLibrary.Setup
{
    /// <summary>
    /// Marks a method as a command so that the library can use this
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class CommandAttribute : Attribute
    {
        internal string Command { get; }

        /// <summary>
        /// Cobstructor of CommandAttribute
        /// </summary>
        /// <param name="command"></param>
        public CommandAttribute(string command)
        {
            Command = command;
        }
    }
}