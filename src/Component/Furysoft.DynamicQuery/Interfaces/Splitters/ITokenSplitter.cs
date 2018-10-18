// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ITokenSplitter.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Interfaces.Splitters
{
    using Entities;

    /// <summary>
    /// The Token Splitter Interface
    /// </summary>
    public interface ITokenSplitter
    {
        /// <summary>
        /// Splits a provided query statement based on key operators
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>The list of string</returns>
        TokenSplitterResponse SplitByToken(string query);
    }
}