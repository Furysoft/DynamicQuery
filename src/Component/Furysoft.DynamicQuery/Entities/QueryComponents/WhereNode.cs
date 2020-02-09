// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WhereNode.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Entities.QueryComponents
{
    using Furysoft.DynamicQuery.Entities.Nodes;

    /// <summary>
    /// The Where Node.
    /// </summary>
    public sealed class WhereNode
    {
        /// <summary>Gets or sets the conjunctive.</summary>
        public Conjunctives Conjunctive { get; set; }

        /// <summary>Gets or sets the next.</summary>
        public WhereNode Next { get; set; }

        /// <summary>Gets or sets the statement.</summary>
        public WhereStatement Statement { get; set; }
    }
}