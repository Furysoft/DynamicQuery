// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QueryParser.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery
{
    using Interfaces;
    using Interfaces.Caching;
    using Logic.Caching;

    /// <summary>
    /// The Query Parser
    /// </summary>
    /// <seealso cref="IQueryParser" />
    public sealed class QueryParser : IQueryParser
    {
        /// <summary>
        /// The parser cache
        /// </summary>
        private static readonly IParserCache ParserCache = new ParserCache();

        /// <summary>
        /// Parses the specified query.
        /// </summary>
        /// <typeparam name="TEntity">The data type</typeparam>
        /// <param name="query">The query.</param>
        /// <returns>
        /// The Query Interface
        /// </returns>
        public IQuery Parse<TEntity>(string query)
        {
            var entityParser = ParserCache.GetParser<TEntity>();

            return entityParser.ParseQuery(query);
        }
    }
}