namespace SimpleLineLibrary.Setup
{
    /// <summary>
    /// Sets the keys for the handler parameter
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false)]
    public class CustomKeysAttribute : Attribute
    {
        internal string LongKey { get; }
        internal string ShortKey { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="longKey">full key "--key"</param>
        /// <param name="shortKey">short key "-k"</param>
        public CustomKeysAttribute(string shortKey, string longKey)
        {
            LongKey = longKey;
            ShortKey = shortKey;
        }
    }
}