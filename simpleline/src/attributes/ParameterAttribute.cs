namespace simpleline.attributes;

[AttributeUsage(AttributeTargets.Field)]
public class ParameterAttribute(string[] aliases) : Attribute
{
}