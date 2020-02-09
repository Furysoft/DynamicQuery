// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GreaterThanOperator.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Entities.Operations
{
    using Furysoft.DynamicQuery.Entities.Nodes;

    /// <summary>
    /// The Greater Than Operator.
    /// </summary>
    /// <seealso cref="Furysoft.DynamicQuery.Entities.Nodes.UnaryNode" />
    public sealed class GreaterThanOperator : UnaryNode
    {
        /// <summary>
        /// Gets or sets the lower.
        /// </summary>
        public object Value { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [lower inclusive].
        /// </summary>
        public bool Inclusive { get; set; }
    }
}