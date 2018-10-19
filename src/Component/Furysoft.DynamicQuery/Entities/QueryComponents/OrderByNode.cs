// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OrderByNode.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Entities.QueryComponents
{
    using Nodes;

    /// <summary>
    /// The Order By Node
    /// </summary>
    public sealed class OrderByNode : UnaryNode
    {
        /// <summary>
        /// Gets or sets the sort order.
        /// </summary>
        public SortOrder SortOrder { get; set; }
    }
}