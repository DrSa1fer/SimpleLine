namespace simpleline.exceptions;

public class MessageException(int code, params string[] args)
    : Exception(ExceptionMessages[code].Format(args))
{
    private static readonly MessageCollection ExceptionMessages = new();
}