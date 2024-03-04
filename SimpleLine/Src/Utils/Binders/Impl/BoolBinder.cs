using SimpleLineLibrary.Src.Exceptions.BinderExceptions;

namespace SimpleLineLibrary.Src.Utils.Binders
{
    public class BoolBinder : IValueBinder<bool>
    {
        public bool Bind(string value)
        {            
            if(value.ToLower() == "true") {
                return true;
            }
            if (value.ToLower() == "false") {
                return false;
            }
            throw new ConvertException(value, "bool");
        }
    }
}