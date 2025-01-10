namespace simpleline.workers.tokenizer.exceptions;

internal class TokenizerException(Exception innerException) : Exception(innerException.Message, innerException);