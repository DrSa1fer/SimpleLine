using SimpleLineLibrary.Extentions;
using SimpleLineLibrary.Setup;
using System.Reflection;

namespace SimpleLineLibrary.Services.Finding.Reading
{
    internal class CommandDefinitionsReader
    {
        internal Dictionary<string, CommandDefinition> GetDefinitions(IEnumerable<TypeInfo> types)
        {
            var root = new CommandDefinition("");

            foreach (var t in types.Where(x => x.IsClass && !x.IsAbstract))
            {
                var defAttr = t.GetCustomAttribute<CommandDefinitionsAttribute>();

                if (defAttr == null)
                {
                    continue;
                }

                var defRoot = root;
                var defTokens = defAttr.Command.SplitAndRemoveEmptyEntries(' ');
                
                if (defTokens.Length > 0)
                {
                    foreach (var defToken in defTokens)
                    {
                        defToken.ThrowIfWrongTokenName();
                    }

                    defRoot = MakeDefinition(defRoot, defTokens);
                }

                foreach (var m in t.GetMethods())
                {
                    var comAttr = m.GetCustomAttribute<CommandAttribute>();

                    if (comAttr == null)
                    {
                        continue;
                    }

                    if (m.IsAbstract)
                    {
                        throw new NotSupportedException("Abstract method is not supported");
                    }

                    if (m.IsGenericMethod)
                    {
                        throw new NotSupportedException("Generic method is not supported");
                    }

                    var comRoot = defRoot;
                    var comTokens = comAttr.Command.SplitAndRemoveEmptyEntries(' ');

                    if (comTokens.Length < 1)
                    {
                        throw new ArgumentException("Empty command name");
                    }

                    foreach (var comToken in comTokens)
                    {
                        comToken.ThrowIfWrongTokenName();
                    }

                    comRoot = MakeDefinition(comRoot, comTokens);

                    if(comRoot.Method != null || comRoot.Type != null)
                    {
                        throw new Exception($"Already register command to uid \"{comRoot.Uid}\"");
                    }

                    comRoot.Type = t;
                    comRoot.Method = m;
                }
            }

            return root.Subcommands;
        }

        private static CommandDefinition MakeDefinition(CommandDefinition root, string[] tokens)
        {
            var locRoot = root;

            for (int i = 0; i < tokens.Length; i++)
            {
                var token = tokens[i];

                if (locRoot.Subcommands.ContainsKey(token))
                {
                    locRoot = locRoot.Subcommands[token];
                }
                else
                {
                    var temp = new CommandDefinition(token);

                    locRoot .Subcommands[temp.Uid] = temp;
                    locRoot = temp;
                }
            }

            return locRoot;
        }
    }
}