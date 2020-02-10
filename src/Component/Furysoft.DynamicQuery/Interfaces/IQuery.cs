// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IQuery.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Interfaces
{
    using System.Collections.Generic;
    using Furysoft.DynamicQuery.Entities.QueryComponents;

    /// <summary>
    /// The Query Interface.
    /// </summary>
    public interface IQuery
    {
        /// <summary>Gets or sets the order by node.</summary>
        List<OrderByNode> OrderByNodes { get; set; }

        /// <summary>Gets or sets the page node.</summary>
        PageNode PageNode { get; set; }

        /// <summary>Gets or sets the where node.</summary>
        SelectNode SelectNode { get; set; }

        /// <summary>Gets or sets the where node.</summary>
        WhereNode WhereNode { get; set; }

        /// <summary>
        /// Wheres this instance.
        /// </summary>
        /// <param name="whereClause">The where clause.</param>
        /// <returns>The <see cref="IQuery"/>.</returns>
        IQuery Where(string whereClause);

        /// <summary>
        /// Wheres the specified node.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns>The <see cref="IQuery"/>.</returns>
        IQuery Where(WhereNode node);

        /// <summary>
        /// Pages the specified page.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="itemsPerPage">The items per page.</param>
        /// <param name="replaceUserValue">if set to <c>true</c> [replace user value].</param>
        /// <returns>The <see cref="IQuery"/>.</returns>
        IQuery Page(int page, int itemsPerPage, bool replaceUserValue = false);

        /// <summary>
        /// Selects all.
        /// </summary>
        /// <param name="replaceUserValue">if set to <c>true</c> [replace user value].</param>
        /// <returns>The <see cref="IQuery"/>.</returns>
        IQuery SelectAll(bool replaceUserValue = false);

        /// <summary>
        /// Selects all.
        /// </summary>
        /// <param name="columns">The columns.</param>
        /// <param name="replaceUserValue">if set to <c>true</c> [replace user value].</param>
        /// <param name="separator">The separator.</param>
        /// <returns>The <see cref="IQuery" />.</returns>
        IQuery Select(string columns, bool replaceUserValue = false, char separator = ',');

        /// <summary>
        /// Selects all.
        /// </summary>
        /// <param name="replaceUserValue">if set to <c>true</c> [replace user value].</param>
        /// <param name="columns">The columns.</param>
        /// <returns>The <see cref="IQuery" />.</returns>
        IQuery Select(bool replaceUserValue = false, params string[] columns);
    }
}