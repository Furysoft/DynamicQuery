// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QueryParser.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Parsers
{
    using Interfaces;

    /// <summary>
    /// The Query Parser
    /// </summary>
    /// <seealso cref="IQueryParser" />
    public sealed class QueryParser : IQueryParser
    {
        /// <summary>
        /// Parses the specified query.
        /// </summary>
        /// <typeparam name="TEntity">The data type</typeparam>
        /// <param name="query">The query.</param>
        /// <returns>
        /// The Query Interface
        /// </returns>
        public IQuery Parse<TEntity>(string query)
        {
            throw new System.NotImplementedException();
        }
    }
}