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
    using Interfaces.QueryParsers;

    /// <summary>
    /// The Query
    /// </summary>
    /// <seealso cref="IQuery" />
    public sealed class Query : IQuery
    {
        /// <summary>
        /// The where parser
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
        public Node WhereNode { get; set; }

        /// <inheritdoc />
        public void Where(string whereClause)
        {
            var node = this.whereParser.ParseWhere(whereClause);

            if (node == null)
            {
                return;
            }

            this.WhereNode = new BinaryNode
            {
                LeftNode = node,
                RightNode = this.WhereNode,
                Name = null,
                Conjunctive = Conjunctives.And,
                Statement = $"{node.Statement} and {this.WhereNode.Statement}"
            };
        }

        /// <inheritdoc />
        public void Where(Node node)
        {
            this.WhereNode = new BinaryNode
            {
                LeftNode = node,
                RightNode = this.WhereNode,
                Name = null,
                Conjunctive = Conjunctives.And,
                Statement = $"{node.Statement} and {this.WhereNode.Statement}"
            };
        }
    }
}