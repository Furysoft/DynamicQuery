// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IQuery.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Interfaces
{
    /// <summary>
    /// The Query Interface
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IQuery<TEntity>
    {
        /// <summary>
        /// Sets the columns to select
        /// </summary>
        /// <param name="select">The select.</param>
        /// <returns>The <see cref="IQuery{TEntity}"/></returns>
        IQuery<TEntity> Select(string select);

        /// <summary>
        /// Selects this instance.
        /// </summary>
        /// <typeparam name="TReturnType">The type of the return type.</typeparam>
        /// <returns>
        /// The <see cref="IQuery{TEntity}" />
        /// </returns>
        IQuery<TEntity> Select<TReturnType>();
    }
}