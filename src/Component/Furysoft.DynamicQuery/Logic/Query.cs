// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Query.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Logic
{
    using System.Linq;
    using Entities.QueryComponents;
    using Interfaces;

    /// <summary>
    /// The Query
    /// </summary>
    /// <seealso cref="IQuery" />
    public sealed class Query : IQuery
    {
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
        /// <returns>The <see cref="IQuery"/></returns>
        public IQuery Select(string select)
        {
            var selectColumns = select.Split(',').Select(r => r.Trim()).ToList();
            this.SelectNode = new SelectNode { SelectColumns = selectColumns };

            return this;
        }

        /// <summary>
        /// Selects this instance.
        /// </summary>
        /// <typeparam name="TReturnType">The type of the return type.</typeparam>
        /// <returns>
        /// The <see cref="IQuery" />
        /// </returns>
        public IQuery Select<TReturnType>()
        {
            throw new System.NotImplementedException();
        }
    }
}