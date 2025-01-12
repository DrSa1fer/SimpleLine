namespace simpleline.services.executor.main.typizer.primitives;

internal class Single {
    public static object Bind(string value) {
        return float.Parse(value);
    }
}