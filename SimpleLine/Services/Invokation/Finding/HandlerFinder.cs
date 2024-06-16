using SimpleLineLibrary.Extensions;
using SimpleLineLibrary.Models;

namespace SimpleLineLibrary.Services.Invokation.Finding
{
    internal class HandlerFinder
    {
        public Handler? Find(Queue<string> args, IEnumerable<Handler> handlers)
        {
            var byKey = FindByHandlerKey(handlers, args.Peek());

            if(byKey != null)
            {
                args.Dequeue();
                return byKey;
            }

            var byPar = FindByParamKeys(handlers, args);

            if(byPar != null)
            {
                return byPar;
            }

            return null;
        }  

        private Handler? FindByHandlerKey(IEnumerable<Handler> handlers, string key) 
        {
            Handler? handler = null;

            foreach(var h in handlers)
            {               
                if(h.HasKey && h.Key.IsEqualsTokenName(key))
                {
                    if (handler != null)
                    {
                        throw new Exceptions.ArgumentException("36");
                    }

                    handler = h;
                }
            }

            return handler;
        }

        private Handler? FindByParamKeys(IEnumerable<Handler> handlers, Queue<string> args)
        {
            //var keys = args.Where(x => x.IsKeyTokenName()).ToHashSet();

            Handler? handler = null;

           /* foreach (var h in handlers)
            {
                if (h.)
                {
                    if (handler != null)
                    {
                        throw new Exceptions.ArgumentException("36");
                    }
                }
            }
           */

            return handler;
        }
    }
}
