// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WhereSplitter.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Logic.Splitters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces.Splitters;

    /// <inheritdoc />
    public sealed class WhereSplitter : IWhereSplitter
    {
        /// <summary>
        /// The tokens
        /// </summary>
        private static readonly string[] Tokens = new List<string> { "and", "or" }.ToArray();

        /// <inheritdoc />
        public List<string> SplitWhere(string where)
        {
            return where.Split(Tokens, StringSplitOptions.RemoveEmptyEntries).Select(r => r.Trim()).ToList();
        }
    }
}