using System.Reflection;

namespace simpleline.configs;

public class ApplicationConfig
{
    public string? Name { get; set; } = "program";
    public string? Description { get; set; } = "My cli program";
    public string? Version { get; set; } = "1.0.0-stable";
    public string? Author { get; set; } = "Me";
    public string? License { get; set; } = "GPL";
    public string? Website { get; set; } = "https://example.com/";
    public string? Documentation { get; set; } = "https://example.com/";

    public Action<string>? OnMissingAction { get; set; } =
        route => Console.WriteLine($"Missing action for route {route}");

    public IServiceProvider ServiceProvider { get; init; }
    public IEnumerable<TypeInfo> DefinedTypes { get; init; }
}