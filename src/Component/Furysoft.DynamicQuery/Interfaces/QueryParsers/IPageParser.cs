﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPageParser.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Interfaces.QueryParsers
{
    using Furysoft.DynamicQuery.Entities.QueryComponents;
    using JetBrains.Annotations;

    /// <summary>
    /// The Page Parser.
    /// </summary>
    public interface IPageParser
    {
        /// <summary>
        /// Parses the specified page data.
        /// </summary>
        /// <param name="pageData">The page data.</param>
        /// <returns>The Page Node.</returns>
        [CanBeNull]
        PageNode Parse([CanBeNull] string pageData);
    }
}