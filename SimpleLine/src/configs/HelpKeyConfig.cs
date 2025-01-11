namespace simpleline.configs;

public class HelpKeyConfig(IReadOnlyCollection<string> helpKeys) {
    public HelpKeyConfig() : this(["h", "help"]) { }

    public IReadOnlyCollection<string> HelpKeys { get; } = helpKeys;
}