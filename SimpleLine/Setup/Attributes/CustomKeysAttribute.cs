namespace SimpleLineLibrary.Setup.Attributes
{
    /// <summary>
    /// Sets the keys for the handler parameter
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false)]
    public class CustomKeysAttribute : Attribute
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="longKey">full key "--key"</param>
        /// <param name="shortKey">short key "-k"</param>
        public CustomKeysAttribute(string shortKey, string longKey)
        {
            ShortKey = shortKey;
            LongKey = longKey;
        }

        public string ShortKey { get; }
        public string LongKey { get; }
    }
}
