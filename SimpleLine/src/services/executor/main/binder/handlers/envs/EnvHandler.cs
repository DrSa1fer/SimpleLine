namespace simpleline.services.executor.main.binder.handlers.envs;

internal class EnvHandler {
    public IEnumerable<string> Handle(IEnvAttribute attribute) {
        return [Environment.GetEnvironmentVariable(attribute.Variable, attribute.Target) ?? ""];
    }
}