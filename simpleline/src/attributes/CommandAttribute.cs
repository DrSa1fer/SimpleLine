using simpleline.models.attributes;
using simpleline.registrars;

namespace simpleline.attributes;

[AttributeUsage(AttributeTargets.Class)]
public class CommandAttribute : Attribute, ICommandAttribute, IRegistered;