// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Query.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Logic
{
    using System.Collections.Generic;
    using Entities.Nodes;
    using Entities.QueryComponents;
    using Interfaces;

    /// <summary>
    /// The Query
    /// </summary>
    /// <seealso cref="IQuery" />
    public sealed class Query : IQuery
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Query" /> class.
        /// </summary>
        /// <param name="orderByNodes">The order by nodes.</param>
        /// <param name="node">The node.</param>
        /// <param name="pageNode">The page node.</param>
        public Query(List<OrderByNode> orderByNodes, Node node, PageNode pageNode)
        {
            this.OrderByNodes = orderByNodes;
            this.PageNode = pageNode;
            this.WhereNode = node;
        }

        /// <summary>Gets the order by node.</summary>
        public List<OrderByNode> OrderByNodes { get; }

        /// <summary>Gets the page node.</summary>
        public PageNode PageNode { get; }

        /// <summary>Gets the where node.</summary>
        public Node WhereNode { get; }
    }
}