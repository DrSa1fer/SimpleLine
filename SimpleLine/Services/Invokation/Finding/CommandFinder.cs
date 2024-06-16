using SimpleLineLibrary.Extensions;
using SimpleLineLibrary.Models;


namespace SimpleLineLibrary.Services.Invokation.Finding
{
    internal sealed class CommandFinder
    {
        private readonly string _rootName;

        public CommandFinder(string rootCommand = "@root")
        {
            _rootName = rootCommand;
        }

        public Command? Find(Queue<string> args, IReadOnlyList<Command> roots)
        {
            if (args is null)
            {
                return null;
            }

            if(roots is null || roots.Count < 1)
            {
                return null;
            }

            var name = _rootName;

            if (args.Count > 0)
            {
                name = args.Peek();
            }

            var root = roots
                .FirstOrDefault(x => x.Name.IsEqualsTokenName(name));

            if (root == null)
            {
                return null;
            }

            while (args.Any())
            {
                args.Dequeue();

                var peek = args.Peek();
                
                var temp = root
                    .Subcommands
                    .FirstOrDefault(x => x.Name.IsEqualsTokenName(peek));

                if (temp == null)
                {
                    break;
                }

                root = temp;  
            }

            return root;
        }
    } 
}