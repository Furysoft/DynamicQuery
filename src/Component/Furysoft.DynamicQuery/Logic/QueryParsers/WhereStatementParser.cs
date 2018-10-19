// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WhereStatementParser.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Logic.QueryParsers
{
    using System.Linq;
    using Entities.Nodes;
    using Interfaces;
    using Interfaces.QueryParsers;
    using JetBrains.Annotations;

    /// <summary>
    /// The Where Statement Parser
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public sealed class WhereStatementParser<TEntity> : IWhereStatementParser
    {
        /// <summary>
        /// The equals parser
        /// </summary>
        [NotNull]
        private readonly IWhereStatementParser equalsParser;

        /// <summary>
        /// The range parser
        /// </summary>
        [NotNull]
        private readonly IWhereStatementParser rangeParser;

        /// <summary>
        /// The entity parser
        /// </summary>
        [NotNull]
        private readonly IEntityParser<TEntity> entityParser;

        /// <summary>
        /// Initializes a new instance of the <see cref="WhereStatementParser{TEntity}" /> class.
        /// </summary>
        /// <param name="rangeParser">The range parser.</param>
        /// <param name="equalsParser">The equals parser.</param>
        /// <param name="entityParser">The entity parser.</param>
        public WhereStatementParser(
            [NotNull] IWhereStatementParser rangeParser,
            [NotNull] IWhereStatementParser equalsParser,
            [NotNull] IEntityParser<TEntity> entityParser)
        {
            this.rangeParser = rangeParser;
            this.equalsParser = equalsParser;
            this.entityParser = entityParser;
        }

        /// <summary>
        /// Parses the statement.
        /// </summary>
        /// <param name="statement">The statement.</param>
        /// <returns>The <see cref="UnaryNode"/></returns>
        public UnaryNode ParseStatement(string statement)
        {
            var strings = statement.Split(':');

            var propertyName = strings[0].Trim();
            if (!this.entityParser.IsPermitted(propertyName))
            {
                return null;
            }

            var operation = strings[1].Trim();

            var firstChar = operation.First();
            if (firstChar == '[' || firstChar == '{')
            {
                var rtn = this.rangeParser.ParseStatement(operation);
                rtn.Name = propertyName;
                return rtn;
            }

            var unaryNode = this.equalsParser.ParseStatement(operation);
            unaryNode.Name = propertyName;
            unaryNode.Statement = statement;
            return unaryNode;
        }
    }
}