using simpleline.services.executor.help.helper;
using simpleline.services.executor.help.helper.handlers;

namespace simpleline.attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field)]
public class DescriptionAttribute(
    string description
) : Attribute, IDescriptionAttribute
{
    public string Description { get; } = description;
}