namespace simpleline.services.executor.main.binder.exceptions;

internal class BindException(Exception innerException) : Exception(innerException.Message, innerException);