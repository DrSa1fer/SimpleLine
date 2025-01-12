namespace simpleline.services;

/// <summary>
/// Implementation of Queue. Present user input  
/// </summary>
/// <param name="input"></param>
internal class Input(IEnumerable<Symbol> input) : Queue<Symbol>(input);