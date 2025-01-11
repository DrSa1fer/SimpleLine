using System.Runtime.InteropServices;

namespace simpleline.configs;

public class ParseConfig {
    public ParseConfig(ICollection<string> keyPrefixes, bool gnuKeyMode) {
        GnuKeyMode = gnuKeyMode;
        KeyPrefixes = keyPrefixes;
    }

    public ParseConfig() {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) {
            GnuKeyMode = false;
            KeyPrefixes = ["/"];
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux)) {
            GnuKeyMode = true;
            KeyPrefixes = ["-", "--"];
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX)) {
            GnuKeyMode = true;
            KeyPrefixes = ["-", "--"];
        }
        else {
            throw new PlatformNotSupportedException();
        }
    }

    /// <summary>
    /// A mode where after a single prefix each character is broken down into separate keys
    /// </summary>
    public bool GnuKeyMode { get; }
    /// <summary>
    /// A set of prefixes that indicate that the passed argument is key
    /// </summary>
    public ICollection<string> KeyPrefixes { get; }
}