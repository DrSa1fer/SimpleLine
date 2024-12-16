namespace simpleline.validators;

public static class SymbolValidatorHelper
{
    public static bool IsSymbol(this string symbol)
    {
        return string.IsNullOrEmpty(symbol)
               || char.IsLetter(symbol[0])
               || symbol
                   .All(sym => false
                               || char.IsLetter (sym)
                               || char.IsDigit  (sym)
                               || '-' .Equals   (sym)
                   );
    }
}