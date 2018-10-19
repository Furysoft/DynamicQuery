// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IWhereParser.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Interfaces.QueryParsers
{
    using Entities.Nodes;
    using Entities.QueryComponents;

    /// <summary>
    /// The Where Parser
    /// </summary>
    public interface IWhereParser
    {
        /// <summary>
        /// Parses the where.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <returns>The <see cref="WhereNode"/></returns>
        Node ParseWhere(string where);
    }
}