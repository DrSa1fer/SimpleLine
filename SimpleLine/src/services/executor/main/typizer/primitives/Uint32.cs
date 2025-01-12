namespace simpleline.services.executor.main.typizer.primitives;

internal class Uint32 {
    public static object Bind(string value) {
        return uint.Parse(value);
    }
}