// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParserCache.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Logic.Caching
{
    using System;
    using System.Collections.Concurrent;
    using Interfaces;
    using Interfaces.Caching;
    using Parsers;
    using QueryParsers;
    using QueryParsers.WhereParsers;
    using Splitters;

    /// <inheritdoc />
    internal sealed class ParserCache : IParserCache
    {
        /// <summary>
        /// The parser cache
        /// </summary>
        private static readonly ConcurrentDictionary<Type, object> Cache = new ConcurrentDictionary<Type, object>();

        /// <inheritdoc />
        public IStatementParser GetParser<TEntity>()
        {
            return (IStatementParser)Cache.GetOrAdd(
                typeof(TEntity),
                type => Initialize<TEntity>());
        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <returns>The IEntityParser</returns>
        private static object Initialize<TEntity>()
        {
            var tokenSplitter = new TokenSplitter();

            var rangeParser = new RangeParser();
            var equalsParser = new EqualsParser();

            var entityParser = new EntityParser<TEntity>();

            var whereStatementParser = new WhereStatementParser<TEntity>(rangeParser, equalsParser, entityParser);
            var whereParser = new WhereParser(whereStatementParser);
            var orderByParser = new OrderByParser();
            var pageParser = new PageParser();

            return new StatementParser(tokenSplitter, whereParser, pageParser, orderByParser);
        }
    }
}