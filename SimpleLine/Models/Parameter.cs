using SimpleLineLibrary.Extentions.Strings;

namespace SimpleLineLibrary.Models
{
    internal sealed class Parameter
    {
        public string Name
        {
            get
            {
                return _name;
            }
        }
        public string Description
        {
            get
            {
                return _description;
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

        private readonly string _name;
        private readonly string _description;
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
        {
            name.ThrowIfWrongTokenName();
            desc.ThrowIfWrongText();

            longKey.ThrowIfWrongKeyTokenName();
            shortKey.ThrowIfWrongKeyTokenName();

            _name= name;
            _description= desc;
            _longkey = longKey;
            _shortkey = shortKey;
           
            _position = position;
            _valueType = valueType;
            _isRequired = isRequired;
            _defValue = defValue;
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
            return HashCode.Combine(IsRequired, Position, _longkey, _shortkey);
        }      
    }
}