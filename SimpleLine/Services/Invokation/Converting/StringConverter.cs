namespace SimpleLineLibrary.Services.Invokation.Converting
{
    internal class StringConverter
    {
        public delegate bool TryConvert(string str, out object? obj);
        private Dictionary<Type, TryConvert> _dict;

        public StringConverter()
        {
            _dict = new();

            RegisterDefaultConverters();
        }

        public T ConvertTo<T>(string str)
        {
            if(_dict[typeof(T)].Invoke(str, out object? obj))
            {
                return (T)obj!;
            }

            throw new Exception("Convert exception");
        }

        public object? ConvertTo(string str, Type type)
        {
            if(_dict[type].Invoke(str, out object? obj))
            {
                return obj;
            }

            throw new Exception("Convert exception");
        }

        public bool TryConvertTo<T>(string str, out T value)
        {
            if(_dict[typeof(T)].Invoke(str, out object? obj))
            {
                value = (T)obj!;
                return true;
            }

            value = default!;
            return false;
        }

        public bool TryConvertTo(string str, Type type, out object? value)
        {
            if(_dict[type].Invoke(str, out object? obj))
            {
                value = obj;
                return true;
            }

            value = default!;
            return false;
        }


        public void RegisterConverter<T>(TryConvert converter)
        {
            _dict.Add(typeof(T), converter);
        }

        private void RegisterDefaultConverters()
        {
            RegisterConverter<int>((string str, out object? val) => 
            { 
                if(int.TryParse(str, out int i))
                {
                    val = i;
                    return true;
                }
                val = null;
                return false;
            });

            RegisterConverter<float>((string str, out object? val) => 
            { 
                if(float.TryParse(str, out float i))
                {
                    val = i;
                    return true;
                }
                val = null;
                return false;
            });

            RegisterConverter<bool>((string str, out object? val) => 
            { 
                if(bool.TryParse(str, out bool i))
                {
                    val = i;
                    return true;
                }
                val = null;
                return false;
            });

            RegisterConverter<string>((string str, out object? val) => 
            { 
                val = str;
                return true;                
            });
            
            RegisterConverter<char>((string str, out object? val) => 
            { 
                if(str.Length == 1)
                {
                    val = str[0];
                    return true;
                }
                val = null;
                return false;
            });

            RegisterConverter<DateTime>((string str, out object? val) => 
            { 
                if(DateTime.TryParse(str, out DateTime i))
                {
                    val = i;
                    return true;
                }
                val = null;
                return false;
            });

            RegisterConverter<FileInfo>((string str, out object? val) => 
            { 
                var info = new FileInfo(str);

                if(info.Exists)
                {
                    val = info;
                    return true;
                }

                val = null;
                return false;
            });

            RegisterConverter<DirectoryInfo>((string str, out object? val) => 
            { 
                var info = new DirectoryInfo(str);

                if(info.Exists)
                {
                    val = info;
                    return true;
                }

                val = null;
                return false;
            });
        }
    }
}