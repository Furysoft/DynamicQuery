﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PageNode.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Entities.QueryComponents
{
    using Furysoft.DynamicQuery.Entities.Nodes;

    /// <summary>
    /// The Page Node.
    /// </summary>
    public sealed class PageNode : UnaryNode
    {
        /// <summary>
        /// Gets or sets the items per page.
        /// </summary>
        public int ItemsPerPage { get; set; }

        /// <summary>
        /// Gets or sets the page.
        /// </summary>
        public int Page { get; set; }
    }
}