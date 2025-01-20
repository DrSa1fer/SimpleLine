namespace simpleline.external;

public class ApplicationMeta(
    string? program,
    string? version,
    string? description,
    string? author,
    string? license,
    string? website,
    string? documentation
) {
    public ApplicationMeta() : this(
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