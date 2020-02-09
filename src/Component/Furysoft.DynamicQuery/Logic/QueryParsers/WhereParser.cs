// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WhereParser.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Logic.QueryParsers
{
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;
    using Furysoft.DynamicQuery.Entities.Nodes;
    using Furysoft.DynamicQuery.Entities.QueryComponents;
    using Furysoft.DynamicQuery.Interfaces.QueryParsers;
    using JetBrains.Annotations;

    /// <summary>
    /// The Where Parser.
    /// </summary>
    internal sealed class WhereParser : IWhereParser
    {
        /// <summary>The regex test.</summary>
        private static readonly Regex RegexTest = new Regex("(and|or)");

        /// <summary>
        /// The where statement parser.
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
        /// <returns>The <see cref="WhereNode"/>.</returns>1
        public WhereNode ParseWhere(string where)
        {
            if (string.IsNullOrWhiteSpace(where))
            {
                return null;
            }

            var whereParts = new List<string>();
            var sb = new StringBuilder();
            var isQuoted = false;
            foreach (var character in where)
            {
                if (!isQuoted && character.Equals('"'))
                {
                    isQuoted = true;
                    continue;
                }

                if (isQuoted && character.Equals('"'))
                {
                    isQuoted = false;
                    continue;
                }

                if (!isQuoted && character.Equals(' '))
                {
                    whereParts.Add(sb.ToString());
                    sb = new StringBuilder();
                    continue;
                }

                sb.Append(character);
            }

            whereParts.Add(sb.ToString());

            var node = this.ParseStatements(new WhereNode(), whereParts, 0);

            return node;
        }

        /// <summary>
        /// Parses the local.
        /// </summary>
        /// <param name="parts">The parts.</param>
        /// <param name="index">The index.</param>
        /// <returns>The data.</returns>
        private (int index, WhereStatement where) ParseLocal(List<string> parts, int index)
        {
            if (parts.Count > index + 1 && parts[index + 1] == "as")
            {
                var asString = parts[index + 2];
                var whereNode = this.whereStatementParser.ParseStatement(parts[index], asString);
                return (index + 3, new WhereStatement { As = asString, Value = whereNode });
            }

            var where = this.whereStatementParser.ParseStatement(parts[index]);
            return (index + 1, new WhereStatement { Value = where, As = null });
        }

        /// <summary>
        /// Parses the statements.
        /// </summary>
        /// <param name="last">The last.</param>
        /// <param name="statements">The statements.</param>
        /// <param name="index">The index.</param>
        /// <returns>The <see cref="WhereNode"/>.</returns>
        private WhereNode ParseStatements(WhereNode last, List<string> statements, int index)
        {
            var whereStatement = this.ParseLocal(statements, index);
            index = whereStatement.index;
            if (index == statements.Count)
            {
                return new WhereNode { Conjunctive = Conjunctives.None, Next = null, Statement = whereStatement.where };
            }

            if (statements[index] == "and")
            {
                last.Conjunctive = Conjunctives.And;
            }

            if (statements[index] == "or")
            {
                last.Conjunctive = Conjunctives.Or;
            }

            last.Statement = whereStatement.where;
            last.Next = this.ParseStatements(new WhereNode(), statements, index + 1);

            return last;
        }
    }
}