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

    /// <inheritdoc />
    internal sealed class ParserCache : IParserCache
    {
        /// <summary>
        /// The parser cache
        /// </summary>
        private static readonly ConcurrentDictionary<Type, object> Cache = new ConcurrentDictionary<Type, object>();

        /// <inheritdoc />
        public IEntityParser<TEntity> GetParser<TEntity>()
        {
            return (IEntityParser<TEntity>)Cache.GetOrAdd(
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
            return new EntityParser<TEntity>();
        }
    }
}