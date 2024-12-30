using simpleline.services.binder.commandOptions.parameters;

namespace simpleline.attributes;

[AttributeUsage(AttributeTargets.Field)]
public class ParameterAttribute(string[] aliases) 
    : Attribute, ICommandParameterAttribute
{
    public IEnumerable<string> Keys => aliases;
}