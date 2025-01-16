namespace simpleline.services.executor.main.typizer.primitives;

internal class Double {
    public static object Typize(string value) {
        return double.Parse(value);
    }
}