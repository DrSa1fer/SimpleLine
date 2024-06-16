namespace SimpleLineLibrary.Setup
{
    /// <summary>
    /// Attribute set keys for parameter
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
