// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WhereStatementParser.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Logic.QueryParsers
{
    using System;
    using System.Linq;
    using Entities.QueryComponents;
    using Interfaces.QueryParsers;
    using JetBrains.Annotations;

    /// <summary>
    /// The Where Statement Parser
    /// </summary>
    public sealed class WhereStatementParser : IWhereStatementParser
    {
        /// <summary>
        /// The range parser
        /// </summary>
        [NotNull]
        private readonly IWhereStatementParser rangeParser;

        /// <summary>
        /// The equals parser
        /// </summary>
        [NotNull]
        private readonly IWhereStatementParser equalsParser;

        /// <summary>
        /// Initializes a new instance of the <see cref="WhereStatementParser" /> class.
        /// </summary>
        /// <param name="rangeParser">The range parser.</param>
        /// <param name="equalsParser">The equals parser.</param>
        public WhereStatementParser(
            [NotNull] IWhereStatementParser rangeParser, 
            [NotNull] IWhereStatementParser equalsParser)
        {
            this.rangeParser = rangeParser;
            this.equalsParser = equalsParser;
        }

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

            var firstChar = operation.First();
            if (firstChar == '[' || firstChar == '{')
            {
                var rtn = this.rangeParser.ParseStatement(operation);
                rtn.Name = propertyName;
                return rtn;
            }

            var unaryNode = this.rangeParser.ParseStatement(operation);
            unaryNode.Name = propertyName;
            return unaryNode;
        }
    }
}