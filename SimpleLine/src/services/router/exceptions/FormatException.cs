namespace simpleline.services.router.exceptions;

internal class FormatException(string route, string item) : Exception(
    "Invalid format of route item. Pattern \"^[a-zA-Z][0-9a-zA-Z]*$\""
    + $"{Environment.NewLine}\tRoute:\t{route};\tInvalid:\t{item};");