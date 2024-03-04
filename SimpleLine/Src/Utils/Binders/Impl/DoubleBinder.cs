using SimpleLineLibrary.Src.Exceptions.BinderExceptions;

namespace SimpleLineLibrary.Src.Utils.Binders
{
    public class DoubleBinder : IValueBinder<double>
    {
        public double Bind(string value)
        {
            if(double.TryParse(value, out double res))
            {
                return res;
            }
            throw new ConvertException(value, "double");
        }
    }
}
