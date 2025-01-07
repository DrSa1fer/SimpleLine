using simpleline.services;

namespace simpleline.workers.parser;

internal abstract class ParserBase
{
    public Input Parse(IEnumerable<string> args)
    {
        try
        {
            var ls = OnParse(args).ToList();
            return new Input(ls);
        }
        catch (Exception e)
        {
            //todo
            throw;
        }    
    }
    
    protected abstract IEnumerable<Symbol> OnParse(IEnumerable<string> args);
}