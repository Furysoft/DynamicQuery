// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RangeOperator.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Entities.Operations
{
    using Nodes;

    /// <summary>
    /// The Range Node
    /// </summary>
    /// <seealso cref="UnaryNode" />
    public sealed class RangeOperator : UnaryNode
    {
        /// <summary>
        /// Gets or sets the lower.
        /// </summary>
        public object Lower { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [lower inclusive].
        /// </summary>
        public bool LowerInclusive { get; set; }

        /// <summary>
        /// Gets or sets the upper.
        /// </summary>
        public object Upper { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [upper inclusive].
        /// </summary>
        public bool UpperInclusive { get; set; }
    }
}