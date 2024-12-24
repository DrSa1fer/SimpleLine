using simpleline.services.binder.commandOptions.parameters;

namespace simpleline.attributes;

[AttributeUsage(AttributeTargets.Field)]
public class ParameterAttribute(string[] aliases, int arity = 1) 
    : Attribute, IParameterAttribute
{
    public IEnumerable<string> Keys => aliases;
    public int Arity => arity;
}