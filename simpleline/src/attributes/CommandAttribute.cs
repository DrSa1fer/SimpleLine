using simpleline.registrars;

namespace simpleline.attributes;

[AttributeUsage(AttributeTargets.Class)]
public class CommandAttribute : Attribute, IRegistered;