namespace simpleline.services.executor.main.typizer.primitives;

internal class Int64 {
    public static object Bind(string value) {
        return long.Parse(value);
    }
}