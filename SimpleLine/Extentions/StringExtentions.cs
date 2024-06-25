using SimpleLineLibrary.Extentions.Exceptions;

namespace SimpleLineLibrary.Extentions
{
    internal static class StringExtentions
    {
        public static bool IsTokenName(this string tokenName)
        {
            return tokenName is not null
                && tokenName.Length > 0
                && tokenName.Length < 33
                && char.IsLetter(tokenName[0])
                && tokenName.All(x => char.IsLetterOrDigit(x) || x.Equals('-'));
        }
        public static bool IsKeyTokenName(this string key)
        {
            return key.IsLongKeyTokenName() || key.IsShortKeyTokenName();
        }

        public static bool IsLongKeyTokenName(this string key) => key.Length > 2
                && key.TokenStartWith("--")
                && !key[2].Equals('-')
                && key.All(x => !char.IsWhiteSpace(x));

        public static bool IsShortKeyTokenName(this string key)
        {
            return key.Length > 1
                && key.TokenStartWith("-")
                && !key[1].Equals('-')
                && key.All(x => !char.IsWhiteSpace(x));
        }

        public static bool IsValidText(this string text)
        {
            if (text == null)
            {
                return true;
            }

            return text.Length < 81;
        }

        public static bool IsEqualsToken(this string token, string otherToken)
        {
            return token.Equals(otherToken, StringComparison.OrdinalIgnoreCase);
        }
        public static bool TokenStartWith(this string token, string start)
        {
            return token.StartsWith(start, StringComparison.OrdinalIgnoreCase);
        }
        public static string[] SplitAndRemoveEmptyEntries(this string text, params char[] separators)
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