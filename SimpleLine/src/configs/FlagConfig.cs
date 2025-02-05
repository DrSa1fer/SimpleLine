namespace simpleline.configs;

public class FlagConfig(IReadOnlyCollection<string> helpKeys) {
    public FlagConfig() : this(["h", "help"]) { }

    public IReadOnlyCollection<string> HelpKeys { get; } = helpKeys;
}