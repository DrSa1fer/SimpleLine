using System.Text;

namespace simpleline.exceptions;

public sealed class Message(string messageText)
{
    public const char Replace = '$';

    public string Text { get; } = messageText;

    public string Format(string[] args)
    {
        var sb = new StringBuilder();

        var i = 0;

        foreach (var c in Text)
        {
            if (c.Equals(Replace))
                if (i < args.Length)
                {
                    sb.Append(args[i++]);
                    continue;
                }

            sb.Append(c);
        }

        return sb.ToString();
    }
}