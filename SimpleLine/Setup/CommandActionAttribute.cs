namespace SimpleLineLibrary.Setup
{
    /// <summary>
    /// Marks a class as a command definition holder so that the library can use this
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class CommandActionAttribute : Attribute { }
}