namespace SimpleLineLibrary.Services.Parsing
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