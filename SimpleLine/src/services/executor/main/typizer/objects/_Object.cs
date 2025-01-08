using simpleline.services.executor.main.typizer.primitives;

namespace simpleline.services.executor.main.typizer.objects;

internal abstract class Object {
    public abstract object? Typize(
        IEnumerable<string> values,
        Func<Type, Object> @object,
        Func<Type, Primitive> primitive
    );
}