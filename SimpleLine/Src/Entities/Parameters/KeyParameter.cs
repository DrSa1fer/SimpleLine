using SimpleLineLibrary.Src.Entities.Parameters.Abs;
using SimpleLineLibrary.Src.Exceptions;
using SimpleLineLibrary.Src.Exceptions.ParameterExceptions;
using SimpleLineLibrary.Src.Execution;

namespace SimpleLineLibrary.Src.Entities.Parameters
{
    public sealed class KeyParameter : Parameter<bool>
    {
        public KeyParameter(params string[] aliasses) : base(aliasses, false)
        {
        }

        protected override bool OnWithoutValue()
        {
            return true;
        }
        protected override bool OnNotFound()
        {
            return false;
        }
        protected override bool OnWithValue(string value)
        {
            throw new KeyWithValueException();
        }
    }
}