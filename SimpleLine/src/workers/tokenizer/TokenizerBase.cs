namespace simpleline.workers.tokenizer;

internal abstract class TokenizerBase
{
    public IEnumerable<string> Tokenize(string input)
    {
        try
        {
            return OnTokenize(input);
        }
        catch (Exception e)
        {
            //TODO
            throw;
        }
    }

    protected abstract IEnumerable<string> OnTokenize(string input);
}