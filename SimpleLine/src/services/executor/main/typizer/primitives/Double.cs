namespace simpleline.services.executor.main.typizer.primitives;

internal class Double {
    public static object Bind(string value) {
        return double.Parse(value);
    }
}