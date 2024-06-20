namespace SimpleLineLibrary.Setup
{
    /// <summary>
    /// Marks a class as a command definition holder so that the library can use this
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class CommandDefinitionsAttribute : Attribute
    {
        public string? BindTo { get; set; }
    }
}