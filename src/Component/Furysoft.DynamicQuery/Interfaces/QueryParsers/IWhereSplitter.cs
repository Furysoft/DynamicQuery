// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IWhereSplitter.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Interfaces.QueryParsers
{
    using System.Collections.Generic;

    /// <summary>
    /// The Where Splitter Interface
    /// </summary>
    public interface IWhereSplitter
    {
        /// <summary>
        /// Splits the where.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <returns>The list of where parts</returns>
        List<string> SplitWhere(string where);
    }
}