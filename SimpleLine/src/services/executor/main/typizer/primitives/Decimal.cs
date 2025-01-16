namespace simpleline.services.executor.main.typizer.primitives;

internal class Decimal {
    public static object Typize(string value) {
        return decimal.Parse(value);
    }
}