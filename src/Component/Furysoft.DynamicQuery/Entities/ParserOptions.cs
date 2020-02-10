// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParserOptions.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Entities
{
    /// <summary>
    /// The Parser Options.
    /// </summary>
    internal sealed class ParserOptions
    {
        /// <summary>Gets or sets a value indicating whether [allow and].</summary>
        public bool AllowAnd { get; set; } = true;

        /// <summary>Gets or sets a value indicating whether [allow or].</summary>
        public bool AllowOr { get; set; } = true;
    }
}