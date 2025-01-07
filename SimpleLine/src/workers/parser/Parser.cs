using simpleline.configs;
using simpleline.services;

namespace simpleline.workers.parser;

internal class Parser(ParserConfig conf) : ParserBase
{
    protected override IEnumerable<Symbol> OnParse(IEnumerable<string> args)
    {
        foreach (var arg in args)
        {
            if (conf.ShortKey != null && arg.StartsWith(conf.ShortKey))
            {
                foreach (var c in arg[conf.ShortKey.Length..])
                    yield return Symbol.CreateKey(c.ToString());
                
                continue;
            }

            if (conf.LongKey != null && arg.StartsWith(conf.LongKey))
            {
                yield return Symbol.CreateKey(arg[conf.LongKey.Length..]);
                
                continue;
            }
            
            yield return Symbol.CreateValue(arg);
        }
    }
}