namespace simpleline.services.executor.main.typizer.primitives;

internal class Int16 {
    public static object Bind(string value) {
        return short.Parse(value);
    }
}