// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParserCache.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Logic.Caching
{
    using System;
    using System.Collections.Concurrent;
    using Furysoft.DynamicQuery.Entities;
    using Furysoft.DynamicQuery.Interfaces;
    using Furysoft.DynamicQuery.Interfaces.Caching;
    using Furysoft.DynamicQuery.Logic.QueryParsers;
    using Furysoft.DynamicQuery.Logic.QueryParsers.WhereParsers;
    using Furysoft.DynamicQuery.Logic.Splitters;
    using Furysoft.DynamicQuery.Parsers;

    /// <inheritdoc />
    internal sealed class ParserCache : IParserCache
    {
        /// <summary>
        /// The parser cache.
        /// </summary>
        private static readonly ConcurrentDictionary<Type, object> Cache = new ConcurrentDictionary<Type, object>();

        /// <inheritdoc />
        public IStatementParser GetParser<TEntity>(ParserOptions parserOptions)
        {
            return (IStatementParser)Cache.GetOrAdd(
                typeof(TEntity),
                type => Initialize<TEntity>(parserOptions));
        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="parserOptions">The parser options.</param>
        /// <returns>The IEntityParser.</returns>
        private static object Initialize<TEntity>(ParserOptions parserOptions)
        {
            var tokenSplitter = new TokenSplitter();

            var rangeParser = new RangeParser();
            var equalsParser = new EqualsParser();

            var entityParser = new EntityParser<TEntity>();
            var typeSplitter = new TypeSplitter();

            var whereStatementParser = new WhereStatementParser<TEntity>(rangeParser, equalsParser, entityParser, typeSplitter);
            var whereParser = new WhereParser(whereStatementParser, parserOptions);
            var orderByParser = new OrderByParser<TEntity>(entityParser);
            var pageParser = new PageParser();
            var selectParser = new SelectParser<TEntity>(entityParser);

            return new StatementParser(tokenSplitter, whereParser, pageParser, orderByParser, selectParser);
        }
    }
}