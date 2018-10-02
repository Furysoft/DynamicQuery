// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NameAttribute.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Attributes
{
    using System;

    /// <summary>
    /// The Name Attribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class NameAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NameAttribute" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public NameAttribute(string name)
        {
            this.Name = name;
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name { get; }
    }
}