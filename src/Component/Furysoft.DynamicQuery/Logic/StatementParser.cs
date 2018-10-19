// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StatementParser.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Logic
{
    using Interfaces;
    using Interfaces.QueryParsers;
    using Interfaces.Splitters;
    using JetBrains.Annotations;

    /// <summary>
    /// The Statement Parser
    /// </summary>
    /// <seealso cref="IStatementParser" />
    public sealed class StatementParser : IStatementParser
    {
        /// <summary>
        /// The order by parser
        /// </summary>
        [NotNull]
        private readonly IOrderByParser orderByParser;

        /// <summary>
        /// The page parser
        /// </summary>
        [NotNull]
        private readonly IPageParser pageParser;

        /// <summary>
        /// The token splitter
        /// </summary>
        [NotNull]
        private readonly ITokenSplitter tokenSplitter;

        /// <summary>
        /// The where parser
        /// </summary>
        [NotNull]
        private readonly IWhereParser whereParser;

        /// <summary>
        /// Initializes a new instance of the <see cref="StatementParser" /> class.
        /// </summary>
        /// <param name="tokenSplitter">The token splitter.</param>
        /// <param name="whereParser">The where parser.</param>
        /// <param name="pageParser">The page parser.</param>
        /// <param name="orderByParser">The order by parser.</param>
        public StatementParser(
            [NotNull] ITokenSplitter tokenSplitter,
            [NotNull] IWhereParser whereParser,
            [NotNull] IPageParser pageParser,
            [NotNull] IOrderByParser orderByParser)
        {
            this.tokenSplitter = tokenSplitter;
            this.whereParser = whereParser;
            this.pageParser = pageParser;
            this.orderByParser = orderByParser;
        }

        /// <summary>
        /// Parses the query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>The <see cref="IQuery"/></returns>
        public IQuery ParseQuery(string query)
        {
            var parts = this.tokenSplitter.SplitByToken(query);

            var pageNode = this.pageParser.Parse(parts.Page);
            var orderByNodes = this.orderByParser.ParseOrderBy(parts.OrderBy);
            var whereNode = this.whereParser.ParseWhere(parts.Where);

            return new Query(orderByNodes, whereNode, pageNode);
        }
    }
}