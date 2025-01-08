namespace simpleline.services.router.exceptions;

public class RouterException(Exception innerException) : Exception(innerException.Message, innerException);