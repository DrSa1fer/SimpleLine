using simpleline.services.binder.commandOptions.arguments;

namespace simpleline.attributes;

[AttributeUsage(AttributeTargets.Field)]
public class ArgumentAttribute(int position, int arity = 1) : Attribute, IArgumentAttribute
{
    public int Position => position;
    public int Arity => arity;
}