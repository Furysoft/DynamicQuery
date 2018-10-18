﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GreaterThanNode.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Entities.QueryComponents.WhereNodes
{
    /// <summary>
    /// The Greater Than Node
    /// </summary>
    public sealed class GreaterThanNode : UnaryNode
    {
        /// <summary>
        /// Gets or sets the lower.
        /// </summary>
        public object Value { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [lower inclusive].
        /// </summary>
        public bool Inclusive { get; set; }
    }
}