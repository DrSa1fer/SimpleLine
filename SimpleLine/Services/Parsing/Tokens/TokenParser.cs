namespace SimpleLineLibrary.Services.Parsing.Tokens
{
    internal class TokenParser
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
            return new();
        }
    }
}