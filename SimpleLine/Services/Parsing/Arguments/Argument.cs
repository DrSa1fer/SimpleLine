namespace SimpleLineLibrary.Services.Parsing.Arguments
{
    /// <summary>
    /// ������������� ��������� "--key value" �� ����� � ���� �������    
    /// </summary>
    internal class Argument
    {
        public string Key { get; }
        public string Value { get; }

        public Argument(string key = "", string value = "")
        {
            Key = key;
            Value = value;

            if (!HasKey() && !HasValue())
            {
                throw new ArgumentNullException("� ������ �� �����. ���� null, �������� null");
            }
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