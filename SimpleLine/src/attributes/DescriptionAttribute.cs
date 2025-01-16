using simpleline.models.actions;
using simpleline.models.commands;
using simpleline.models.options;
using simpleline.services.executor.help.helper;

namespace simpleline.attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field)]
public class DescriptionAttribute(string description) : Attribute, 
    ICommandAttribute,
    IActionAttribute,
    IOptionAttribute,
    IDescriptionAttribute
{
    public string Description { get; } = description;
}