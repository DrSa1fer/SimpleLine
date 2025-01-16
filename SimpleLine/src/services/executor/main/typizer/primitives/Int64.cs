namespace simpleline.services.executor.main.typizer.primitives;

internal class Int64 {
    public static object Typize(string value) {
        return long.Parse(value);
    }
}