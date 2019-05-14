// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EqualsOperator.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Entities.Operations
{
    using Nodes;

    /// <summary>
    /// The Equals Node
    /// </summary>
    public sealed class EqualsOperator : UnaryNode
    {
        /// <summary>
        /// Gets or sets a value indicating whether [case insensitive].
        /// </summary>
        public bool CaseInsensitive { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is not.
        /// </summary>
        public bool IsNot { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        public object Value { get; set; }
    }
}