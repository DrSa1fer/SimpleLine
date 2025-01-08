namespace simpleline.workers.tokenizer.exceptions;

public class TokenizerException(Exception innerException) : Exception(innerException.Message, innerException);