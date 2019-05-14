// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WhereParserTests.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Tests.Integration.QueryParsers
{
    using System.Diagnostics;
    using Attributes;
    using DynamicQuery.Logic.QueryParsers;
    using DynamicQuery.Logic.QueryParsers.WhereParsers;
    using Entities.Nodes;
    using Entities.Operations;
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
            var whereStatementParser = new WhereStatementParser<CustomEntity>(rangeParser, equalsParser, entityParser);
            var whereParser = new WhereParser(whereStatementParser);

            // Act
            var stopwatch = Stopwatch.StartNew();
            var whereNode = whereParser.ParseWhere("testKey:testValue");
            stopwatch.Stop();

            // Assert
            this.WriteTimeElapsed(stopwatch);

            var equalsOperator = whereNode as EqualsOperator;

            Assert.That(equalsOperator, Is.Not.Null);

            Assert.That(equalsOperator.Statement, Is.EqualTo("testKey:testValue"));
            Assert.That(equalsOperator.Name, Is.EqualTo("testKey"));
            Assert.That(equalsOperator.Value, Is.EqualTo("testValue"));
            Assert.That(equalsOperator.IsNot, Is.False);
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
            var whereStatementParser = new WhereStatementParser<CustomEntity>(rangeParser, equalsParser, entityParser);
            var whereParser = new WhereParser(whereStatementParser);

            // Act
            var stopwatch = Stopwatch.StartNew();
            var whereNode = whereParser.ParseWhere("testKey:testValue and testKey2:[23,2]");
            stopwatch.Stop();

            // Assert
            this.WriteTimeElapsed(stopwatch);

            var equalsOperator = whereNode as BinaryNode;

            Assert.That(equalsOperator, Is.Not.Null);

            Assert.That(equalsOperator.Statement, Is.EqualTo("testKey:testValue and testKey2:[23,2]"));
            Assert.That(equalsOperator.LeftNode, Is.Not.Null);
            Assert.That(equalsOperator.RightNode, Is.Not.Null);

            /* Left Node */
            var leftNode = equalsOperator.LeftNode as EqualsOperator;
            Assert.That(leftNode, Is.Not.Null);

            Assert.That(leftNode.Value, Is.EqualTo("testValue"));
            Assert.That(leftNode.Name, Is.EqualTo("testKey"));
            Assert.That(leftNode.IsNot, Is.False);

            /* Right Node */
            var rightNode = equalsOperator.RightNode as RangeOperator;
            Assert.That(rightNode, Is.Not.Null);

            Assert.That(rightNode.Lower, Is.EqualTo(23));
            Assert.That(rightNode.Upper, Is.EqualTo(2));
        }

        /// <summary>
        /// The Custom Entity
        /// </summary>
        // ReSharper disable once ClassNeverInstantiated.Local
        private sealed class CustomEntity
        {
            /// <summary>Gets or sets the test key.</summary>
            [Name("testKey")]
            public string TestKey { get; set; }

            /// <summary>Gets or sets the test key2.</summary>
            [Name("testKey2")]
            public string TestKey2 { get; set; }
        }
    }
}