namespace simpleline.services.binder.exceptions;

internal class BindException : Exception
{
    public BindException(Exception inner) : base("", inner)
    {
        
    }
}