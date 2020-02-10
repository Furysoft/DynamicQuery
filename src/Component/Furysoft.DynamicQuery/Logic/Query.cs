// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Query.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Logic
{
    using System.Collections.Generic;
    using Furysoft.DynamicQuery.Entities.QueryComponents;
    using Furysoft.DynamicQuery.Interfaces;
    using Furysoft.DynamicQuery.Interfaces.QueryParsers;
    using JetBrains.Annotations;

    /// <summary>
    /// The Query.
    /// </summary>
    /// <seealso cref="IQuery" />
    public sealed class Query : IQuery
    {
        /// <summary>
        /// The select parser.
        /// </summary>
        [NotNull]
        private readonly ISelectParser selectParser;

        /// <summary>
        /// The where parser.
        /// </summary>
        [NotNull]
        private readonly IWhereParser whereParser;

        /// <summary>
        /// Initializes a new instance of the <see cref="Query" /> class.
        /// </summary>
        /// <param name="whereParser">The where parser.</param>
        /// <param name="selectParser">The select parser.</param>
        public Query([NotNull] IWhereParser whereParser, [NotNull] ISelectParser selectParser)
        {
            this.whereParser = whereParser;
            this.selectParser = selectParser;
        }

        /// <summary>Gets or sets the order by node.</summary>
        public List<OrderByNode> OrderByNodes { get; set; }

        /// <summary>Gets or sets the page node.</summary>
        public PageNode PageNode { get; set; }

        /// <summary>Gets or sets the where node.</summary>
        public SelectNode SelectNode { get; set; }

        /// <summary>Gets or sets the where node.</summary>
        public WhereNode WhereNode { get; set; }

        /// <inheritdoc />
        public IQuery Page(int page, int itemsPerPage, bool replaceUserValue = false)
        {
            if (!replaceUserValue && this.PageNode != null)
            {
                return this;
            }

            this.PageNode = new PageNode { ItemsPerPage = itemsPerPage, Name = null, Statement = $"{page},{itemsPerPage}", Page = page };

            return this;
        }

        /// <inheritdoc />
        public IQuery Select(string columns, bool replaceUserValue = false, char separator = ',')
        {
            if (!replaceUserValue && this.SelectNode != null)
            {
                return this;
            }

            var selectNode = this.selectParser.Parse("*", separator);
            this.SelectNode = selectNode;

            return this;
        }

        /// <inheritdoc />
        public IQuery Select(bool replaceUserValue = false, params string[] columns)
        {
            if (!replaceUserValue && this.SelectNode != null)
            {
                return this;
            }

            var selectNode = this.selectParser.Parse(string.Join(",", columns));
            this.SelectNode = selectNode;

            return this;
        }

        /// <inheritdoc />
        public IQuery SelectAll(bool replaceUserValue = false)
        {
            if (!replaceUserValue && this.SelectNode != null)
            {
                return this;
            }

            var selectNode = this.selectParser.Parse("*");
            this.SelectNode = selectNode;

            return this;
        }

        /// <inheritdoc />
        public IQuery Where(string whereClause)
        {
            var node = this.whereParser.ParseWhere(whereClause);

            return this.Where(node);
        }

        /// <inheritdoc />
        public IQuery Where(WhereNode node)
        {
            if (node == null)
            {
                return this;
            }

            node.Next = this.WhereNode;
            this.WhereNode = node;

            return this;
        }
    }
}