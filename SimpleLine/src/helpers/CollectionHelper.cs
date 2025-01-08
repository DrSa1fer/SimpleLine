namespace simpleline.helpers;

internal static class CollectionHelper {
    public static bool IsPrefix(this IReadOnlyCollection<string> prefix, IReadOnlyCollection<string> source) {
        if (source.Count != prefix.Count) {
            return false;
        }

        using var sourceEnumerator = source.GetEnumerator();
        using var prefixEnumerator = prefix.GetEnumerator();

        while (sourceEnumerator.MoveNext() && prefixEnumerator.MoveNext()) {
            if (!sourceEnumerator.Current.HEquals(prefixEnumerator.Current)) {
                return false;
            }
        }

        sourceEnumerator.Reset();
        prefixEnumerator.Reset();

        return true;
    }
}