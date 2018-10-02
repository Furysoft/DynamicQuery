// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OrderByParser.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Logic.QueryParsers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Entities;
    using Entities.QueryComponents;
    using Interfaces.QueryParsers;

    /// <summary>
    /// The Order By Parser
    /// </summary>
    public sealed class OrderByParser : IOrderByParser
    {
        /// <summary>
        /// The regex query
        /// </summary>
        private static readonly Regex RegexQuery = new Regex("(asc|desc)", RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase);

        /// <summary>
        /// Parses the order by.
        /// </summary>
        /// <param name="orderByData">The order by data.</param>
        /// <returns>The List of order by node</returns>
        public List<OrderByNode> ParseOrderBy(string orderByData)
        {
            var rtn = new List<OrderByNode>();

            var strings = RegexQuery.Split(orderByData).Where(r => !string.IsNullOrWhiteSpace(r)).ToList();

            for (var i = 0; i < strings.Count; i = i + 2)
            {
                var orderByNode = GetOrderByNode(strings[i], strings[i + 1]);
                rtn.Add(orderByNode);
            }

            return rtn;
        }

        /// <summary>
        /// Gets the order by node.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="order">The order.</param>
        /// <returns>The <see cref="OrderByNode"/></returns>
        private static OrderByNode GetOrderByNode(string name, string order)
        {
            SortOrder sortOrder;
            switch (order)
            {
                case "desc":
                    sortOrder = SortOrder.Desc;
                    break;
                case "asc":
                default:
                    sortOrder = SortOrder.Asc;
                    break;
            }

            return new OrderByNode
            {
                SortOrder = sortOrder,
                Name = name.Trim().Trim('"')
            };
        }
    }
}