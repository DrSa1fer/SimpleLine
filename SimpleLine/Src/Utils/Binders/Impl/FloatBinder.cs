using SimpleLineLibrary.Src.Exceptions.BinderExceptions;

namespace SimpleLineLibrary.Src.Utils.Binders
{
    public class FloatBinder : IValueBinder<float>
    {
        public float Bind(string value)
        {
            if (float.TryParse(value, out float res))
            {
                return res;
            }
            throw new ConvertException(value, "float");
        }
    }
}
