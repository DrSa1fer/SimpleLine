using simpleline.services;

namespace simpleline.workers.parser;

internal abstract class ParserBase
{
    public Input Parse(IEnumerable<string> args)
    {
        try
        {
            return OnParse(args);
        }
        catch (Exception e)
        {
            //todo
            throw;
        }
    }

    protected abstract Input OnParse(IEnumerable<string> args);
}