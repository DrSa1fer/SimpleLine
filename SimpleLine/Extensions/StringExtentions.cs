namespace SimpleLineLibrary.Extensions
{
    internal static class StringExtentions
    {
        public static bool IsTokenName(this string tokenName)
        {
            return tokenName is not null
                && tokenName.Length > 0
                && char.IsLetter(tokenName[0])
                && tokenName.All(x => char.IsLetterOrDigit(x) || x.Equals('-'));
        }
        public static bool IsKeyTokenName(this string key)
        {
            return key.IsLongKeyTokenName() || key.IsShortKeyTokenName();
        }
        public static bool IsLongKeyTokenName(this string key) => key.Length > 2
                && key.TokenStartWith("--")
                && !key[2].Equals('-');
        public static bool IsShortKeyTokenName(this string key)
        {
            return key.Length > 1
                && key.TokenStartWith("-")
                && !key[1].Equals('-');
        }

        public static bool IsValidTextLength(this string text)
        {
            if(text == null)
            {
                return true;
            }

            return text.Length < 81;
        }
                
        public static bool IsEqualsTokenName(this string token, string otherToken)
        {
            return token.Equals(otherToken, StringComparison.OrdinalIgnoreCase);
        }
        public static bool TokenStartWith(this string token, string start)
        {
            return token.StartsWith(start, StringComparison.OrdinalIgnoreCase);
        }

        public static void ThrowIfWrongTokenName(this string tokenName)
        {
            if (!tokenName.IsTokenName())
            {
                throw new Exceptions.InvalidTokenNameException(tokenName);
            }
        }
        public static void ThrowIfWrongTextLength(this string text)
        {
            if (!text.IsValidTextLength())
            {
                throw new Exception("length more than 80");
            }
        }
        public static void ThrowIfWrongKeyTokenName(this string key)
        {
            if (!key.IsKeyTokenName())
            {
                throw new 
                    SimpleLineLibrary
                    .Exceptions
                    .ArgumentException("Invalid key");
            }
        }
    }
}