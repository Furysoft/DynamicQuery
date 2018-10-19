// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DynamicQueryParser.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery
{
    using Interfaces;
    using Interfaces.Caching;
    using Logic.Caching;

    /// <inheritdoc />
    public sealed class DynamicQueryParser : IDynamicQueryParser
    {
        /// <summary>
        /// The parser cache
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