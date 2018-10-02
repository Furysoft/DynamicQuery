// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LessThanNode.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Entities.QueryComponents.WhereNodes
{
    /// <summary>
    /// The Less Than Node
    /// </summary>
    public sealed class LessThanNode
    {
        /// <summary>
        /// Gets or sets the lower.
        /// </summary>
        public object Value { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [lower inclusive].
        /// </summary>
        public bool Inclusive { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }
    }
}