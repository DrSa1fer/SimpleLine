namespace simpleline.services.executor.main.typizer.primitives;

internal class SByte {
    public static object Typize(string value) {
        return sbyte.Parse(value);
    }
}