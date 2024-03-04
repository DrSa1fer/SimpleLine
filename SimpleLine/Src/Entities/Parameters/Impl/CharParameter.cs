using SimpleLineLibrary.Src.Utils.Binders;

namespace SimpleLineLibrary.Src.Entities.Parameters.Impl
{
    public class CharParameter : ValueParameter<char>
    {
        public CharParameter(string[] aliasses, char? defaultValue) 
            : base(aliasses, new CharBinder(), defaultValue.ToString(), defaultValue == null)
        {
        }
    }
}
