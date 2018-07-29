// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DynamicQuery.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace DynamicQuery
{
    /// <summary>
    /// The Dynamic Query
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public sealed class DynamicQuery<TEntity>
        where TEntity : class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DynamicQuery{TEntity}" /> class.
        /// </summary>
        /// <param name="template">The template.</param>
        /// <param name="query">The query.</param>
        public DynamicQuery(TEntity template, string query)
        {
        }

        /// <summary>
        /// Gets the data.
        /// </summary>
        public object Data { get; }

        /// <summary>
        /// Gets the SQL.
        /// </summary>
        public string Sql { get; }
    }
}