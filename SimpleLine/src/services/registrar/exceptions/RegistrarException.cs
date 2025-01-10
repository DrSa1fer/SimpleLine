namespace simpleline.services.registrar.exceptions;

internal class RegistrarException(Exception innerException) : Exception(innerException.Message, innerException);