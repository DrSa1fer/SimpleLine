namespace simpleline.services.executor.main.typizer.primitives;

internal class Byte {
    public static object Bind(string value) {
        return byte.Parse(value);
    }
}