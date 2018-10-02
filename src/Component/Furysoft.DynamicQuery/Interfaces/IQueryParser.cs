// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IQueryParser.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Interfaces
{
    /// <summary>
    /// The Query Parser Interface
    /// </summary>
    public interface IQueryParser
    {
        /// <summary>
        /// Parses the specified query.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="query">The query.</param>
        /// <returns>
        /// The Query Interface
        /// </returns>
        IQuery Parse<TEntity>(string query);
    }
}