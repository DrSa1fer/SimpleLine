namespace simpleline.extensions;

internal static class StringExtension
{
    public static int Compare(this string? source, string? other)
    {
        return string.Compare(source, other, StringComparison.Ordinal);
    }
}