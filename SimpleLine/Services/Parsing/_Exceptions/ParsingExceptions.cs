using SimpleLineLibrary.Exceptions;
using System.Runtime.Serialization;

namespace SimpleLineLibrary.Services.Parsing.Exceptions
{
    internal class ParsingExceptions : SimpleLineException
    {
        public ParsingExceptions()
        {
        }

        public ParsingExceptions(string? message) : base(message)
        {
        }

        public ParsingExceptions(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public ParsingExceptions(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
