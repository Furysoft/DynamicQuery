// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISqlBuilder.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Interfaces
{
    /// <summary>
    /// The SQL Builder
    /// </summary>
    public interface ISqlBuilder
    {
        /// <summary>
        /// Builds the SQL.
        /// </summary>
        /// <returns>
        /// The SQL Query
        /// </returns>
        ISqlQuery BuildSql();

        /// <summary>
        /// Selects the specified select clause.
        /// </summary>
        /// <param name="selectClause">The select clause.</param>
        /// <returns>The ISqlBuilder</returns>
        ISqlBuilder Select(string selectClause);
    }
}