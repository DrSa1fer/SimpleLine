namespace simpleline.configs;

public class HelpConfig(
    string? program,
    string? version,
    string? description,
    string? author,
    string? license,
    string? website,
    string? documentation
) {
    public HelpConfig() : this(
        "program",
        "1.0.0-stable",
        "My cli program",
        "Me",
        "GPL",
        "https://example.com/",
        "https://example.com/"
    ) { }

    public string? Program { get; } = program;
    public string? Version { get; } = version;
    public string? Description { get; } = description;
    public string? Author { get; } = author;
    public string? License { get; } = license;
    public string? Website { get; } = website;
    public string? Documentation { get; } = documentation;
}