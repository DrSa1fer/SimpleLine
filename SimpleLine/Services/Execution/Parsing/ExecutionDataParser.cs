using SimpleLineLibrary.Extentions;

namespace SimpleLineLibrary.Services.Execution.Parsing
{
    internal class ExecutionDataParser
    {
        public ExecutionData Parse(Queue<string> args)
        {
            var named = new Dictionary<string, List<string>>();
            var posed = new Dictionary<int, List<string>>();

            int pos = 0;

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
                    
                    if(!named.ContainsKey(key) || named[key] == null)
                    {
                        named[key] = new List<string>();
                    }

                    named[key].Add(value);
                    continue;
                }                    
                if (IsValue(args.Peek()))
                {
                    string value = args.Dequeue();
                    
                    if(!posed.ContainsKey(pos) || posed[pos] == null)
                    {
                        posed[pos] = new List<string>();
                    }

                    posed[pos++].Add(value);
                    continue;
                }
               
                throw new ArgumentException($"Invalid token in this context {args.Peek()}");                
            }

            var ndict = named.ToDictionary(x => x.Key, x => (IEnumerable<string>)x.Value);
            var pdict = posed.ToDictionary(x => x.Key, x => (IEnumerable<string>)x.Value);

            return new ExecutionData(ndict, pdict);


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