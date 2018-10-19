// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WhereParser.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Logic.QueryParsers
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Entities.Nodes;
    using Entities.QueryComponents;
    using Interfaces.QueryParsers;
    using JetBrains.Annotations;

    /// <summary>
    /// The Where Parser
    /// </summary>
    internal sealed class WhereParser : IWhereParser
    {
        /// <summary>The regex test</summary>
        private static readonly Regex RegexTest = new Regex("(and|or)");

        /// <summary>
        /// The where statement parser
        /// </summary>
        [NotNull]
        private readonly IWhereStatementParser whereStatementParser;

        /// <summary>
        /// Initializes a new instance of the <see cref="WhereParser" /> class.
        /// </summary>
        /// <param name="whereStatementParser">The where statement parser.</param>
        public WhereParser([NotNull] IWhereStatementParser whereStatementParser)
        {
            this.whereStatementParser = whereStatementParser;
        }

        /// <summary>
        /// Parses the where.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <returns>The <see cref="WhereNode"/></returns>1
        public Node ParseWhere(string where)
        {
            return this.ParseLocal(where);
        }

        /// <summary>
        /// Parses the local.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <returns>The <see cref="WhereNode"/></returns>
        private Node ParseLocal(string where)
        {
            var strings = RegexTest.Split(where, 2).ToList();

            // If there's only 1, we're done. No need to parse more!
            if (strings.Count == 1)
            {
                return this.whereStatementParser.ParseStatement(strings[0]);
            }

            Enum.TryParse(strings[1], out Conjunctives conjunctive);

            var leftNode = this.ParseLocal(strings[0]);
            var rightNode = this.ParseLocal(strings[2]);

            return new BinaryNode
            {
                LeftNode = leftNode,
                Conjunctive = conjunctive,
                RightNode = rightNode,
                Name = null,
                Statement = where
            };
        }
    }
}