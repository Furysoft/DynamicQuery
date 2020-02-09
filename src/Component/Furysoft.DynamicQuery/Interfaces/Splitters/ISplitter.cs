// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISplitter.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Interfaces.Splitters
{
    /// <summary>
    /// The Splitter Interface.
    /// </summary>
    /// <typeparam name="TResponse">The type of the response.</typeparam>
    public interface ISplitter<out TResponse>
    {
        /// <summary>
        /// Splits a provided query statement based on key operators.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>
        /// The list of string.
        /// </returns>
        TResponse SplitByToken(string query);
    }
}