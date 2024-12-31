namespace simpleline.services.typizer.primitives;

internal class Object : Primitive
{
    public override object? Bind(string value)
    {
        return new InnerObject(value);
    }

    private class InnerObject(string value)
    {
        public override string ToString()
        {
            return value;
        }
    }
}