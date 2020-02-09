// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IQuery.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Interfaces
{
    using System.Collections.Generic;
    using Furysoft.DynamicQuery.Entities.Nodes;
    using Furysoft.DynamicQuery.Entities.QueryComponents;

    /// <summary>
    /// The Query Interface.
    /// </summary>
    public interface IQuery
    {
        /// <summary>Gets or sets the order by node.</summary>
        List<OrderByNode> OrderByNodes { get; set; }

        /// <summary>Gets or sets the page node.</summary>
        PageNode PageNode { get; set; }

        /// <summary>Gets or sets the where node.</summary>
        WhereNode WhereNode { get; set; }

        /// <summary>
        /// Wheres this instance.
        /// </summary>
        /// <param name="whereClause">The where clause.</param>
        void Where(string whereClause);

        /// <summary>
        /// Wheres the specified node.
        /// </summary>
        /// <param name="node">The node.</param>
        void Where(Node node);
    }
}