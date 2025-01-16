namespace simpleline.services.executor.main.typizer.primitives;

internal class Int32 {
    public static object Typize(string value) {
        return int.Parse(value);
    }
}