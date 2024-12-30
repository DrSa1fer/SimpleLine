using simpleline.configs;
using simpleline.models;
using simpleline.models.commands;

namespace simpleline.services;

public sealed class Context(Input input)
{
    public required ApplicationConfig ApplicationConfig { get; init; }
    public required EventConfig EventConfig { get; init; }
    
    public string Pwd { get; }
    public Command Command { get; init; }
    
}