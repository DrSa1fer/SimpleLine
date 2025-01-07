namespace simpleline.services.executor.main.invoker.exceptions;

internal class InvokeException(Exception innerException) : Exception(innerException.Message, innerException);