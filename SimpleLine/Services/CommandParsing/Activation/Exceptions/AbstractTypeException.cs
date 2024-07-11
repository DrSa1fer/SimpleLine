using SimpleLineLibrary.Exceptions;

namespace SimpleLineLibrary.Services.CommandParsing.Activation.Exceptions
{
    internal class AbstractTypeException : SimpleLineException
    {
        public AbstractTypeException(Type type)
            : base($"Type \"{type}\" must be not abstract")
        {
        }
    }
}
