namespace simpleline.services.executor.main.typizer.primitives;

internal class Uint32 {
    public static object Typize(string value) {
        return uint.Parse(value);
    }
}