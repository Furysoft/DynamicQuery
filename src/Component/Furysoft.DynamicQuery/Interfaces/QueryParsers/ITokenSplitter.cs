// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ITokenSplitter.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Interfaces.QueryParsers
{
    using System.Collections.Generic;
    using Entities;

    /// <summary>
    /// The Token Splitter Interface
    /// </summary>
    public interface ITokenSplitter
    {
        /// <summary>
        /// Splits the by token.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>The list of string</returns>
        TokenSplitterResponse SplitByToken(string query);
    }
}