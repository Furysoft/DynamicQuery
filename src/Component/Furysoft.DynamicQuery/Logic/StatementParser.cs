// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StatementParser.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Logic
{
    using Furysoft.DynamicQuery.Entities;
    using Furysoft.DynamicQuery.Interfaces;
    using Furysoft.DynamicQuery.Interfaces.QueryParsers;
    using Furysoft.DynamicQuery.Interfaces.Splitters;
    using JetBrains.Annotations;

    /// <summary>
    /// The Statement Parser.
    /// </summary>
    /// <seealso cref="IStatementParser" />
    public sealed class StatementParser : IStatementParser
    {
        /// <summary>
        /// The order by parser.
        /// </summary>
        [NotNull]
        private readonly IOrderByParser orderByParser;

        /// <summary>
        /// The page parser.
        /// </summary>
        [NotNull]
        private readonly IPageParser pageParser;

        /// <summary>
        /// The select parser.
        /// </summary>
        [NotNull]
        private readonly ISelectParser selectParser;

        /// <summary>
        /// The token splitter.
        /// </summary>
        [NotNull]
        private readonly ISplitter<TokenSplitterResponse> tokenSplitter;

        /// <summary>
        /// The where parser.
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
        /// <param name="selectParser">The select parser.</param>
        public StatementParser(
            [NotNull] ISplitter<TokenSplitterResponse> tokenSplitter,
            [NotNull] IWhereParser whereParser,
            [NotNull] IPageParser pageParser,
            [NotNull] IOrderByParser orderByParser,
            [NotNull] ISelectParser selectParser)
        {
            this.tokenSplitter = tokenSplitter;
            this.whereParser = whereParser;
            this.pageParser = pageParser;
            this.orderByParser = orderByParser;
            this.selectParser = selectParser;
        }

        /// <summary>
        /// Parses the query.
        /// </summary>
        /// <param name="queryString">The query string.</param>
        /// <returns>
        /// The <see cref="IQuery" />.
        /// </returns>
        public IQuery ParseQuery(string queryString)
        {
            var parts = this.tokenSplitter.SplitByToken(queryString);

            var query = new Query(this.whereParser, this.selectParser);
            if (parts.Page != null)
            {
                query.PageNode = this.pageParser.Parse(parts.Page);
            }

            if (parts.OrderBy != null)
            {
                query.OrderByNodes = this.orderByParser.ParseOrderBy(parts.OrderBy);
            }

            if (parts.Where != null)
            {
                query.WhereNode = this.whereParser.ParseWhere(parts.Where);
            }

            if (parts.Select != null)
            {
                query.SelectNode = this.selectParser.Parse(parts.Select);
            }

            return query;
        }
    }
}