using SimpleLineLibrary.Extentions.Exceptions;

namespace SimpleLineLibrary.Extentions
{
    internal static class StringExtentions
    {
        private const int MAX_TOKEN_LENGTH = 32;
        private const int MAX_TEXT_LENGTH = 80;

        public static bool IsTokenName(this string tokenName)
        {
            return tokenName is not null
                && tokenName.Length > 0
                && tokenName.Length <= MAX_TOKEN_LENGTH
                && char.IsLetter(tokenName[0])
                && tokenName.All(x => char.IsLetterOrDigit(x) || x.Equals('-'));
        }
        public static bool IsKeyTokenName(this string key)
        {
            return key.IsLongKeyTokenName() || key.IsShortKeyTokenName();
        }
        public static bool IsLongKeyTokenName(this string key)
        {

            return key.Length > 2
                && key.TokenStartWith("--")
                && key[2..].IsTokenName();
        }
        public static bool IsShortKeyTokenName(this string key)
        {
            return key.Length > 1
                && key.TokenStartWith("-")
                && key[1..].IsTokenName();
        }
        public static bool IsValidText(this string text)
        {
            if (text == null)
            {
                return true;
            }

            return text.Length <= MAX_TEXT_LENGTH;
        }


        public static bool IsEqualsToken(this string token, string otherToken)
        {
            return token.Equals(otherToken, StringComparison.OrdinalIgnoreCase);
        }
        public static bool TokenStartWith(this string token, string start)
        {
            return token.StartsWith(start, StringComparison.OrdinalIgnoreCase);
        }
        public static string[] SplitOnTokens(this string text, params char[] separators)
        {
            return text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        }


        public static void ThrowIfWrongTokenName(this string tokenName)
        {
            if (!tokenName.IsTokenName())
            {
                throw new InvalidTokenException(tokenName);
            }
        }
        public static void ThrowIfWrongText(this string text)
        {
            if (!text.IsValidText())
            {
                throw new InvalidTextException(text.Length, 80);
            }
        }
        public static void ThrowIfWrongKeyTokenName(this string key)
        {
            if (!key.IsKeyTokenName())
            {
                throw new InvalidKeyException(key);
            }
        }
        public static void ThrowIfWrongLongKeyTokenName(this string key)
        {
            if (!key.IsLongKeyTokenName())
            {
                throw new InvalidKeyException(key);
            }
        }
        public static void ThrowIfWrongShortKeyTokenName(this string key)
        {
            if (!key.IsShortKeyTokenName())
            {
                throw new InvalidKeyException(key);
            }
        }
    }
}