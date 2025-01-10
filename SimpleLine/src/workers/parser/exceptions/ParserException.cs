namespace simpleline.workers.parser.exceptions;

internal class ParserException(Exception innerException) : Exception(innerException.Message, innerException);