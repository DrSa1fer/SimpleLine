using SimpleLineLibrary.Extentions;

namespace SimpleLineLibrary.Services.Execution.Parsing
{
    internal class ExecutionDataParser
    {
        public ExecutionData Parse(Queue<string> args)
        {
            var named = new Dictionary<string, ICollection<string>>(args.Count / 2);
            var posed = new Dictionary<int, ICollection<string>>(args.Count / 4);

            int pos = 0;

            while (args.Count > 0)
            {
                var peek = args.Peek();

                if (IsKey(peek))
                {
                    string key = args.Dequeue();
                    string value = string.Empty;

                    if (args.TryPeek(out string? nextToken))
                    {
                        if (IsEqualSign(nextToken))
                        {
                            args.Dequeue(); //skip '='

                            if (!args.TryDequeue(out string? keyValue))
                            {
                                throw new ArgumentException($"key {key} wait value after '=' ");
                            }

                            value = keyValue;
                        }
                        else if (IsValue(nextToken))
                        {
                            value = args.Dequeue();
                        }
                    }

                    if (!named.ContainsKey(key) || named[key] == null)
                    {
                        named[key] = new List<string>(2);
                    }

                    named[key].Add(value);
                    continue;
                }
                if (IsValue(peek))
                {
                    string value = args.Dequeue();

                    if (!posed.ContainsKey(pos) || posed[pos] == null)
                    {
                        posed[pos] = new List<string>(2);
                    }

                    posed[pos++].Add(value);
                    continue;
                }

                throw new ArgumentException($"Invalid token in current context {peek}");
            }

            return new ExecutionData(named, posed);


            bool IsKey(string token)
            {
                return token.IsKeyTokenName();
            }
            bool IsCombine(string token)
            {
                return token.IsEqualsToken(",");
            }
            bool IsEqualSign(string token)
            {
                return token.IsEqualsToken("=");
            }
            bool IsValue(string token)
            {
                return !IsKey(token) && !IsCombine(token) && !IsEqualSign(token);
            }
        }
    }
}