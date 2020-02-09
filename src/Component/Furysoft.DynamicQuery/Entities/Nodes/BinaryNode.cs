// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BinaryNode.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Entities.Nodes
{
    /// <summary>
    /// The Binary Node.
    /// </summary>
    public class BinaryNode : Node
    {
        // ReSharper disable once UnusedAutoPropertyAccessor.Global

        /// <summary>Gets or sets the conjunctive.</summary>
        public Conjunctives Conjunctive { get; set; }

        /// <summary>Gets or sets the left node.</summary>
        public Node LeftNode { get; set; }

        /// <summary>Gets or sets the right node.</summary>
        public Node RightNode { get; set; }
    }
}