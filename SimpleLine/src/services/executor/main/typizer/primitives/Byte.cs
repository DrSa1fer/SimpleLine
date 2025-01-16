namespace simpleline.services.executor.main.typizer.primitives;

internal class Byte {
    public static object Typize(string value) {
        return byte.Parse(value);
    }
}