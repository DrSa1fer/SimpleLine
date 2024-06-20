using SimpleLineLibrary.Extentions.Strings;
using SimpleLineLibrary.Models;

namespace SimpleLineLibrary.Services.Finding
{
    internal class HandlerFinder
    {
        public Handler? Find(Queue<string> args, Handler handler)
        {
            return handler;
        }
    }
}