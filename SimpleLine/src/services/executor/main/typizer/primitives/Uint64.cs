namespace simpleline.services.executor.main.typizer.primitives;

internal class Uint64 {
    public static object Typize(string value) {
        return ulong.Parse(value);
    }
}