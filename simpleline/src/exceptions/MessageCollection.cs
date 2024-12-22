using System.Collections;

namespace simpleline.exceptions;

public class MessageCollection : IReadOnlyCollection<Message>
{
    private readonly IReadOnlyDictionary<MessageCodes, Message> _msg = new Dictionary<MessageCodes, Message>
    {
        { MessageCodes.NotImplemented, new Message("Not implemented method $") }
    };

    public Message this[MessageCodes index]
        => _msg[index];
    public Message this[int index]
        => _msg[(MessageCodes)index];
    
    public int Count
        => _msg.Count;
    public IEnumerator<Message> GetEnumerator() 
        => _msg.Values.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() 
        => _msg.Values.GetEnumerator();
}