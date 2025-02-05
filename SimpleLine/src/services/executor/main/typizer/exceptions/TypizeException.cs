namespace simpleline.services.executor.typizer.exceptions;

internal class TypizeException(Exception innerException) : Exception(innerException.Message, innerException);