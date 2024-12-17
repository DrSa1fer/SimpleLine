using simpleline.models.commands;

namespace simpleline.attributes;

[AttributeUsage(AttributeTargets.Method)]
public class ActionAttribute : Attribute, IActionAttribute;