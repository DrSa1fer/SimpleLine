namespace simpleline.external;

public class Console(
    TextReader input,
    TextWriter output,
    TextWriter error) {
    public Console() : this(
        System.Console.In,
        System.Console.Out,
        System.Console.Error
    ) { }

    public TextReader In { get; } = input; //may be  
    public TextWriter Out { get; } = output;
    public TextWriter Err { get; } = error;
}