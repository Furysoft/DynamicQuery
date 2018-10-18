// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RangeParserTests.cs" company="Email Hippo Ltd">
//   © Email Hippo Ltd
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Tests.Logic.QueryParsers.WhereParsers
{
    using System.Diagnostics;
    using DynamicQuery.Logic.QueryParsers.WhereParsers;
    using Entities.QueryComponents.WhereNodes;
    using NUnit.Framework;

    /// <summary>
    /// The Range Parser Tests
    /// </summary>
    [TestFixture]
    public class RangeParserTests : TestBase
    {
        /// <summary>
        /// Parses the statement when inclusive range expect correct range node.
        /// </summary>
        [Test]
        public void ParseStatement_WhenInclusiveRange_ExpectCorrectRangeNode()
        {
            // Arrange
            var rangeParser = new RangeParser();

            // Act
            var stopwatch = Stopwatch.StartNew();
            var unaryNode = rangeParser.ParseStatement("{25,50}");
            stopwatch.Stop();

            // Assert
            this.WriteTimeElapsed(stopwatch);

            Assert.That(unaryNode, Is.Not.Null);

            Assert.That(unaryNode, Is.TypeOf(typeof(RangeNode)));

            var rangeNode = (RangeNode)unaryNode;

            Assert.That(rangeNode.Name, Is.Null);

            Assert.That(rangeNode.Lower, Is.EqualTo(25));
            Assert.That(rangeNode.Upper, Is.EqualTo(50));

            Assert.That(rangeNode.LowerInclusive, Is.True);
            Assert.That(rangeNode.UpperInclusive, Is.True);
        }

        /// <summary>
        /// Parses the statement when inclusive wildcard lower expect correct less than node.
        /// </summary>
        [Test]
        public void ParseStatement_WhenInclusiveWildcardLower_ExpectCorrectLessThanNode()
        {
            // Arrange
            var rangeParser = new RangeParser();

            // Act
            var stopwatch = Stopwatch.StartNew();
            var unaryNode = rangeParser.ParseStatement("[*,50}");
            stopwatch.Stop();

            // Assert
            this.WriteTimeElapsed(stopwatch);

            Assert.That(unaryNode, Is.Not.Null);

            Assert.That(unaryNode, Is.TypeOf(typeof(LessThanNode)));

            var rangeNode = (LessThanNode)unaryNode;

            Assert.That(rangeNode.Name, Is.Null);
            Assert.That(rangeNode.Value, Is.EqualTo(50));
            Assert.That(rangeNode.Inclusive, Is.True);
        }

        /// <summary>
        /// Parses the statement when inclusive wildcard upper expect correct greater than node.
        /// </summary>
        [Test]
        public void ParseStatement_WhenInclusiveWildcardUpper_ExpectCorrectGreaterThanNode()
        {
            // Arrange
            var rangeParser = new RangeParser();

            // Act
            var stopwatch = Stopwatch.StartNew();
            var unaryNode = rangeParser.ParseStatement("{10,*]");
            stopwatch.Stop();

            // Assert
            this.WriteTimeElapsed(stopwatch);

            Assert.That(unaryNode, Is.Not.Null);

            Assert.That(unaryNode, Is.TypeOf(typeof(GreaterThanNode)));

            var rangeNode = (GreaterThanNode)unaryNode;

            Assert.That(rangeNode.Name, Is.Null);
            Assert.That(rangeNode.Value, Is.EqualTo(10));
            Assert.That(rangeNode.Inclusive, Is.True);
        }

        /// <summary>
        /// Parses the statement when non inclusive range expect correct range node.
        /// </summary>
        [Test]
        public void ParseStatement_WhenNonInclusiveRange_ExpectCorrectRangeNode()
        {
            // Arrange
            var rangeParser = new RangeParser();

            // Act
            var stopwatch = Stopwatch.StartNew();
            var unaryNode = rangeParser.ParseStatement("[25,50]");
            stopwatch.Stop();

            // Assert
            this.WriteTimeElapsed(stopwatch);

            Assert.That(unaryNode, Is.Not.Null);

            Assert.That(unaryNode, Is.TypeOf(typeof(RangeNode)));

            var rangeNode = (RangeNode)unaryNode;

            Assert.That(rangeNode.Name, Is.Null);

            Assert.That(rangeNode.Lower, Is.EqualTo(25));
            Assert.That(rangeNode.Upper, Is.EqualTo(50));

            Assert.That(rangeNode.LowerInclusive, Is.False);
            Assert.That(rangeNode.UpperInclusive, Is.False);
        }

        /// <summary>
        /// Parses the statement when wildcard lower expect correct less than node.
        /// </summary>
        [Test]
        public void ParseStatement_WhenNonInclusiveWildcardLower_ExpectCorrectLessThanNode()
        {
            // Arrange
            var rangeParser = new RangeParser();

            // Act
            var stopwatch = Stopwatch.StartNew();
            var unaryNode = rangeParser.ParseStatement("[*,50]");
            stopwatch.Stop();

            // Assert
            this.WriteTimeElapsed(stopwatch);

            Assert.That(unaryNode, Is.Not.Null);

            Assert.That(unaryNode, Is.TypeOf(typeof(LessThanNode)));

            var rangeNode = (LessThanNode)unaryNode;

            Assert.That(rangeNode.Name, Is.Null);
            Assert.That(rangeNode.Value, Is.EqualTo(50));
            Assert.That(rangeNode.Inclusive, Is.False);
        }

        /// <summary>
        /// Parses the statement when non inclusive wildcard upper expect correct greater than node.
        /// </summary>
        [Test]
        public void ParseStatement_WhenNonInclusiveWildcardUpper_ExpectCorrectGreaterThanNode()
        {
            // Arrange
            var rangeParser = new RangeParser();

            // Act
            var stopwatch = Stopwatch.StartNew();
            var unaryNode = rangeParser.ParseStatement("[10,*]");
            stopwatch.Stop();

            // Assert
            this.WriteTimeElapsed(stopwatch);

            Assert.That(unaryNode, Is.Not.Null);

            Assert.That(unaryNode, Is.TypeOf(typeof(GreaterThanNode)));

            var rangeNode = (GreaterThanNode)unaryNode;

            Assert.That(rangeNode.Name, Is.Null);
            Assert.That(rangeNode.Value, Is.EqualTo(10));
            Assert.That(rangeNode.Inclusive, Is.False);
        }
    }
}