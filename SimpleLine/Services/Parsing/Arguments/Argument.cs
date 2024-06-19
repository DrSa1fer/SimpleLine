namespace SimpleLineLibrary.Services.Parsing.Arguments
{
    /// <summary>
    /// ������������� ��������� "--key value" �� ����� � ���� �������    
    /// </summary>
    internal class Argument
    {
        public string Key { get; }
        public string Value { get; }
        public int Position { get; }

        public Argument(string key = "", string value = "", int position = 0)
        {
            Key = key;
            Value = value;

            if (!HasKey() && !HasValue())
            {
                throw new ArgumentNullException("� ������ �� �����. ���� null, �������� null");
            }

            Position = position;
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