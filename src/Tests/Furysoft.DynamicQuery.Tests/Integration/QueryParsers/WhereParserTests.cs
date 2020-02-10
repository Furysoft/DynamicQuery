// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WhereParserTests.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Tests.Integration.QueryParsers
{
    using System.Diagnostics;
    using Attributes;
    using DeepEqual.Syntax;
    using DynamicQuery.Logic.QueryParsers;
    using DynamicQuery.Logic.QueryParsers.WhereParsers;
    using DynamicQuery.Logic.Splitters;
    using Entities.Nodes;
    using Entities.Operations;
    using Furysoft.DynamicQuery.Entities;
    using Furysoft.DynamicQuery.Entities.QueryComponents;
    using JetBrains.Annotations;
    using NUnit.Framework;
    using Parsers;

    /// <summary>
    /// The Where Parser Tests
    /// </summary>
    [TestFixture]
    public sealed class WhereParserTests : TestBase
    {
        /// <summary>
        /// Parses the where when simple query expect node back.
        /// </summary>
        [Test]
        public void ParseWhere_WhenSimpleQuery_ExpectNodeBack()
        {
            // Arrange
            var rangeParser = new RangeParser();
            var equalsParser = new EqualsParser();
            var entityParser = new EntityParser<CustomEntity>();
            var typeSplitter = new TypeSplitter();
            var whereStatementParser = new WhereStatementParser<CustomEntity>(rangeParser, equalsParser, entityParser, typeSplitter);
            var whereParser = new WhereParser(whereStatementParser, new ParserOptions());

            // Act
            var stopwatch = Stopwatch.StartNew();
            var whereNode = whereParser.ParseWhere("testKey:testValue");
            stopwatch.Stop();

            // Assert
            this.WriteTimeElapsed(stopwatch);

            var equalsOperator = whereNode;

            Assert.That(equalsOperator, Is.Not.Null);

            var expected = new WhereNode
            {
                Conjunctive = Conjunctives.None,
                Next = null,
                Statement = new WhereStatement { As = null, Value = new EqualsOperator { Statement = "testKey:testValue", Name = "testKey", CaseInsensitive = false, Value = "testValue", IsNot = false } }
            };

            whereNode.ShouldDeepEqual(expected);
        }

        /// <summary>
        /// Parses the where when two parts expect binary node.
        /// </summary>
        [Test]
        public void ParseWhere_WhenTwoParts_ExpectBinaryNode()
        {
            // Arrange
            var rangeParser = new RangeParser();
            var equalsParser = new EqualsParser();
            var entityParser = new EntityParser<CustomEntity>();
            var typeSplitter = new TypeSplitter();
            var whereStatementParser = new WhereStatementParser<CustomEntity>(rangeParser, equalsParser, entityParser, typeSplitter);
            var whereParser = new WhereParser(whereStatementParser, new ParserOptions());

            // Act
            var stopwatch = Stopwatch.StartNew();
            var whereNode = whereParser.ParseWhere("testKey:testValue and testKey2:[23,2]");
            stopwatch.Stop();

            // Assert
            this.WriteTimeElapsed(stopwatch);

            var next1 = new WhereNode
            {
                Conjunctive = Conjunctives.None,
                Next = null,
                Statement = new WhereStatement { As = null, Value = new RangeOperator { Statement = "testKey2:[23,2]", Name = "testKey2", Lower = 23, LowerInclusive = false, Upper = 2, UpperInclusive = false } }
            };

            var expected = new WhereNode
            {
                Conjunctive = Conjunctives.And,
                Next = next1,
                Statement = new WhereStatement { As = null, Value = new EqualsOperator { Statement = "testKey:testValue", Name = "testKey", CaseInsensitive = false, Value = "testValue", IsNot = false } }
            };

            whereNode.ShouldDeepEqual(expected);
        }

        /// <summary>
        /// The Custom Entity
        /// </summary>
        // ReSharper disable once ClassNeverInstantiated.Local
        private sealed class CustomEntity
        {
            /// <summary>Gets or sets the test key.</summary>
            [Name("testKey")]
            [UsedImplicitly]
            public string TestKey { get; set; }

            /// <summary>Gets or sets the test key2.</summary>
            [Name("testKey2")]
            [UsedImplicitly]
            public string TestKey2 { get; set; }
        }
    }
}