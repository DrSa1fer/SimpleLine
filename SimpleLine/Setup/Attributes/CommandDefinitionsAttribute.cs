namespace SimpleLineLibrary.Setup.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class CommandDefinitionsAttribute : Attribute
    {
        public string? BindToCommand { get; set; }
    }
}
