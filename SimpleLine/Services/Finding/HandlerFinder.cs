using SimpleLineLibrary.Extensions;
using SimpleLineLibrary.Models;

namespace SimpleLineLibrary.Services.Finding
{
    internal class HandlerFinder
    {
        public Handler? Find(Queue<string> args, IEnumerable<Handler> handlers)
        {
            var hs = handlers;

            var peek = args.Peek();

            if (peek.IsKeyTokenName())
            {
                var filtered = handlers.Where(h => h.HasKey && h.Key.IsEqualsTokenName(peek));

                if (filtered.Any())
                {
                    args.Dequeue();
                    return filtered.Single();
                }
            }

            var withouKey = handlers.Where(x => !x.HasKey);

            return withouKey.SingleOrDefault();
        }
    }
}