using SimpleLineLibrary.Extentions;
using SimpleLineLibrary.Services.Parsing.Arguments.Exceptions;

namespace SimpleLineLibrary.Services.Parsing.Arguments
{
    internal class ArgumentParser
    {
        public List<Argument> Parse(Queue<string> args)
        {
            var ls = new List<Argument>();
            int pos = 0;

            while (args.TryPeek(out string? current))
            { 

                if (IsKey(current))
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

                    var arg = new Argument
                    {
                        Key = key, 
                        Value = value
                    };
                    
                    ls.Add(arg);
                }
                else if(IsValue(current))
                {
                    string key = string.Empty;
                    string value = args.Dequeue();

                    var arg = new Argument
                    {
                        Key = key, 
                        Value = value, 
                        Position = pos
                    };

                    ls.Add(arg);
                }

                if(args.TryPeek(out var combine) && IsCombine(combine))
                {
                    args.Dequeue();
                }
                else
                {
                    pos++;
                }
            }

            return ls;
        }

        private static bool IsKey(string token)
        {
            return token.IsKeyTokenName();
        }
        private static bool IsValue(string token)
        {
            return !IsKey(token) 
                && !IsCombine(token)
                && !IsEqualSign(token);
        }
        private static bool IsCombine(string token)
        {
            return token.IsEqualsToken("&");
        }
        private static bool IsEqualSign(string token)
        {
            return token.IsEqualsToken("=");
        }
    }
}