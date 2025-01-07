namespace simpleline.attributes;

[AttributeUsage(AttributeTargets.All)]
public class DescriptionAttribute(string description) : Attribute;