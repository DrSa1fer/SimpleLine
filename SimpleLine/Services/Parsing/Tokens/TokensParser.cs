namespace SimpleLineLibrary.Services.Parsing.Tokens
{
    public class TokensParser
    {
        private Dictionary<char, char> _borders = new()
        {
            { '(' , ')'  },
            { '[' , ']'  },
            { '\"', '\"' },
            { '\'', '\'' },
            { '<' , '>'  },
        };

        public List<string> Parse(string input)
        {
            input = input.Trim();

            var start = 0;
            var open = false;

            char? end = null;

            var ls = new List<string>();

            for (int i = start; i < input.Length; i++)
            {
                if (char.IsWhiteSpace(input[i]))
                {
                    if (open)
                    {
                        if (i > 0 && input[i - 1] == end)
                        {
                            open = false;
                        }
                        else
                        {
                            continue;
                        }
                    }

                    var word = input[start..i].Trim();

                    if (word.Length > 0)
                    {
                        ls.Add(word);
                    }

                    start = i + 1;
                }

                if (!open
                    && (i == 0 || i > 0 && char.IsWhiteSpace(input[i - 1]) && input[i - 1] != '\\')
                    && _borders.TryGetValue(input[i], out char e))
                {
                    open = true;
                    end = e;
                }
            }

            ls.Add(input[start..]);

            return null!;
        }
    }
}