// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WhereNode.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Entities.QueryComponents
{
    /// <summary>
    /// The Where Node
    /// </summary>
    public abstract class WhereNode : Node
    {
        /// <summary>
        /// Gets or sets the conjunction.
        /// </summary>
        public Conjunctions Conjunction { get; set; }

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance has children.
        /// </summary>
        public bool HasChildren { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is not.
        /// </summary>
        public bool IsNot { get; set; }

        /// <summary>
        /// Gets or sets the left node.
        /// </summary>
        public WhereNode LeftNode { get; set; }

        /// <summary>
        /// Gets or sets the right node.
        /// </summary>
        public WhereNode RightNode { get; set; }
    }
}