namespace SimpleLineLibrary.Setup
{
    [AttributeUsage(AttributeTargets.Parameter)]
    public class ParameterDataAttribute : Attribute
    {
        public string? LongKey { get; set; }
        public string? ShortKey { get; set; }

        public string? Description { get; set; }
        public string[]? PermissibleValues { get; set; }
    }
}
