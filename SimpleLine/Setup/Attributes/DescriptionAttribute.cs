﻿namespace SimpleLineLibrary.Setup.Attributes
{
    /// <summary>
    /// Adds a description for further use by the library
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Parameter, AllowMultiple = false, Inherited = true)]
    public class DescriptionAttribute : Attribute
    {
        public string Description { get; }

        public DescriptionAttribute(string description) => Description = description;
    }
}