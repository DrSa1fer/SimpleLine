using simpleline.models.commands;
using simpleline.configs;
using simpleline.services.binder;

namespace simpleline.services;

internal sealed class Context
{
    public required ApplicationConfig ApplicationConfig { get; init; }
    public required EventConfig EventConfig { get; init; }

    public required Command Command { get; init; }
    public required InputData InputData { get; init; }
}