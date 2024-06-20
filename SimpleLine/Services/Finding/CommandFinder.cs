using SimpleLineLibrary.Models;

namespace SimpleLineLibrary.Services.Finding
{
    internal sealed class CommandFinder
    {
        public Command? Find(Queue<string> args, IEnumerable<Command> roots)
        {            
            if(!args.TryPeek(out string? name))
            {
                return null;
            }
           
            var root = roots.FirstOrDefault(x => x.Is(name));

            if (root == null)
            {
                return null;
            }

            while (args.Count > 0)
            {
                args.Dequeue(); //skip root in first pass

                if (!args.TryPeek(out string? peek))
                {
                    break;
                }

                var temp = root.Subcommands.FirstOrDefault(x => x.Is(peek));

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