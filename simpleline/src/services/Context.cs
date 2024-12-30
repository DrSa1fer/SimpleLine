using simpleline.configs;
using simpleline.models;
using simpleline.models.commands;

namespace simpleline.services;

internal sealed class Context(Input input)
{
    public required ApplicationConfig ApplicationConfig { get; init; }
    public required ServiceConfig ServiceConfig { get; init; }
    public required EventConfig EventConfig { get; init; }
    
    public Command Command { get; init; }
}