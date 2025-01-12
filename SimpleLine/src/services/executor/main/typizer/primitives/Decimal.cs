namespace simpleline.services.executor.main.typizer.primitives;

internal class Decimal {
    public static object Bind(string value) {
        return decimal.Parse(value);
    }
}