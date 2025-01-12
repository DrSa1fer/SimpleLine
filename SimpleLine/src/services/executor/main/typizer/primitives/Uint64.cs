namespace simpleline.services.executor.main.typizer.primitives;

internal class Uint64 {
    public static object Bind(string value) {
        return ulong.Parse(value);
    }
}