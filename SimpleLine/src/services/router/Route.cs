using System.Collections;

namespace simpleline.services.router;

internal class Route(Symbol[] symbols) : IReadOnlyCollection<string> {
    public int Count => 0;

    public IEnumerator<string> GetEnumerator() {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator() {
        return GetEnumerator();
    }
}