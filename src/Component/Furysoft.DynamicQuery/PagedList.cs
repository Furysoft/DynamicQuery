// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PagedList.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace DynamicQuery
{
    using System.Collections.Generic;

    /// <summary>
    /// The Paged List
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public sealed class PagedList<TEntity>
    {
        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        public List<TEntity> Data { get; set; }

        /// <summary>
        /// Gets or sets the items per page.
        /// </summary>
        public int ItemsPerPage { get; set; }

        /// <summary>
        /// Gets or sets the page.
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Gets or sets the total items.
        /// </summary>
        public int TotalItems { get; set; }
    }
}