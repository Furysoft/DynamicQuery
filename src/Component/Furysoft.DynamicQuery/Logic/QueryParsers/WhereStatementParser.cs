// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WhereStatementParser.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Logic.QueryParsers
{
    using System.Linq;
    using Furysoft.DynamicQuery.Entities;
    using Furysoft.DynamicQuery.Entities.Nodes;
    using Furysoft.DynamicQuery.Interfaces;
    using Furysoft.DynamicQuery.Interfaces.QueryParsers;
    using Furysoft.DynamicQuery.Interfaces.Splitters;
    using JetBrains.Annotations;

    /// <summary>
    /// The Where Statement Parser.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public sealed class WhereStatementParser<TEntity> : IWhereStatementParser
    {
        /// <summary>
        /// The equals parser.
        /// </summary>
        [NotNull]
        private readonly IWhereStatementParser equalsParser;

        /// <summary>
        /// The range parser.
        /// </summary>
        [NotNull]
        private readonly IWhereStatementParser rangeParser;

        /// <summary>
        /// The entity parser.
        /// </summary>
        [NotNull]
        private readonly IEntityParser<TEntity> entityParser;

        /// <summary>
        /// The type splitter.
        /// </summary>
        [NotNull]
        private readonly ISplitter<TypeSplitterResponse> typeSplitter;

        /// <summary>
        /// Initializes a new instance of the <see cref="WhereStatementParser{TEntity}" /> class.
        /// </summary>
        /// <param name="rangeParser">The range parser.</param>
        /// <param name="equalsParser">The equals parser.</param>
        /// <param name="entityParser">The entity parser.</param>
        /// <param name="typeSplitter">The type splitter.</param>
        public WhereStatementParser(
            [NotNull] IWhereStatementParser rangeParser,
            [NotNull] IWhereStatementParser equalsParser,
            [NotNull] IEntityParser<TEntity> entityParser,
            [NotNull] ISplitter<TypeSplitterResponse> typeSplitter)
        {
            this.rangeParser = rangeParser;
            this.equalsParser = equalsParser;
            this.entityParser = entityParser;
            this.typeSplitter = typeSplitter;
        }

        /// <summary>
        /// Parses the statement.
        /// </summary>
        /// <param name="statement">The statement.</param>
        /// <param name="type">The type.</param>
        /// <returns>
        /// The <see cref="UnaryNode" />.
        /// </returns>
        public UnaryNode ParseStatement(string statement, string type = null)
        {
            var strings = statement.Split(':');

            // Validate the left hand property name against the white list
            var propertyName = strings[0].Trim();
            if (!this.entityParser.IsPermitted(propertyName))
            {
                return null;
            }

            // Cleanup the right hand value
            var operation = strings[1].Trim();

            // Check to see if the data type is explicitly specified
            var split = this.typeSplitter.SplitByToken(operation);

            var firstChar = operation.First();
            if (firstChar == '[' || firstChar == '{')
            {
                var rtn = this.rangeParser.ParseStatement(split.Data, split.Type);
                rtn.Name = propertyName;
                rtn.Statement = statement;
                return rtn;
            }

            var unaryNode = this.equalsParser.ParseStatement(split.Data, split.Type);
            unaryNode.Name = propertyName;
            unaryNode.Statement = statement;
            return unaryNode;
        }
    }
}