using SimpleLineLibrary.Src.Utils.Binders;

namespace SimpleLineLibrary.Src.Entities.Parameters.Impl
{
    public class BoolParameter : ValueParameter<bool>
    {
        public BoolParameter(string[] aliasses, bool? defaultValue = null)
            : base(aliasses, new BoolBinder(), defaultValue?.ToString(), defaultValue == null)
        {
        }
    }
}