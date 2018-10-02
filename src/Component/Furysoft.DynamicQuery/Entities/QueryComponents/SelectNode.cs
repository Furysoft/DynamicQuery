// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SelectNode.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Entities.QueryComponents
{
    using System.Collections.Generic;

    /// <summary>
    /// The Select Node
    /// </summary>
    public sealed class SelectNode
    {
        /// <summary>
        /// Gets or sets the select columns.
        /// </summary>
        public List<string> SelectColumns { get; set; }
    }
}