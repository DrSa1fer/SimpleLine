using SimpleLineLibrary.Extentions;

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
            Name= name;
            Description= desc;
            LongKey = longKey;
            ShortKey = shortKey;
           
            Position = position;
            ValueType = valueType;
            IsRequired = isRequired;
            DefaultValue = defValue;
        }                

        public bool Is(string key)
        {
            return key.IsEqualsToken(ShortKey) || key.IsEqualsToken(LongKey);
        }

        public override bool Equals(object? obj)
        {
            return obj is Parameter other 
                && Is(other.LongKey) 
                && Is(other.ShortKey);
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(IsRequired, Position, LongKey, ShortKey);
        }      
    }
}