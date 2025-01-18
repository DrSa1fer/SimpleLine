using simpleline.services.executor.main.binder.handlers.envs;
using simpleline.services.registrar;

namespace simpleline.attributes;

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
public class EnvAttribute(
    string name,
    EnvironmentVariableTarget target = EnvironmentVariableTarget.Process
) : Attribute, IRegistered, IEnvAttribute {
    public string Variable { get; } = name;
    public EnvironmentVariableTarget Target { get; } = target;
}