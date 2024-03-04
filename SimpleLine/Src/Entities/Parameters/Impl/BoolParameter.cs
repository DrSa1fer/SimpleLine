using SimpleLineLibrary.Src.Utils.Binders;

namespace SimpleLineLibrary.Src.Entities.Parameters.Impl
{
    public class BoolParameter : ValueParameter<bool>
    {
        public BoolParameter(string[] aliasses, bool defaultValue, string helpInfo)
            : base(aliasses, new BoolBinder(), defaultValue, helpInfo)
        {
        }

        public BoolParameter(string[] aliasses, string helpInfo)
            : base(aliasses, new BoolBinder(), helpInfo)
        {
        }
    }
}