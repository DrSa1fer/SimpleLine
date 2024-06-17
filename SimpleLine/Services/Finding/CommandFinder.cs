using SimpleLineLibrary.Extensions;
using SimpleLineLibrary.Models;

namespace SimpleLineLibrary.Services.Finding
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

            if (roots is null || roots.Count < 1)
            {
                return null;
            }

            var name = _rootName;

            if (args.Count > 0)
            {
                name = args.Peek();
            }

            var root = roots
                .FirstOrDefault(x => x.Is(name));

            if (root == null)
            {
                return null;
            }

            while (args.Any())
            {
                args.Dequeue(); //skip root

                var peek = args.Peek();
                var temp = root
                    .Subcommands
                    .FirstOrDefault(x => x.Is(peek));

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