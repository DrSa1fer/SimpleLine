namespace simpleline.helpers;

internal static class StringHelper
{
    public static int Compare(this string? source, string? other)
    {
        return string.Compare(source, other, StringComparison.Ordinal);
    }
}