using simpleline.services.binder.commandOptions.parameters;
using simpleline.workers.registrar;

namespace simpleline.attributes;

[AttributeUsage(AttributeTargets.Field)]
public class ParameterAttribute(string[] aliases) : Attribute, ICommandParameterAttribute, IRegistered
{
    public IEnumerable<string> Keys => aliases;
}