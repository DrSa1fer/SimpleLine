using System.Collections;

namespace simpleline.exceptions;

public class MessageCollection : IReadOnlyCollection<Message>
{
    private readonly IReadOnlyDictionary<int, Message> _msg = new Dictionary<int, Message>
    {
        { 0, new Message("Not implemented") }
    };

    public Message this[int index]
        => _msg[index];

    public int Count
        => _msg.Count;

    public IEnumerator<Message> GetEnumerator()
    {
        return _msg.Values.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return _msg.Values.GetEnumerator();
    }
}