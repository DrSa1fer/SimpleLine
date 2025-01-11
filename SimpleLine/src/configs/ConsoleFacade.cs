namespace simpleline.configs;

public class ConsoleFacade(
    TextReader input,
    TextWriter output,
    TextWriter error) {
    public ConsoleFacade() : this(
        Console.In,
        Console.Out,
        Console.Error
    ) { }

    public TextReader In { get; } = input; //may be  
    public TextWriter Out { get; } = output;
    public TextWriter Err { get; } = error;
}