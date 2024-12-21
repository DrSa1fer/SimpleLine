namespace simpleline.exceptions;

public sealed class Message(string messageText)
{
    public string Text { get; } = messageText;

    public string Format(string[] args)
    {
        throw new NotImplementedException();
    }
}