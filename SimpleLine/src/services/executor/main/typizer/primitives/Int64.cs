namespace simpleline.services.executor.main.typizer.primitives;

internal class Int64 : Primitive {
    public override object? Bind(string value) {
        return long.Parse(value);
    }
}