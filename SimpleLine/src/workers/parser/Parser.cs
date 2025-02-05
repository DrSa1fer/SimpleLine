using simpleline.configs;
using simpleline.helpers;
using simpleline.services;

namespace simpleline.workers.parser;

internal class Parser(ParseConfig conf) : ParserBase {
    protected override IEnumerable<Symbol> OnParse(IEnumerable<string> args) {
        var ls = new List<Symbol>();
        var fArgs = args.Where(x => !string.IsNullOrWhiteSpace(x));

        foreach (var arg in fArgs) {
            if (Path.Exists(arg)) {
                ls.Add(new Symbol(false, arg));
                continue;
            }
            
            if (conf.KeyPrefixes.FirstOrDefault(arg.HStartsWith) is {} prefix && prefix.Length < arg.Length) {
                
                if (conf.GnuKeyMode && prefix.Length == 1) {
                    ls.AddRange(arg[prefix.Length..].Select(c => new Symbol(true, c.ToString())));
                }
                else {
                    ls.Add(new Symbol(true, arg[prefix.Length..]));
                }
                
                continue;
            }
            
            ls.Add(new Symbol(false, arg));
        }
        
        return ls;
    }
}