using simpleline.workers.tokenizer.exceptions;

namespace simpleline.workers.tokenizer;

public abstract class TokenizerBase {
    public IEnumerable<string> Tokenize(string input) {
        try {
            return OnTokenize(input);
        }
        catch (Exception e) {
            throw new TokenizerException(e);
        }
    }

    protected abstract IEnumerable<string> OnTokenize(string input);
}