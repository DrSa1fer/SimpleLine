using simpleline.models.commands;
using simpleline.workers.registrar;

namespace simpleline.attributes;

[AttributeUsage(AttributeTargets.Class)]
public class CommandAttribute : Attribute, ICommandAttribute, IRegistered;