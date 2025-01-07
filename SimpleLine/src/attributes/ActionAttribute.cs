using simpleline.services.registrar;

namespace simpleline.attributes;

[AttributeUsage(AttributeTargets.Method)]
public class ActionAttribute : Attribute, IRegistered;