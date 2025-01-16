namespace simpleline.services.executor.main.typizer.primitives;

internal class Single {
    public static object Typize(string value) {
        return float.Parse(value);
    }
}