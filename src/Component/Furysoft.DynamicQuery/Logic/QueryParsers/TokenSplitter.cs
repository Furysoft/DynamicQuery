// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TokenSplitter.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Logic.QueryParsers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Entities;
    using Interfaces.QueryParsers;

    /// <summary>
    /// The Token Splitter
    /// </summary>
    public sealed class TokenSplitter : ITokenSplitter
    {
        /// <summary>
        /// The regex
        /// </summary>
        private static readonly Regex RegexQuery = new Regex("(where::|orderby::|page::)", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);

        /// <summary>
        /// Splits the by token.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>The list of string</returns>
        public TokenSplitterResponse SplitByToken(string query)
        {
            var rtn = new TokenSplitterResponse();

            var escapedQuery = Regex.Escape(query);

            var strings = RegexQuery.Split(escapedQuery).Where(r => !string.IsNullOrWhiteSpace(r)).ToList();

            for (var i = 0; i < strings.Count; i = i + 2)
            {
                SetValue(rtn, strings[i], strings[i + 1]);
            }

            return rtn;
        }

        /// <summary>
        /// Sets the value.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <param name="query">The query.</param>
        /// <param name="data">The data.</param>
        private static void SetValue(TokenSplitterResponse response, string query, string data)
        {
            switch (query)
            {
                case "where::":
                    response.Where = Regex.Unescape(data).Trim();
                    return;
                case "orderby::":
                    response.OrderBy = Regex.Unescape(data).Trim();
                    return;
                case "page::":
                    response.Page = Regex.Unescape(data).Trim();
                    return;
            }
        }
    }
}