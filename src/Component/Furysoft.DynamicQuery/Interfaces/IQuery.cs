// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IQuery.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Interfaces
{
    using System.Collections.Generic;
    using Entities.Nodes;
    using Entities.QueryComponents;

    /// <summary>
    /// The Query Interface
    /// </summary>
    public interface IQuery
    {
        /// <summary>Gets the order by node.</summary>
        List<OrderByNode> OrderByNodes { get; }

        /// <summary>Gets the page node.</summary>
        PageNode PageNode { get; }

        /// <summary>Gets the where node.</summary>
        Node WhereNode { get; }
    }
}