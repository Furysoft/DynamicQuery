// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SqlQuery.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Entities
{
    /// <summary>
    /// The SQL Query
    /// </summary>
    public sealed class SqlQuery
    {
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