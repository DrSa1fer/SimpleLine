namespace simpleline.services.executor.main.binder.handlers.parameters;

internal class ParameterHandler {
    public IEnumerable<string> Handle(IParameterAttribute attribute, DataInput dataInput) {
        foreach (var alias in attribute.Aliases) {
            if (!dataInput.TryTakeValues(alias, attribute.Arity, out var values)) {
                continue;
            }

            return values;
        }

        throw new Exception("Key not found");
    }
}