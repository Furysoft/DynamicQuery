// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EqualsParserTests.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Tests.Logic.QueryParsers.WhereParsers
{
    using System;
    using System.Diagnostics;
    using DynamicQuery.Logic.QueryParsers.WhereParsers;
    using Entities.Operations;
    using NUnit.Framework;

    /// <summary>
    /// The Equals Parser Tests
    /// </summary>
    [TestFixture]
    public sealed class EqualsParserTests : TestBase
    {
        /// <summary>
        /// Parses the statement when escaped string in expect equals node.
        /// </summary>
        [Test]
        public void ParseStatement_WhenEscapedStringIn_ExpectEqualsNode()
        {
            // Arrange
            var equalsParser = new EqualsParser();

            // Act
            var stopwatch = Stopwatch.StartNew();
            var unaryNode = equalsParser.ParseStatement("\"TestString\"");
            stopwatch.Stop();

            // Assert
            this.WriteTimeElapsed(stopwatch);

            Assert.That(unaryNode, Is.Not.Null);
            Assert.That(unaryNode, Is.TypeOf<EqualsOperator>());

            var equalsNode = (EqualsOperator)unaryNode;

            Assert.That(equalsNode.Name, Is.Null);
            Assert.That(equalsNode.Value, Is.EqualTo("TestString"));
            Assert.That(equalsNode.IsNot, Is.False);
        }

        /// <summary>
        /// Parses the statement when string in expect equals node.
        /// </summary>
        [Test]
        public void ParseStatement_WhenStringIn_ExpectEqualsNode()
        {
            // Arrange
            var equalsParser = new EqualsParser();

            // Act
            var stopwatch = Stopwatch.StartNew();
            var unaryNode = equalsParser.ParseStatement("TestString");
            stopwatch.Stop();

            // Assert
            this.WriteTimeElapsed(stopwatch);

            Assert.That(unaryNode, Is.Not.Null);
            Assert.That(unaryNode, Is.TypeOf<EqualsOperator>());

            var equalsNode = (EqualsOperator)unaryNode;

            Assert.That(equalsNode.Name, Is.Null);
            Assert.That(equalsNode.Value, Is.EqualTo("TestString"));
            Assert.That(equalsNode.IsNot, Is.False);
        }

        /// <summary>
        /// Parses the statement when string in with not expect equals node.
        /// </summary>
        [Test]
        public void ParseStatement_WhenStringInWithNot_ExpectEqualsNode()
        {
            // Arrange
            var equalsParser = new EqualsParser();

            // Act
            var stopwatch = Stopwatch.StartNew();
            var unaryNode = equalsParser.ParseStatement("!TestString");
            stopwatch.Stop();

            // Assert
            this.WriteTimeElapsed(stopwatch);

            Assert.That(unaryNode, Is.Not.Null);
            Assert.That(unaryNode, Is.TypeOf<EqualsOperator>());

            var equalsNode = (EqualsOperator)unaryNode;

            Assert.That(equalsNode.Name, Is.Null);
            Assert.That(equalsNode.Value, Is.EqualTo("TestString"));
            Assert.That(equalsNode.IsNot, Is.True);
        }

        /// <summary>
        /// Parses the statement when number expect query is number.
        /// </summary>
        [Test]
        public void ParseStatement_WhenNumber_ExpectQueryIsNumber()
        {
            // Arrange
            var equalsParser = new EqualsParser();

            // Act
            var stopwatch = Stopwatch.StartNew();
            var unaryNode = equalsParser.ParseStatement("56");
            stopwatch.Stop();

            // Assert
            this.WriteTimeElapsed(stopwatch);

            Assert.That(unaryNode, Is.Not.Null);
            Assert.That(unaryNode, Is.TypeOf<EqualsOperator>());

            var equalsNode = (EqualsOperator)unaryNode;

            Assert.That(equalsNode.Name, Is.Null);
            Assert.That(equalsNode.Value, Is.EqualTo(56));
            Assert.That(equalsNode.IsNot, Is.False);
        }

        /// <summary>
        /// Parses the statement when date time expect query is date time.
        /// </summary>
        [Test]
        public void ParseStatement_WhenDateTime_ExpectQueryIsDateTime()
        {
            // Arrange
            var equalsParser = new EqualsParser();

            // Act
            var stopwatch = Stopwatch.StartNew();
            var unaryNode = equalsParser.ParseStatement("2018-1-1");
            stopwatch.Stop();

            // Assert
            this.WriteTimeElapsed(stopwatch);

            Assert.That(unaryNode, Is.Not.Null);
            Assert.That(unaryNode, Is.TypeOf<EqualsOperator>());

            var equalsNode = (EqualsOperator)unaryNode;

            Assert.That(equalsNode.Name, Is.Null);
            Assert.That(equalsNode.Value, Is.EqualTo(new DateTime(2018, 1, 1)));
            Assert.That(equalsNode.IsNot, Is.False);
        }
    }
}