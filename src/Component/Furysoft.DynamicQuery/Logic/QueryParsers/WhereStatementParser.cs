// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WhereStatementParser.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Logic.QueryParsers
{
    using System.Linq;
    using Entities.QueryComponents;
    using Interfaces.QueryParsers;

    /// <summary>
    /// The Where Statement Parser
    /// </summary>
    public sealed class WhereStatementParser : IWhereStatementParser
    {
        /// <summary>
        /// Parses the statement.
        /// </summary>
        /// <param name="statement">The statement.</param>
        /// <returns>The <see cref="UnaryNode"/></returns>
        public UnaryNode ParseStatement(string statement)
        {
            var strings = statement.Split(':');

            var propertyName = strings[0];
            var operation = strings[1].Trim();

            /* operation is an exclusive range check */
            if (operation.First() == '[' && operation.Last() == ']')
            {
                var s = operation.Substring(1, operation.Length - 1).Split(',').ToList();
            }

            throw new System.NotImplementedException();
        }
    }
}