namespace simpleline.configs;

public class ParserConfig(string? shortKey, string? longKey)
{
    public string? ShortKey { get; } = shortKey;
    public string? LongKey { get; } = longKey;
}