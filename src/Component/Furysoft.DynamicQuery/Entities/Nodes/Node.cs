// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Node.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Entities.Nodes
{
    /// <summary>
    /// The Node.
    /// </summary>
    public abstract class Node
    {
        /// <summary>Gets or sets the data.</summary>
        public string Statement { get; set; }

        /// <summary>Gets or sets the name.</summary>
        public string Name { get; set; }
    }
}