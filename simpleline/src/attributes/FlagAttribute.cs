using simpleline.models.options;

namespace simpleline.attributes;

[AttributeUsage(AttributeTargets.Field)]
public class FlagAttribute(string[] aliases) 
    : Attribute, ICommandOptionAttribute;