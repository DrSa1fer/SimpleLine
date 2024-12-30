using simpleline.models.actions;
using simpleline.workers.registrar;

namespace simpleline.attributes;

[AttributeUsage(AttributeTargets.Method)]
public class ActionAttribute : Attribute, IActionAttribute, IRegistered;