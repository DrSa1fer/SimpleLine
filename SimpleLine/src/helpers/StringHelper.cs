namespace simpleline.helpers;

internal static class StringHelper {
    public static int HCompare(this string source, string other) {
        return string.Compare(source, other, StringComparison.Ordinal);
    }

    public static bool HEquals(this string source, string other) {
        return source.Equals(other, StringComparison.Ordinal);
    }

    public static bool HStartsWith(this string source, string other) {
        return source.StartsWith(other, StringComparison.Ordinal);
    }

    public static string HReplace(this string source, string oldValue, string newValue) {
        return source.Replace(oldValue, newValue, StringComparison.Ordinal);
    }
}