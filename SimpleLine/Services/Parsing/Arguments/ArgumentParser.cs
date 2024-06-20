using SimpleLineLibrary.Extentions.Strings;
using SimpleLineLibrary.Services.Parsing.Arguments.Exceptions;

namespace SimpleLineLibrary.Services.Parsing.Arguments
{
    internal class ArgumentParser
    {
        public List<Argument> Parse(Queue<string> args)
        {
            var ls = new List<Argument>();

            while (args.Count > 0)
            {
                if (IsKey(args.Peek()))
                {
                    string key = args.Dequeue();
                    string value = string.Empty;

                    if(args.TryPeek(out string? nextToken))
                    {
                        if (IsEqualSign(nextToken))
                        {
                            args.Dequeue(); //skip '='

                            if (args.TryDequeue(out string? keyValue))
                            {
                                value = keyValue;
                            }
                            else
                            {
                                throw new KeyAwaitsValueException(key);
                            }
                        }
                        else if (IsValue(nextToken))
                        {
                            value = args.Dequeue();
                        }
                    }

                    var arg = new Argument(key, value);

                    ls.Add(arg);
                }
                else if (IsValue(args.Peek()))
                {
                    string key = string.Empty;
                    string value = args.Dequeue();

                    var arg = new Argument(key, value);

                    ls.Add(arg);
                }
            }

            Console.WriteLine(string.Join(", ", ls.Select(x => x.Key + " " + x.Value)));

            return ls;
        }

        private static bool IsKey(string token)
        {
            return token.IsKeyTokenName();
        }
        private static bool IsValue(string token)
        {
            return !IsKey(token);
        }
        private static bool IsEqualSign(string token)
        {
            return token.IsEqualsTokenName("=");
        }
    }
}
