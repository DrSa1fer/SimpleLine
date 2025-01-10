namespace simpleline.services.router.exceptions;

internal class RouterException(Exception innerException) : Exception(innerException.Message, innerException);