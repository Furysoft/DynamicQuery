// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TokenSplitterResponse.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Entities
{
    /// <summary>
    /// The Token Splitter Response
    /// </summary>
    public sealed class TokenSplitterResponse
    {
        /// <summary>
        /// Gets or sets the where.
        /// </summary>
        public string Where { get; set; }

        /// <summary>
        /// Gets or sets the order by.
        /// </summary>
        public string OrderBy { get; set; }

        /// <summary>
        /// Gets or sets the page.
        /// </summary>
        public string Page { get; set; }
    }
}