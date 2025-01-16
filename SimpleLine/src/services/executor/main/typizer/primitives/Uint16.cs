namespace simpleline.services.executor.main.typizer.primitives;

internal class Uint16 {
    public static object Typize(string value) {
        return ushort.Parse(value);
    }
}