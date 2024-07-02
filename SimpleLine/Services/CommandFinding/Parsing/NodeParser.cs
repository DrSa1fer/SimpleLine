using SimpleLineLibrary.Extentions;
using SimpleLineLibrary.Setup;
using System.Reflection;

namespace SimpleLineLibrary.Services.CommandFinding.Parsing
{
    internal class NodeParser
    {
        private readonly string _contextOperator;

        public NodeParser(string contexOperator)
        {
            _contextOperator = contexOperator;
        }

        internal Node GetNode(IEnumerable<TypeInfo> types)
        {
            var root = new Node("root");

            foreach (var t in types.Where(x => x.IsClass && !x.IsAbstract))
            {
                var defAttr = t.GetCustomAttribute<CommandDefinitionsAttribute>();

                if (defAttr == null)
                {
                    continue;
                }

                var defRoot = root;
                var defTokens = defAttr.Command.SplitOnTokens(' ');

                if (defTokens.Length > 0)
                {
                    foreach (var defToken in defTokens)
                    {
                        defToken.ThrowIfWrongTokenName();
                    }

                    defRoot = MakeNode(defRoot, defTokens);
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

                    if (!comAttr.Command.IsEqualsToken(_contextOperator))
                    {
                        var comTokens = comAttr.Command.SplitOnTokens(' ');

                        if (comTokens.Length < 1)
                        {
                            throw new ArgumentException("Empty command name");
                        }

                        foreach (var comToken in comTokens)
                        {
                            comToken.ThrowIfWrongTokenName();
                        }

                        comRoot = MakeNode(comRoot, comTokens);
                    }

                    if (comRoot.Method != null || comRoot.Type != null)
                    {
                        throw new Exception($"Already register command to uid \"{comRoot.Uid}\"");
                    }

                    comRoot.Type = t;
                    comRoot.Method = m;
                }
            }

            return root;
        }

        private static Node MakeNode(Node root, string[] tokens)
        {            
            for (int i = 0; i < tokens.Length; i++)
            {                
                if (!root.Subcommands.ContainsKey(tokens[i]))
                {
                    root.Subcommands[tokens[i]] = new Node(tokens[i]);                    
                }

                root = root.Subcommands[tokens[i]];
            }

            return root;
        }
    }
}