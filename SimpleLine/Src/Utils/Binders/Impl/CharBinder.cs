using SimpleLineLibrary.Src.Exceptions.BinderExceptions;

namespace SimpleLineLibrary.Src.Utils.Binders
{
    public class CharBinder : IValueBinder<char>
    {
        public char Bind(string value)
        {
            if(value.Length == 1)
            {
                return value[0];
            }
            throw new ConvertException(value, "char");
        }
    }
}
