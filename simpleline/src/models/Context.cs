using simpleline.configs;
using simpleline.models.inputs;

namespace simpleline.models;

public sealed class Context(ApplicationConfig app, Input input)
{
    public ApplicationConfig ApplicationConfig { get; } = app;
    
    public RouteInput  RouteInput       { get; } = new(input);
    public OptionInput OptionInput { get; } = new(input);
}