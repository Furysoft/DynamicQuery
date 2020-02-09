// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WhereStatement.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Entities.QueryComponents
{
    using Furysoft.DynamicQuery.Entities.Nodes;

    /// <summary>
    /// The Where Statement.
    /// </summary>
    public sealed class WhereStatement
    {
        /// <summary>Gets or sets the value.</summary>
        public Node Value { get; set; }

        /// <summary>Gets or sets as.</summary>
        public string As { get; set; }
    }
}