using simpleline.models.options;

namespace simpleline.services.executor.main.complier;

internal abstract class ComplierBase {
    public void Compliant(IEnumerable<Option> options) {
        try {
            OnCompliant(options);
        }
        catch (Exception e) {
            Console.WriteLine(e);
            throw;
        }
    }
    protected abstract void OnCompliant(IEnumerable<Option> options);
}