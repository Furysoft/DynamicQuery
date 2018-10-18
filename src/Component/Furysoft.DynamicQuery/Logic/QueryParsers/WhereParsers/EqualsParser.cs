// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EqualsParser.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Logic.QueryParsers.WhereParsers
{
    using System.Linq;
    using Entities.QueryComponents;
    using Entities.QueryComponents.WhereNodes;
    using Interfaces.QueryParsers;

    /// <summary>
    /// The Equals Parser
    /// </summary>
    public sealed class EqualsParser : IWhereStatementParser
    {
        /// <summary>
        /// Parses the statement.
        /// </summary>
        /// <param name="statement">The statement.</param>
        /// <returns>The <see cref="UnaryNode"/></returns>
        public UnaryNode ParseStatement(string statement)
        {
            var isNot = false;
            if (statement.First() == '!')
            {
                isNot = true;
                statement = statement.Substring(1);
            }

            return new EqualsNode
            {
                Name = null,
                Value = statement.Trim('"'),
                IsNot = isNot
            };
        }
    }
}