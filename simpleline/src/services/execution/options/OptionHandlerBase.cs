using System.Reflection;
using simpleline.models;

namespace simpleline.services.registration.reflection.options;

public abstract class OptionHandlerBase
{
    public abstract bool Is(IOptionMarker mark);
    public abstract Action<Context> Handle(IOptionMarker mark, Lazy<object>? instance, FieldInfo method);
}

public abstract class OptionHandlerBase<T> : OptionHandlerBase where T : IOptionMarker
{
    public sealed override bool Is(IOptionMarker mark)
    {
        return typeof(T) == mark.GetType();
    }

    public sealed override Action<Context> Handle(IOptionMarker mark, Lazy<object>? instance, FieldInfo field)
    {
        return Handle((T)mark, instance, field);
    }

    protected abstract void Handle(T mark, Func<object?> init);
}