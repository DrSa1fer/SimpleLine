using simpleline.configs;
using simpleline.models.inputs;

namespace simpleline.models;

public sealed class Context(ApplicationConfig app, Input input)
{
    public ApplicationConfig ApplicationConfig { get; } = app;

    public Route Route { get; } = new(input);
    public Data  Data { get; } = new(input);
}