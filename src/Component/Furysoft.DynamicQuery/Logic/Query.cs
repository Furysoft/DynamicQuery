// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Query.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Logic
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using Entities.QueryComponents;
    using Interfaces;
    using JetBrains.Annotations;

    /// <summary>
    /// The Query
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <seealso cref="IQuery{TEntity}" />
    public sealed class Query<TEntity> : IQuery<TEntity>
    {
        /// <summary>
        /// The tokens validator
        /// </summary>
        [NotNull]
        private readonly IEntityParser<TEntity> entityParser;

        /// <summary>
        /// Initializes a new instance of the <see cref="Query{TEntity}" /> class.
        /// </summary>
        /// <param name="entityParser">The entity parser.</param>
        public Query([NotNull] IEntityParser<TEntity> entityParser)
        {
            this.entityParser = entityParser;
        }

        /// <summary>
        /// Gets the order by node.
        /// </summary>
        public OrderByNode OrderByNode { get; }

        /// <summary>
        /// Gets the select node.
        /// </summary>
        public SelectNode SelectNode { get; private set; }

        /// <summary>
        /// Gets The where node
        /// </summary>
        public WhereNode WhereNode { get; }

        /// <summary>
        /// Sets the columns to select
        /// </summary>
        /// <param name="select">The select.</param>
        /// <returns>The <see cref="IQuery{TEntity}"/></returns>
        public IQuery<TEntity> Select(string select)
        {
            var selectColumns = select.Split(',').Select(r => r.Trim()).Where(r => this.entityParser.IsPermitted(r)).ToList();
            this.SelectNode = new SelectNode { SelectColumns = selectColumns };

            return this;
        }

        /// <summary>
        /// Selects this instance.
        /// </summary>
        /// <typeparam name="TReturnType">The type of the return type.</typeparam>
        /// <returns>
        /// The <see cref="IQuery{TEntity}" />
        /// </returns>
        public IQuery<TEntity> Select<TReturnType>()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// And the where.
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        /// <param name="value">The value.</param>
        /// <returns>
        /// The <see cref="IQuery{TEntity}" />
        /// </returns>
        public IQuery<TEntity> AndWhere(string columnName, object value)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// And the where.
        /// </summary>
        /// <typeparam name="TType">The type of the type.</typeparam>
        /// <param name="ex">The ex.</param>
        /// <param name="value">The value.</param>
        /// <returns>
        /// The <see cref="IQuery{TEntity}" />
        /// </returns>
        public IQuery<TEntity> AndWhere<TType>(Expression<Func<TEntity, TType>> ex, object value)
        {
            throw new System.NotImplementedException();
        }
    }
}