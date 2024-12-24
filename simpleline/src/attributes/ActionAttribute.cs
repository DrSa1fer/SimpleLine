using simpleline.models.attributes;
using simpleline.services.registrar;

namespace simpleline.attributes;

[AttributeUsage(AttributeTargets.Method)]
public class ActionAttribute : Attribute, IActionAttribute, IRegisteredAttribute;