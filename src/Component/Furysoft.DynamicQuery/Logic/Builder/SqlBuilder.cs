// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SqlBuilder.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Logic.Builder
{
    using Interfaces;

    /// <summary>
    /// THe SQL Builder
    /// </summary>
    /// <seealso cref="Furysoft.DynamicQuery.Interfaces.ISqlBuilder" />
    public sealed class SqlBuilder : ISqlBuilder
    {
        /// <summary>
        /// Builds the SQL.
        /// </summary>
        /// <returns>
        /// The SQL Query
        /// </returns>
        public ISqlQuery BuildSql()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Selects the specified select clause.
        /// </summary>
        /// <param name="selectClause">The select clause.</param>
        /// <returns>The ISqlBuilder</returns>
        public ISqlBuilder Select(string selectClause)
        {
            throw new System.NotImplementedException();
        }
    }
}