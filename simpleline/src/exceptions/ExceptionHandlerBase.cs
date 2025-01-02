namespace simpleline.exceptions;

public abstract class ExceptionHandlerBase
{
    public abstract bool Is(Exception exception);
    public abstract void Handle(Exception exception);
}