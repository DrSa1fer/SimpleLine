using System.Diagnostics.CodeAnalysis;

namespace simpleline.services.router;

internal class Route(Input input) {
    public string Peek() {
        var t = input.Peek();
        if (t.IsKey()) {
            throw new Exception();
        }

        return t.Value;
    }

    public string Take() {
        var t = input.Peek();
        if (t.IsKey()) {
            throw new Exception();
        }

        input.Dequeue();
        return t.Value;
    }

    public bool TryPeek([MaybeNullWhen(false)] out string value) {
        value = null;

        if (!input.TryPeek(out var t)) {
            return false;
        }
        
        if (t.IsKey()) {
            return false;
        }

        value = t.Value;
        return true;
    }

    public bool TryTake([MaybeNullWhen(false)] out string value) {
        value = null;
        
        if (!input.TryPeek(out var t)) {
            return false;
        }
        
        if (t.IsKey()) {
            return false;
        }

        value = t.Value;
        input.Dequeue();
        return true;
    }
}