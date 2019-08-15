// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EqualsParser.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Logic.QueryParsers.WhereParsers
{
    using System.Linq;
    using Entities.Nodes;
    using Entities.Operations;
    using Helpers;
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
        /// <param name="type">The type.</param>
        /// <returns>
        /// The <see cref="UnaryNode" />
        /// </returns>
        public UnaryNode ParseStatement(string statement, string type = null)
        {
            var cleanedStatement = statement.Trim('"');

            var isNot = false;
            if (cleanedStatement.First() == '!')
            {
                isNot = true;
                cleanedStatement = cleanedStatement.Substring(1);
            }

            var value = ParserHelpers.Parse(cleanedStatement, type);

            return new EqualsOperator
            {
                Name = null,
                Value = value,
                IsNot = isNot,
                Statement = statement
            };
        }
    }
}