﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PageParser.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Logic.QueryParsers
{
    using Entities.QueryComponents;
    using Interfaces.QueryParsers;

    /// <summary>
    /// The Page Parser
    /// </summary>
    public sealed class PageParser : IPageParser
    {
        /// <summary>
        /// Parses the specified page data.
        /// </summary>
        /// <param name="pageData">The page data.</param>
        /// <returns>The Page Node</returns>
        public PageNode Parse(string pageData)
        {
            var strings = pageData.Split(',');

            int.TryParse(strings[0], out var page);
            int.TryParse(strings[1], out var itemsPerPage);

            return new PageNode
            {
                Page = page,
                ItemsPerPage = itemsPerPage
            };
        }
    }
}