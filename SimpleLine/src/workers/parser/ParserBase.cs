using simpleline.services;
using simpleline.workers.parser.exceptions;

namespace simpleline.workers.parser;

internal abstract class ParserBase {
    public Symbol[] Parse(IEnumerable<string> args) {
        try {
            return OnParse(args);
        }
        catch (Exception e) {
            throw new ParserException(e);
        }
    }

    protected abstract Symbol[] OnParse(IEnumerable<string> args);
}