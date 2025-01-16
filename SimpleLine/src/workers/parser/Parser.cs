using simpleline.configs;
using simpleline.helpers;
using simpleline.services;

namespace simpleline.workers.parser;

internal class Parser(ParseConfig conf) : ParserBase {
    protected override Symbol[] OnParse(IEnumerable<string> args) {
        var ls = new List<Symbol>();
        var fArgs = args
            // It s a responsibility of parser?
            // .SelectMany(arg => arg.Split("="))
            // .Select(x => x.Trim())
            .Where(x => !string.IsNullOrWhiteSpace(x));

        foreach (var arg in fArgs) {
            var prefix = conf.KeyPrefixes.FirstOrDefault(arg.HStartsWith);

            if (prefix == null) {
                ls.Add(Symbol.CreateValue(arg));
                continue;
            }

            if (prefix.Length == arg.Length) {
                throw new ArgumentException($"Awaits value after prefix: [{arg}]");
            }

            var t = arg[prefix.Length..];
            if (conf.GnuKeyMode && prefix.Length == 1) {
                ls.AddRange(t.Select(c => Symbol.CreateKey(c.ToString())));
            }
            else {
                ls.Add(Symbol.CreateKey(t));
            }
        }

        return ls.ToArray();
    }
}