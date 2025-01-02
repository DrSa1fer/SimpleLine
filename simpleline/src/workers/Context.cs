using simpleline.configs;
using simpleline.models.commands;
using simpleline.services;

namespace simpleline.workers;

internal sealed class Context(
    ApplicationConfig applicationConfig, 
    Command command,
    Data data)
{
    public ApplicationConfig ApplicationConfig { get; init; } = applicationConfig;

    public Command Command { get; init; } = command;
    public Data Data { get; init; } = data;
}