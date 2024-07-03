using SimpleLineLibrary.Models;

namespace SimpleLineLibrary.Services.CommandFinding
{
    internal class CommandFinder
    {
        public Command Find(Queue<string> args, Command root)
        {
            while (args.TryPeek(out string? peek))
            {
                if (!root.Children.ContainsKey(peek))
                {
                    break;
                }

                root = root.Children[peek];
                args.Dequeue();
            }

            return root;
        }
    }
}