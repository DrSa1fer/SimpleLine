using System.Runtime.InteropServices;

namespace simpleline.configs;

public class ParserConfig
{
    public ParserConfig(string shortKeyPrefix, string longKeyPrefix, bool useShortKeySplitting)
    {
        ShortKeyPrefix = shortKeyPrefix;
        LongKeyPrefix = longKeyPrefix;

        UseShortKeySplitting = useShortKeySplitting;
    }

    public ParserConfig()
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            UseShortKeySplitting = false;
            ShortKeyPrefix = "/";
            LongKeyPrefix = "/";
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
            UseShortKeySplitting = true;
            ShortKeyPrefix = "-";
            LongKeyPrefix = "--";
        }
        else
        {
            throw new PlatformNotSupportedException();
        }
    }

    public string ShortKeyPrefix { get; }
    public string LongKeyPrefix { get; }

    public bool UseShortKeySplitting { get; }
}