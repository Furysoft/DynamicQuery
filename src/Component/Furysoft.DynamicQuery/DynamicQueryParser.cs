// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DynamicQueryParser.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery
{
    using Furysoft.DynamicQuery.Entities;
    using Furysoft.DynamicQuery.Interfaces;
    using Furysoft.DynamicQuery.Interfaces.Caching;
    using Furysoft.DynamicQuery.Logic.Caching;
    using JetBrains.Annotations;

    /// <inheritdoc />
    public sealed class DynamicQueryParser : IDynamicQueryParser
    {
        /// <summary>
        /// The parser cache.
        /// </summary>
        private static readonly IParserCache ParserCache = new ParserCache();

        /// <summary>
        /// The parser options.
        /// </summary>
        [NotNull]
        private readonly ParserOptions parserOptions;

        /// <summary>
        /// Initializes a new instance of the <see cref="DynamicQueryParser" /> class.
        /// </summary>
        /// <param name="allowAnd">if set to <c>true</c> [allow and].</param>
        /// <param name="allowOr">if set to <c>true</c> [allow or].</param>
        public DynamicQueryParser(bool allowAnd = true, bool allowOr = true)
        {
            this.parserOptions = new ParserOptions
            {
                AllowOr = allowOr,
                AllowAnd = allowAnd,
            };
        }

        /// <inheritdoc />
        public IQuery Parse<TEntity>(string query)
        {
            var entityParser = ParserCache.GetParser<TEntity>(this.parserOptions);

            return entityParser.ParseQuery(query);
        }
    }
}