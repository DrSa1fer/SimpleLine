namespace simpleline.services.registrar.exceptions;

public class RegistrarException(Exception innerException) : Exception(innerException.Message, innerException);