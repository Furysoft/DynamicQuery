// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EqualsParser.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Logic.QueryParsers.WhereParsers
{
    using System;
    using System.Linq;
    using Entities.Nodes;
    using Entities.Operations;
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
            var cleanedStatement = statement;

            var isNot = false;
            if (cleanedStatement.First() == '!')
            {
                isNot = true;
                cleanedStatement = cleanedStatement.Substring(1);
            }

            // If it's a number
            if (int.TryParse(cleanedStatement, out var intValue))
            {
                return new EqualsOperator
                {
                    Name = null,
                    Value = intValue,
                    IsNot = isNot,
                    Statement = statement
                };
            }

            // If it's a datetime
            if (DateTime.TryParse(cleanedStatement, out var dateTimeValue))
            {
                return new EqualsOperator
                {
                    Name = null,
                    Value = dateTimeValue,
                    IsNot = isNot,
                    Statement = statement
                };
            }

            // Trim after, if " are present, the entity is treated as a string
            cleanedStatement = cleanedStatement.Trim('"');

            return new EqualsOperator
            {
                Name = null,
                Value = cleanedStatement,
                IsNot = isNot,
                Statement = statement
            };
        }
    }
}