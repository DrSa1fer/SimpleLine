namespace simpleline.services.executor.main.binder.handlers.arguments;

internal class ArgumentHandler {
    public IEnumerable<string> Handle(IArgumentAttribute attribute, DataInput dataInput) {
        if (!dataInput.TryTakeValues(attribute.Position, attribute.Arity, out var values)) {
            throw new Exception("Invalid position");
        }

        return values;
    }
}