using simpleline.models.commands;

namespace simpleline.services.executor;

internal sealed class Context(IServiceProvider provider, Command command, Data data)
{
    public IServiceProvider Provider { get; } = provider;

    public Command Command { get; } = command;
    public Data Data { get; } = data;
}