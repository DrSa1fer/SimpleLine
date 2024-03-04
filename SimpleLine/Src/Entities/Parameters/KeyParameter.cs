using SimpleLineLibrary.Src.Entities.Parameters.Abs;
using SimpleLineLibrary.Src.Exceptions.ParameterExceptions;
using SimpleLineLibrary.Src.Execution;

namespace SimpleLineLibrary.Src.Entities.Parameters
{
    public sealed class KeyParameter : Parameter<bool>
    {
        public KeyParameter(string[] aliasses, string helpInfo) 
            : base(false, helpInfo)
        {
            _aliasses = aliasses;
        }

        private readonly string[] _aliasses;

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
        protected override int GetIndex(InputData data)
        {
            var set = new HashSet<string>();
            foreach (var i in _aliasses)
            {
                set.Add($"/{i}");
            }
            return data.Items.FindIndex(set.Contains);
        }
    }
}