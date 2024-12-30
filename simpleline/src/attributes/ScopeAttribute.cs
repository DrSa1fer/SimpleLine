using simpleline.workers.registrar;

namespace simpleline.attributes;

[AttributeUsage(AttributeTargets.Assembly)]
public class ScopeAttribute : Attribute, IRegistered;