namespace simpleline.services.executor.main.typizer.primitives;

internal class Int32 {
    public static object Bind(string value) {
        return int.Parse(value);
    }
}