using simpleline.models.options;

namespace simpleline.services.executor.main.binder.handlers.envs;

internal interface IEnvAttribute : IOptionAttribute {
    public string Variable { get; }
    public EnvironmentVariableTarget Target { get; }
}