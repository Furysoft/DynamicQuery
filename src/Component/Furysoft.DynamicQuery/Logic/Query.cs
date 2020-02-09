// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Query.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Logic
{
    using System.Collections.Generic;
    using Furysoft.DynamicQuery.Entities.Nodes;
    using Furysoft.DynamicQuery.Entities.QueryComponents;
    using Furysoft.DynamicQuery.Interfaces;
    using Furysoft.DynamicQuery.Interfaces.QueryParsers;

    /// <summary>
    /// The Query.
    /// </summary>
    /// <seealso cref="IQuery" />
    public sealed class Query : IQuery
    {
        /// <summary>
        /// The where parser.
        /// </summary>
        private readonly IWhereParser whereParser;

        /// <summary>
        /// Initializes a new instance of the <see cref="Query"/> class.
        /// </summary>
        /// <param name="whereParser">The where parser.</param>
        public Query(IWhereParser whereParser)
        {
            this.whereParser = whereParser;
        }

        /// <summary>Gets or sets the order by node.</summary>
        public List<OrderByNode> OrderByNodes { get; set; }

        /// <summary>Gets or sets the page node.</summary>
        public PageNode PageNode { get; set; }

        /// <summary>Gets or sets the where node.</summary>
        public WhereNode WhereNode { get; set; }

        /// <inheritdoc />
        public void Where(string whereClause)
        {
            var node = this.whereParser.ParseWhere(whereClause);

            if (node == null)
            {
                return;
            }
        }

        /// <inheritdoc />
        public void Where(Node node)
        {
        }
    }
}