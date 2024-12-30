namespace simpleline.exceptions;

public class MessageException : Exception
{
    public MessageException(MessageCodes code, params string[] args)
        : base(ExceptionMessages[code].Format(args))
    {
    }

    public MessageException(int code, params string[] args)
        : base(ExceptionMessages[code].Format(args))
    {
    }

    private static readonly MessageCollection ExceptionMessages = new();
}