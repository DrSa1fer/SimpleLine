namespace simpleline.services.executor.main.typizer.primitives;

internal class Byte : Primitive {
    public override object? Bind(string value) {
        return byte.Parse(value);
    }
}