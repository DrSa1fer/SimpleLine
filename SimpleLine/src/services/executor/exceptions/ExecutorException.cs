namespace simpleline.services.executor.exceptions;

internal class ExecutorException(Exception innerException) : Exception(innerException.Message, innerException);