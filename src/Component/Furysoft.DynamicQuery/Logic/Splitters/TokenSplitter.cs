// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TokenSplitter.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Logic.Splitters
{
    using System.Linq;
    using System.Text.RegularExpressions;
    using Furysoft.DynamicQuery.Entities;
    using Furysoft.DynamicQuery.Interfaces.Splitters;

    /// <inheritdoc />
    public sealed class TokenSplitter : ISplitter<TokenSplitterResponse>
    {
        /// <summary>
        /// The regex.
        /// </summary>
        private static readonly Regex RegexQuery = new Regex("(select::|where::|orderby::|page::)", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);

        /// <inheritdoc />
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
                case "select::":
                    response.Select = Regex.Unescape(data).Trim();
                    return;
            }
        }
    }
}