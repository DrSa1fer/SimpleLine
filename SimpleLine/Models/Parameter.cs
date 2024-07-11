namespace SimpleLineLibrary.Models
{
    internal sealed class Parameter
    {
        public string Name { get; }
        public string Description { get; }
        public string LongKey { get; }
        public string ShortKey { get; }
        public int Position { get; }
        public Type ValueType { get; }
        public bool IsRequired { get; }
        public object? DefaultValue { get; }
        public bool HasDefaultValue { get; }

        public Parameter(
            string name, string desc,
            string longKey, string shortKey,
            int position, bool isRequired,
            Type valueType, object? defValue)
        {
            Name = name;
            Description = desc;
            LongKey = longKey;
            ShortKey = shortKey;

            Position = position;
            ValueType = valueType;
            IsRequired = isRequired;
            DefaultValue = defValue;

            HasDefaultValue = valueType.IsAssignableTo(typeof(Nullable)) || defValue != null;
        }
    }
}