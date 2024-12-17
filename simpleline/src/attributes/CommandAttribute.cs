using simpleline.services.registration;

namespace simpleline.attributes;

[AttributeUsage(AttributeTargets.Class)]
public class CommandAttribute : Attribute, IRegistered;