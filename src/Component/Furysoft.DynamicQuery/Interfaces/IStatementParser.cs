// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IStatementParser.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Interfaces
{
    /// <summary>
    /// The Statement Parser
    /// </summary>
    public interface IStatementParser
    {
        /// <summary>
        /// Parses the query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>The <see cref="IQuery"/></returns>
        IQuery ParseQuery(string query);
    }
}