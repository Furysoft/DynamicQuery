// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IOrderByParser.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Interfaces.QueryParsers
{
    using System.Collections.Generic;
    using Entities.QueryComponents;

    /// <summary>
    /// The Order By Parser
    /// </summary>
    public interface IOrderByParser
    {
        /// <summary>
        /// Parses the order by.
        /// </summary>
        /// <param name="orderByData">The order by data.</param>
        /// <returns>The List of order by node</returns>
        List<OrderByNode> ParseOrderBy(string orderByData);
    }
}