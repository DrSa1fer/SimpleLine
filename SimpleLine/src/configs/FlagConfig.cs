namespace simpleline.configs;

public class FlagConfig {
    public FlagConfig(IReadOnlyCollection<string> helpKeys) {
        HelpKeys = helpKeys;
    }
    public FlagConfig() {
        HelpKeys = ["h", "help"];
    }

    public IReadOnlyCollection<string> HelpKeys { get; }
}