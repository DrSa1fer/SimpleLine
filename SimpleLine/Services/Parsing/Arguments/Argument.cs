namespace SimpleLineLibrary.Services.Parsing.Arguments
{
    /// <summary>
    ///    
    /// </summary>
    internal class Argument
    {
        public string Key { get; init; }
        public string Value { get; init; }
        public int Position { get; init; }

        public Argument()
        {
            Key = "";
            Value = "";
            Position = -1;
        }

        public bool HasKey()
        {
            return Key is not null && Key.Length > 0;
        }
        public bool HasValue()
        {
            return Value is not null && Value.Length > 0;
        }
    }
}