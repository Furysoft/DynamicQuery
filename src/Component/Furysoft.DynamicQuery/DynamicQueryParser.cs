// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DynamicQueryParser.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery
{
    using Furysoft.DynamicQuery.Interfaces;
    using Furysoft.DynamicQuery.Interfaces.Caching;
    using Furysoft.DynamicQuery.Logic.Caching;

    /// <inheritdoc />
    public sealed class DynamicQueryParser : IDynamicQueryParser
    {
        /// <summary>
        /// The parser cache.
        /// </summary>
        private static readonly IParserCache ParserCache = new ParserCache();

        /// <inheritdoc />
        public IQuery Parse<TEntity>(string query)
        {
            var entityParser = ParserCache.GetParser<TEntity>();

            return entityParser.ParseQuery(query);
        }
    }
}