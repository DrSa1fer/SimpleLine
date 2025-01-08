namespace simpleline.services.executor.main.typizer.primitives;

internal class Int32 : Primitive {
    public override object? Bind(string value) {
        return int.Parse(value);
    }
}