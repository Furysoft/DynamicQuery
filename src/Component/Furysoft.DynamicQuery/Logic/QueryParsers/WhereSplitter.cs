// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WhereSplitter.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Logic.QueryParsers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces.QueryParsers;

    /// <summary>
    /// The Where Splitter
    /// </summary>
    public sealed class WhereSplitter : IWhereSplitter
    {
        /// <summary>
        /// The tokens
        /// </summary>
        private static readonly string[] Tokens = new List<string> { "and", "or" }.ToArray();

        /// <summary>
        /// Splits the where.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <returns>The list of where parts</returns>
        public List<string> SplitWhere(string where)
        {
            return where.Split(Tokens, StringSplitOptions.RemoveEmptyEntries).Select(r => r.Trim()).ToList();
        }
    }
}