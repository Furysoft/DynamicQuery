// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WhereParser.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Logic.QueryParsers
{
    using System;
    using Entities.QueryComponents;
    using Interfaces.QueryParsers;
    using Interfaces.Splitters;
    using JetBrains.Annotations;

    /// <summary>
    /// The Where Parser
    /// </summary>
    internal sealed class WhereParser : IWhereParser
    {
        [NotNull]
        private readonly IWhereSplitter whereSplitter;

        [NotNull]
        private readonly IWhereStatementParser whereStatementParser;

        /// <summary>
        /// Initializes a new instance of the <see cref="WhereParser"/> class.
        /// </summary>
        /// <param name="whereSplitter">The where splitter.</param>
        /// <param name="whereStatementParser">The where statement parser.</param>
        public WhereParser(
            [NotNull] IWhereSplitter whereSplitter,
            [NotNull] IWhereStatementParser whereStatementParser)
        {
            this.whereSplitter = whereSplitter;
            this.whereStatementParser = whereStatementParser;
        }

        /// <summary>
        /// Parses the where.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <returns>The <see cref="WhereNode"/></returns>1
        public WhereNode ParseWhere(string where)
        {
            throw new NotImplementedException();
        }
    }
}