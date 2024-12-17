using simpleline.models.commands;

namespace simpleline.attributes;

[AttributeUsage(AttributeTargets.Field)]
public class ArgumentAttribute(int position) : Attribute, IOptionAttribute
{
}