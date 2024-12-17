using simpleline.models.commands;

namespace simpleline.attributes;

[AttributeUsage(AttributeTargets.Field)]
public class FlagAttribute(string[] aliases) : Attribute, IOptionAttribute
{
}