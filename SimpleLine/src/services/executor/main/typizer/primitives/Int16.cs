namespace simpleline.services.executor.main.typizer.primitives;

internal class Int16 {
    public static object Typize(string value) {
        return short.Parse(value);
    }
}