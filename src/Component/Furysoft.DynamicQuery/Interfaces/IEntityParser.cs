// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IEntityParser.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Interfaces
{
    using System.Collections.Generic;

    /// <summary>
    /// The Entity Parser
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IEntityParser<TEntity>
    {
        /// <summary>
        /// Gets the permitted properties.
        /// </summary>
        List<string> PermittedProperties { get; }

        /// <summary>
        /// Determines whether the specified name is permitted.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>
        ///   <c>true</c> if the specified name is permitted; otherwise, <c>false</c>.
        /// </returns>
        bool IsPermitted(string name);
    }
}