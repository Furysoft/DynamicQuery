// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TypeSplitterResponse.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Entities
{
    /// <summary>
    /// The Token Splitter Response
    /// </summary>
    public sealed class TypeSplitterResponse
    {
        /// <summary>Gets or sets the data.</summary>
        public string Data { get; set; }

        /// <summary>Gets or sets a value indicating whether this instance has type.</summary>
        public bool HasType { get; set; }

        /// <summary>Gets or sets the type.</summary>
        public string Type { get; set; }
    }
}