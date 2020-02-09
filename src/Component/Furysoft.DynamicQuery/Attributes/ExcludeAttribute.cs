// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExcludeAttribute.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Attributes
{
    using System;

    /// <summary>
    /// The Exclude Attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class ExcludeAttribute : Attribute
    {
    }
}