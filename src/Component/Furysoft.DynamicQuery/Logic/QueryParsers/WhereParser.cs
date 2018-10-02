// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WhereParser.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Logic.QueryParsers
{
    using Entities.QueryComponents;
    using Interfaces.QueryParsers;

    /// <summary>
    /// The Where Parser
    /// </summary>
    public sealed class WhereParser : IWhereParser
    {
        /// <summary>
        /// Parses the where.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <returns>The <see cref="WhereNode"/></returns>1
        public WhereNode ParseWhere(string where)
        {
            throw new System.NotImplementedException();
        }
    }
}