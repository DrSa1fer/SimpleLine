namespace simpleline.services;

/// <summary>
/// Passed in input argument that present as Key or Value
/// </summary>
internal sealed record Symbol(bool IsKey, string Value);