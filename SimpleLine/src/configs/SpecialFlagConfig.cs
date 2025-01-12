namespace simpleline.configs;

public class SpecialFlagConfig {
    public SpecialFlagConfig(IReadOnlyCollection<string> helpKeys) {
        HelpKeys = helpKeys;
    }
    public SpecialFlagConfig() {
        HelpKeys = ["h", "help"];
    }

    public IReadOnlyCollection<string> HelpKeys { get; }
}