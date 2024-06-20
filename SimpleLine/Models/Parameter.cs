using SimpleLineLibrary.Extentions.Strings;

namespace SimpleLineLibrary.Models
{
    internal sealed class Parameter : BaseEntity
    {        
        public Type ValueType
        {
            get
            {
                return _valueType;
            }
        }
        public bool IsRequired
        {
            get
            {
                return _isRequired;
            }
        }
        public string LongKey
        {
            get
            {
                return _longkey;
            }
        }
        public string ShortKey
        {
            get
            {
                return _shortkey;
            }
        }
        public int Position
        {
            get
            {
                return _position;
            }
        }
        public object? DefaultValue
        {
            get
            {
                return _defValue;
            }
        }
        public bool HasDefaultValue
        {
            get
            {
                return DefaultValue is not null;
            }
        }

        private readonly string _longkey;
        private readonly string _shortkey;
        private readonly Type _valueType;
        private readonly bool _isRequired;
        private readonly int _position;
        private readonly object? _defValue;
        
        public Parameter(
            string name, string desc,
            string longKey, string shortKey,
            int position, bool isRequired,
            Type valueType, object? defValue) 
            : base(name, desc, false, true)
        {

            longKey.ThrowIfWrongKeyTokenName();
            shortKey.ThrowIfWrongKeyTokenName();

            _longkey = longKey;
            _shortkey = shortKey;
           
            _position = position;
            _valueType = valueType;
            _isRequired = isRequired;
            _defValue = defValue;
        }                

        public bool Is(string key)
        {
            return false 
                || key.IsEqualsTokenName(this.ShortKey) 
                || key.IsEqualsTokenName(this.LongKey);
        }

        public override bool Equals(object? obj)
        {
            return obj is Parameter other 
                && Is(other.LongKey) 
                && Is(other.ShortKey);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(IsRequired, Position, _longkey, _shortkey);
        }      
    }
}