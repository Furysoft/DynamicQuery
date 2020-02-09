// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LessThanOperator.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Entities.Operations
{
    using Furysoft.DynamicQuery.Entities.Nodes;

    /// <summary>
    /// The Less Than Operator.
    /// </summary>
    /// <seealso cref="UnaryNode" />
    public sealed class LessThanOperator : UnaryNode
    {
        /// <summary>
        /// Gets or sets a value indicating whether [lower inclusive].
        /// </summary>
        public bool Inclusive { get; set; }

        /// <summary>
        /// Gets or sets the lower.
        /// </summary>
        public object Value { get; set; }
    }
}