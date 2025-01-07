namespace simpleline.services.executor.main.typizer.exceptions;

internal class TypizeException(Exception innerException) : Exception(innerException.Message, innerException);