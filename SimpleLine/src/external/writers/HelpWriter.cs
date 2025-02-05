namespace simpleline.external.writers;

public class HelpWriter : IWriter {
    public void Write(string text) {
        Console.WriteLine(text);
    }
}