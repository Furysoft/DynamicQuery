// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RangeParser.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Logic.QueryParsers.WhereParsers
{
    using System;
    using System.Linq;
    using Entities.Nodes;
    using Entities.Operations;
    using Helpers;
    using Interfaces.QueryParsers;

    /// <summary>
    /// The Range Parser
    /// </summary>
    /// <seealso cref="IWhereStatementParser" />
    public sealed class RangeParser : IWhereStatementParser
    {
        /// <inheritdoc />
        public UnaryNode ParseStatement(string statement, string type = null)
        {
            var first = statement.First();
            var last = statement.Last();

            bool lowerInclusive;
            switch (first)
            {
                case '[':
                    lowerInclusive = false;
                    break;
                case '{':
                    lowerInclusive = true;
                    break;
                default:
                    throw new InvalidOperationException($"Character '{first}' is not a valid part of a range query");
            }

            bool upperInclusive;
            switch (last)
            {
                case ']':
                    upperInclusive = false;
                    break;
                case '}':
                    upperInclusive = true;
                    break;
                default:
                    throw new InvalidOperationException($"Character '{last}' is not a valid part of a range query");
            }

            var parts = statement
                .Substring(1, statement.Length - 2)
                .Split(',')
                .Select(s => s.Trim())
                .ToList();

            // If the first part is a wildcard, determine the last part only
            if (parts[0] == "*")
            {
                var lowerVal = ParserHelpers.Parse(parts[1], type);

                return new LessThanOperator
                {
                    Value = lowerVal,
                    Inclusive = upperInclusive,
                    Name = null,
                    Statement = statement
                };
            }

            // If the last part is a wildcard, determine the first part only
            if (parts[1] == "*")
            {
                var upperVal = ParserHelpers.Parse(parts[0], type);

                return new GreaterThanOperator
                {
                    Value = upperVal,
                    Inclusive = lowerInclusive,
                    Name = null,
                    Statement = statement
                };
            }

            var lower = ParserHelpers.Parse(parts[0], type);
            var upper = ParserHelpers.Parse(parts[1], type);

            return new RangeOperator
            {
                LowerInclusive = lowerInclusive,
                UpperInclusive = upperInclusive,
                Lower = lower,
                Upper = upper,
                Name = null,
                Statement = statement
            };
        }
    }
}