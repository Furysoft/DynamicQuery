// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IParserCache.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Interfaces.Caching
{
    using Furysoft.DynamicQuery.Entities;
    using JetBrains.Annotations;

    /// <summary>
    /// The Parser Cache.
    /// </summary>
    internal interface IParserCache
    {
        /// <summary>
        /// Gets the parser.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="options">The options.</param>
        /// <returns>The <see cref="IEntityParser{TEntity}" />.</returns>
        IStatementParser GetParser<TEntity>([NotNull] ParserOptions options);
    }
}