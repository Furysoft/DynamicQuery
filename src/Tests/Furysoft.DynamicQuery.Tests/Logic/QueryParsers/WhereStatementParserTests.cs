// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WhereStatementParserTests.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Tests.Logic.QueryParsers
{
    using System.Diagnostics;
    using DynamicQuery.Logic.QueryParsers;
    using Entities.QueryComponents.WhereNodes;
    using Interfaces.QueryParsers;
    using Moq;
    using NUnit.Framework;

    /// <summary>
    /// The Where Statement Parser
    /// </summary>
    [TestFixture]
    public sealed class WhereStatementParserTests : TestBase
    {
        /// <summary>
        /// Parses the statement whe equals statement expect equals parser.
        /// </summary>
        [Test]
        public void ParseStatement_WheEqualsStatement_ExpectEqualsParser()
        {
            // Arrange
            var mockRangeParser = new Mock<IWhereStatementParser>();
            var mockEqualsParser = new Mock<IWhereStatementParser>();

            mockRangeParser.Setup(r => r.ParseStatement(It.IsAny<string>())).Returns(new EqualsNode
            {
                Name = null,
                IsNot = false,
                Value = "test"
            });

            var whereStatementParser = new WhereStatementParser(mockRangeParser.Object, mockEqualsParser.Object);

            // Act
            var stopwatch = Stopwatch.StartNew();
            var unaryNode = whereStatementParser.ParseStatement("column:\"bobs burgers\"");
            stopwatch.Stop();

            // Assert
            this.WriteTimeElapsed(stopwatch);

            Assert.That(unaryNode, Is.Not.Null);

            var equalsNode = unaryNode as EqualsNode;

            Assert.That(equalsNode, Is.Not.Null);

            Assert.That(equalsNode.Name, Is.EqualTo("column"));
            Assert.That(equalsNode.Value, Is.EqualTo("test"));
            Assert.That(equalsNode.IsNot, Is.False);
        }

        /// <summary>
        /// Parses the statement whe explicit range expect range node.
        /// </summary>
        [Test]
        public void ParseStatement_WheExplicitRange_ExpectRangeNode()
        {
            // Arrange
            var mockRangeParser = new Mock<IWhereStatementParser>();
            var mockEqualsParser = new Mock<IWhereStatementParser>();

            mockRangeParser.Setup(r => r.ParseStatement(It.IsAny<string>())).Returns(new RangeNode
            {
                Name = null,
                LowerInclusive = false,
                UpperInclusive = false,
                Upper = 250,
                Lower = 10
            });

            var whereStatementParser = new WhereStatementParser(mockRangeParser.Object, mockEqualsParser.Object);

            // Act
            var stopwatch = Stopwatch.StartNew();
            var unaryNode = whereStatementParser.ParseStatement("column:[10,250]");
            stopwatch.Stop();

            // Assert
            this.WriteTimeElapsed(stopwatch);

            Assert.That(unaryNode, Is.Not.Null);

            var rangeNode = unaryNode as RangeNode;

            Assert.That(rangeNode, Is.Not.Null);

            Assert.That(rangeNode.Name, Is.EqualTo("column"));
            Assert.That(rangeNode.Lower, Is.EqualTo(10));
            Assert.That(rangeNode.LowerInclusive, Is.False);

            Assert.That(rangeNode.Upper, Is.EqualTo(250));
            Assert.That(rangeNode.UpperInclusive, Is.False);
        }
    }
}