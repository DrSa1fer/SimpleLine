using simpleline.models.attributes;

namespace simpleline.attributes;

[AttributeUsage(AttributeTargets.Method)]
public class ActionAttribute : Attribute, IActionAttribute;