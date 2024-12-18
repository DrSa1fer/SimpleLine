using simpleline.services.execution.options.arguments;

namespace simpleline.attributes;

[AttributeUsage(AttributeTargets.Field)]
public class ArgumentAttribute(int position) : Attribute, IArgumentAttribute
{
}