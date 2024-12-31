using simpleline.services.typizer.primitives;

namespace simpleline.services.typizer.objects;

internal abstract class Object
{
    public abstract object? Typize(
        IEnumerable<string> values,
        Func<Type, Object> @object,
        Func<Type, Primitive> primitive
    );
}