namespace SimpleLineLibrary.Models.Info
{
    public class HandlerInfo : BaseInfo
    {
        public IEnumerable<ParameterInfo> Parameters { get; }

        internal HandlerInfo(Handler handler)
        {

        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}