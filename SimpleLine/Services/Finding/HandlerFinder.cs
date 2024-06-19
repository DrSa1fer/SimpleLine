using SimpleLineLibrary.Models;
using SimpleLineLibrary.Utils.Strings;

namespace SimpleLineLibrary.Services.Finding
{
    internal class HandlerFinder
    {
        public Handler? Find(Queue<string> args, IEnumerable<Handler> handlers)
        {
            var hs = handlers;

            if (args.TryPeek(out var peek))
            {
                var filtered = handlers.Where(h => h.HasKey && h.Key.IsEqualsTokenName(peek));

                if (filtered.Any())
                {
                    args.Dequeue();
                    return filtered.Single();
                }

                var withouKey = handlers.Where(x => !x.HasKey);

                return withouKey.SingleOrDefault();
            }

            return null;
        }
    }
}