// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISqlQuery.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Interfaces
{
    /// <summary>
    /// The SQL Query Interface
    /// </summary>
    public interface ISqlQuery
    {
        /// <summary>
        /// Gets the data.
        /// </summary>
        object Data { get; }

        /// <summary>
        /// Gets the SQL.
        /// </summary>
        string Sql { get; }
    }
}