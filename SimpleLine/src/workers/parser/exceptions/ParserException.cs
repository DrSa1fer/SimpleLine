namespace simpleline.workers.parser.exceptions;

public class ParserException(Exception innerException) : Exception(innerException.Message, innerException);