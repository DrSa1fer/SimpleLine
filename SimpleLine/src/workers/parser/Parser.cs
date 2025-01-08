using simpleline.configs;
using simpleline.services;

namespace simpleline.workers.parser;

internal class Parser(ParserConfig conf) : ParserBase {
    protected override Symbol[] OnParse(IEnumerable<string> args) {
        var ls = new List<Symbol>();

        foreach (var arg in args) {
            if (arg.StartsWith(conf.ShortKeyPrefix)) {
                var t = arg[conf.ShortKeyPrefix.Length..];
                ArgumentException.ThrowIfNullOrEmpty(t);

                if (conf.UseShortKeySplitting)
                    ls.AddRange(t.Select(c => Symbol.CreateKey(c.ToString())));
                else
                    ls.Add(Symbol.CreateKey(t));

                continue;
            }

            if (arg.StartsWith(conf.LongKeyPrefix)) {
                var t = arg[conf.LongKeyPrefix.Length..];
                ArgumentException.ThrowIfNullOrEmpty(t);

                ls.Add(Symbol.CreateKey(t));
                continue;
            }

            ls.Add(Symbol.CreateValue(arg));
        }

        return ls.ToArray();
    }
}