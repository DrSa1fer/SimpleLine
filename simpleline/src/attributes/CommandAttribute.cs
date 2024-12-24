using simpleline.models.attributes;
using simpleline.services.registrar;

namespace simpleline.attributes;

[AttributeUsage(AttributeTargets.Class)]
public class CommandAttribute : Attribute, ICommandAttribute, IRegisteredAttribute;