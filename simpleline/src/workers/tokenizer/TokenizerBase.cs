namespace simpleline.workers.tokenizer;

internal abstract class TokenizerBase
{
    public abstract IEnumerable<string> Tokenize(string input);
}