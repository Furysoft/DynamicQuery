// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EntityProperty.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Entities.Parsers
{
    /// <summary>
    /// The Entity Property.
    /// </summary>
    public sealed class EntityProperty
    {
        /// <summary>Gets or sets the name of the internal.</summary>
        public string InternalName { get; set; }

        /// <summary>Gets or sets a value indicating whether this instance is permitted.</summary>
        public bool IsPermitted { get; set; }

        /// <summary>Gets or sets the name of the query.</summary>
        public string QueryName { get; set; }
    }
}