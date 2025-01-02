namespace simpleline.exceptions;

public abstract class ExceptionHandlerBase<T> : ExceptionHandlerBase where T : Exception
{
    public override bool Is(Exception exception)
    {
        return exception is T;
    }

    public override void Handle(Exception exception)
    {
        OnHandle((T)exception);
    }
    
    protected abstract void OnHandle(T exception);
}