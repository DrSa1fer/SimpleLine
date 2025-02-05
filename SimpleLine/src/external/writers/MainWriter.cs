namespace simpleline.external.writers;

public class MainWriter  : IWriter {
    public void Write(string text) {
        Console.WriteLine(text);
    }
}