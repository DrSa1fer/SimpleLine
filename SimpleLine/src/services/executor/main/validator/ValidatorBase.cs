using simpleline.models.options;

namespace simpleline.services.executor.main.validator;

internal abstract class ValidatorBase {
    public void Validate(IEnumerable<Option> options) {
        try {
            OnValidate(options);
        }
        catch (Exception e) {
            Console.WriteLine(e);
            throw;
        }
    }
    protected abstract void OnValidate(IEnumerable<Option> options);
}