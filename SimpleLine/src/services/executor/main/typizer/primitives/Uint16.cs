namespace simpleline.services.executor.main.typizer.primitives;

internal class Uint16 {
    public static object Bind(string value) {
        return ushort.Parse(value);
    }
}