// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RangeParser.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Logic.QueryParsers.WhereParsers
{
    using System;
    using System.Linq;
    using Entities.QueryComponents;
    using Entities.QueryComponents.WhereNodes;
    using Interfaces.QueryParsers;

    /// <summary>
    /// The Range Parser
    /// </summary>
    /// <seealso cref="IWhereStatementParser" />
    public sealed class RangeParser : IWhereStatementParser
    {
        /// <summary>
        /// Parses the statement.
        /// </summary>
        /// <param name="statement">The statement.</param>
        /// <returns>The <see cref="UnaryNode"/></returns>
        public UnaryNode ParseStatement(string statement)
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

            if (parts[0] == "*")
            {
                int.TryParse(parts[1], out var lowerVal);

                return new LessThanNode
                {
                    Value = lowerVal,
                    Inclusive = upperInclusive
                };
            }

            if (parts[1] == "*")
            {
                int.TryParse(parts[0], out var upperVal);

                return new GreaterThanNode
                {
                    Value = upperVal,
                    Inclusive = lowerInclusive
                };
            }

            int.TryParse(parts[0], out var lower);
            int.TryParse(parts[1], out var upper);

            return new RangeNode
            {
                LowerInclusive = lowerInclusive,
                UpperInclusive = upperInclusive,
                Lower = lower,
                Upper = upper
            };
        }
    }
}