// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICache.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Interfaces
{
    /// <summary>
    /// The Cache
    /// </summary>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    public interface ICache<TKey, TValue>
    {
        /// <summary>
        /// Gets the or add.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns>The <see cref="!:TValue"/></returns>
        TValue GetOrAdd(TKey key, TValue value);
    }
}