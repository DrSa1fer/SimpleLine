using SimpleLineLibrary.Src.Utils.Binders;

namespace SimpleLineLibrary.Src.Entities.Parameters.Impl
{
    public class CharParameter : ValueParameter<char>
    {
        public CharParameter(string[] aliasses, char defaultValue, string helpInfo) 
            : base(aliasses, new CharBinder(), defaultValue, helpInfo)
        {
        }
        public CharParameter(string[] aliasses, string helpInfo)
            : base(aliasses, new CharBinder(), helpInfo)
        {
        }
    }
}
