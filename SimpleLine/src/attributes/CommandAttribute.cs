using simpleline.services.registrar;

namespace simpleline.attributes;

[AttributeUsage(AttributeTargets.Class)]
public class CommandAttribute : Attribute, IRegistered;