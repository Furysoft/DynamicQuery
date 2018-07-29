// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EntityCache.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace DynamicQuery.Caching
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;

    /// <summary>
    /// The Entity Cache
    /// </summary>
    public sealed class EntityCache
    {
        /// <summary>
        /// The cache
        /// </summary>
        private static readonly ConcurrentDictionary<Type, List<string>> Cache = new ConcurrentDictionary<Type, List<string>>();

        /// <summary>
        /// Gets the or add.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="values">The values.</param>
        /// <returns>The Cached list of strings</returns>
        public List<string> GetOrAdd(Type key, List<string> values)
        {
            return Cache.GetOrAdd(key, values);
        }
    }
}