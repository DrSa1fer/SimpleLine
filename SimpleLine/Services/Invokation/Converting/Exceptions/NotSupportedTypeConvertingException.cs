using SimpleLineLibrary.Exceptions;

namespace SimpleLineLibrary.Services.Invokation.Converting.Exceptions
{
    internal class NotSupportedTypeConvertingException : SimpleLineException
    {
        internal NotSupportedTypeConvertingException(Type type)
            : base($"Type {type} is not supported. Register that before use")
        {
        }
    }
}
