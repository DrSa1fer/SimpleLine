using System.Diagnostics.CodeAnalysis;

namespace simpleline.services.router;

internal class Route(Input input) {
    public string Peek() {
        var t = input[0];
        if (t.IsKey()) {
            throw new Exception();
        }

        return t.Value;
    }

    public string Take() {
        var t = input[0];
        if (t.IsKey()) {
            throw new Exception();
        }

        input.RemoveAt(0);
        return t.Value;
    }

    public bool TryPeek([MaybeNullWhen(false)] out string value) {
        value = null;

        if (input.Count < 1) {
            return false;
        }

        if (input[0].IsKey()) {
            return false;
        }

        value = input[0].Value;
        return true;
    }

    public bool TryTake([MaybeNullWhen(false)] out string value) {
        value = null;

        if (input.Count < 1) {
            return false;
        }

        if (input[0].IsKey()) {
            return false;
        }

        value = input[0].Value;
        input.RemoveAt(0);
        return true;
    }
}