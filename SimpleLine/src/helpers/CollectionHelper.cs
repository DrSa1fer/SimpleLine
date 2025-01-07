namespace simpleline.helpers;

internal static class CollectionHelper
{
    public static bool IsPrefix(this IReadOnlyCollection<string> prefix, IReadOnlyCollection<string> source)
    {
        using var prefixEnumerator = prefix.GetEnumerator();
        using var sourceEnumerator = source.GetEnumerator();

        while (prefixEnumerator.MoveNext())
        {
            if (!sourceEnumerator.MoveNext()) return false;

            if (sourceEnumerator.Current != prefixEnumerator.Current) return false;
        }

        sourceEnumerator.Reset();
        prefixEnumerator.Reset();

        return true;
    }
}