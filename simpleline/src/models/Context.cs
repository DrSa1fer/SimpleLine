using simpleline.configs;
using simpleline.models.inputs;

namespace simpleline.models;

public sealed class Context(Input input)
{
    public required ApplicationConfig ApplicationConfig { get; init; }
    public required IEnumerable<Command> Commands { get; init; }


    public Data Data { get; } = new(input);
    public Route Route { get; } = new(input);
}