// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WhereParserTests.cs" company="Email Hippo Ltd">
//   © Email Hippo Ltd
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Tests.Logic.QueryParsers
{
    using DeepEqual.Syntax;
    using Furysoft.DynamicQuery.Entities.Operations;
    using Furysoft.DynamicQuery.Entities.QueryComponents;
    using Furysoft.DynamicQuery.Interfaces.QueryParsers;
    using Furysoft.DynamicQuery.Logic.QueryParsers;
    using Moq;
    using NUnit.Framework;
    using System.Diagnostics;
    using Furysoft.DynamicQuery.Entities.Nodes;

    /// <summary>
    /// The Where Parser Tests.
    /// </summary>
    [TestFixture]
    public sealed class WhereParserTests : TestBase
    {
        /// <summary>
        /// Parses the where when empty where statement expect null.
        /// </summary>
        [Test]
        public void ParseWhere_WhenEmptyWhereStatement_ExpectNull()
        {
            // Arrange
            var mockWhereStatementParser = new Mock<IWhereStatementParser>();

            var whereParser = new WhereParser(mockWhereStatementParser.Object);

            // Act
            var stopwatch = Stopwatch.StartNew();
            var whereNode = whereParser.ParseWhere(string.Empty);
            stopwatch.Stop();

            // Assert
            this.WriteTimeElapsed(stopwatch);

            Assert.That(whereNode, Is.Null);
        }

        /// <summary>
        /// Parses the where when empty where statement expect null.
        /// </summary>
        [Test]
        public void ParseWhere_WhenNullWhereStatement_ExpectNull()
        {
            // Arrange
            var mockWhereStatementParser = new Mock<IWhereStatementParser>();

            var whereParser = new WhereParser(mockWhereStatementParser.Object);

            // Act
            var stopwatch = Stopwatch.StartNew();
            var whereNode = whereParser.ParseWhere(null);
            stopwatch.Stop();

            // Assert
            this.WriteTimeElapsed(stopwatch);

            Assert.That(whereNode, Is.Null);
        }

        /// <summary>
        /// Parses the where when empty where statement expect null.
        /// </summary>
        [Test]
        public void ParseWhere_WhenSingleWhereStatement_ExpectWhereNodeBack()
        {
            // Arrange
            var mockWhereStatementParser = new Mock<IWhereStatementParser>();

            mockWhereStatementParser
                .Setup(r => r.ParseStatement(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(new EqualsOperator { Statement = "name:test", Name = "name", CaseInsensitive = false, Value = "test", IsNot = false });

            var whereParser = new WhereParser(mockWhereStatementParser.Object);

            // Act
            var stopwatch = Stopwatch.StartNew();
            var whereNode = whereParser.ParseWhere("name:test");
            stopwatch.Stop();

            // Assert
            this.WriteTimeElapsed(stopwatch);

            var expected = new WhereNode
            {
                Statement = new WhereStatement { Value = new EqualsOperator { Statement = "name:test", Name = "name", CaseInsensitive = false, Value = "test", IsNot = false }, As = null, }
            };

            whereNode.ShouldDeepEqual(expected);
        }

        /// <summary>
        /// Parses the where when empty where statement expect null.
        /// </summary>
        [Test]
        public void ParseWhere_WhenAndStatement_ExpectWhereNodesBack()
        {
            // Arrange
            var mockWhereStatementParser = new Mock<IWhereStatementParser>();

            mockWhereStatementParser
                .SetupSequence(r => r.ParseStatement(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(new EqualsOperator { Statement = "name:test", Name = "name", CaseInsensitive = false, Value = "test", IsNot = false })
                .Returns(new EqualsOperator { Statement = "name2:test2", Name = "name2", CaseInsensitive = false, Value = "test2", IsNot = false });

            var whereParser = new WhereParser(mockWhereStatementParser.Object);

            // Act
            var stopwatch = Stopwatch.StartNew();
            var whereNode = whereParser.ParseWhere("name:test and name2:test2");
            stopwatch.Stop();

            // Assert
            this.WriteTimeElapsed(stopwatch);

            var expected1 = new WhereNode
            {
                Statement = new WhereStatement { Value = new EqualsOperator { Statement = "name2:test2", Name = "name2", CaseInsensitive = false, Value = "test2", IsNot = false }, As = null, }
            };

            var expected2 = new WhereNode
            {
                Statement = new WhereStatement { Value = new EqualsOperator { Statement = "name:test", Name = "name", CaseInsensitive = false, Value = "test", IsNot = false }, As = null, },
                Conjunctive = Conjunctives.And,
                Next = expected1,
            };

            whereNode.ShouldDeepEqual(expected2);
        }

        /// <summary>
        /// Parses the where when empty where statement expect null.
        /// </summary>
        [Test]
        public void ParseWhere_WhenAndStatementWithAs_ExpectWhereNodesBack()
        {
            // Arrange
            var mockWhereStatementParser = new Mock<IWhereStatementParser>();

            mockWhereStatementParser
                .SetupSequence(r => r.ParseStatement(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(new EqualsOperator { Statement = "name:test", Name = "name", CaseInsensitive = false, Value = "test", IsNot = false })
                .Returns(new EqualsOperator { Statement = "name2:test2", Name = "name2", CaseInsensitive = false, Value = "test2", IsNot = false });

            var whereParser = new WhereParser(mockWhereStatementParser.Object);

            // Act
            var stopwatch = Stopwatch.StartNew();
            var whereNode = whereParser.ParseWhere("name:test as string and name2:test2");
            stopwatch.Stop();

            // Assert
            this.WriteTimeElapsed(stopwatch);

            var expected1 = new WhereNode
            {
                Statement = new WhereStatement { Value = new EqualsOperator { Statement = "name2:test2", Name = "name2", CaseInsensitive = false, Value = "test2", IsNot = false }, As = null, }
            };

            var expected2 = new WhereNode
            {
                Statement = new WhereStatement { Value = new EqualsOperator { Statement = "name:test", Name = "name", CaseInsensitive = false, Value = "test", IsNot = false }, As = "string", },
                Conjunctive = Conjunctives.And,
                Next = expected1,
            };

            whereNode.ShouldDeepEqual(expected2);
        }

        /// <summary>
        /// Parses the where when empty where statement expect null.
        /// </summary>
        [Test]
        public void ParseWhere_WhenSingleWhereStatementWithAndIn_ExpectWhereNodeBack()
        {
            // Arrange
            var mockWhereStatementParser = new Mock<IWhereStatementParser>();

            mockWhereStatementParser
                .Setup(r => r.ParseStatement(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(new EqualsOperator { Statement = "name:testandvalue", Name = "name", CaseInsensitive = false, Value = "testandvalue", IsNot = false });

            var whereParser = new WhereParser(mockWhereStatementParser.Object);

            // Act
            var stopwatch = Stopwatch.StartNew();
            var whereNode = whereParser.ParseWhere("name:testandvalue");
            stopwatch.Stop();

            // Assert
            this.WriteTimeElapsed(stopwatch);

            var expected = new WhereNode
            {
                Statement = new WhereStatement { Value = new EqualsOperator { Statement = "name:testandvalue", Name = "name", CaseInsensitive = false, Value = "testandvalue", IsNot = false }, As = null, }
            };

            whereNode.ShouldDeepEqual(expected);
        }

        /// <summary>
        /// Parses the where when empty where statement expect null.
        /// </summary>
        [Test]
        public void ParseWhere_WhenSingleWhereStatementWithOrIn_ExpectWhereNodeBack()
        {
            // Arrange
            var mockWhereStatementParser = new Mock<IWhereStatementParser>();

            mockWhereStatementParser
                .Setup(r => r.ParseStatement(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(new EqualsOperator { Statement = "name:testorvalue", Name = "name", CaseInsensitive = false, Value = "testorvalue", IsNot = false });

            var whereParser = new WhereParser(mockWhereStatementParser.Object);

            // Act
            var stopwatch = Stopwatch.StartNew();
            var whereNode = whereParser.ParseWhere("name:testorvalue");
            stopwatch.Stop();

            // Assert
            this.WriteTimeElapsed(stopwatch);

            var expected = new WhereNode
            {
                Statement = new WhereStatement { Value = new EqualsOperator { Statement = "name:testorvalue", Name = "name", CaseInsensitive = false, Value = "testorvalue", IsNot = false }, As = null, }
            };

            whereNode.ShouldDeepEqual(expected);
        }

        /// <summary>
        /// Parses the where when empty where statement expect null.
        /// </summary>
        [Test]
        public void ParseWhere_WhenSingleWhereStatementWithQuotes_ExpectWhereNodeBack()
        {
            // Arrange
            var mockWhereStatementParser = new Mock<IWhereStatementParser>();

            mockWhereStatementParser
                .Setup(r => r.ParseStatement(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(new EqualsOperator { Statement = "name:\"Test and value\"", Name = "name", CaseInsensitive = false, Value = "Test and value", IsNot = false });

            var whereParser = new WhereParser(mockWhereStatementParser.Object);

            // Act
            var stopwatch = Stopwatch.StartNew();
            var whereNode = whereParser.ParseWhere("name:\"Test and value\"");
            stopwatch.Stop();

            // Assert
            this.WriteTimeElapsed(stopwatch);

            var expected = new WhereNode
            {
                Statement = new WhereStatement { Value = new EqualsOperator { Statement = "name:\"Test and value\"", Name = "name", CaseInsensitive = false, Value = "Test and value", IsNot = false }, As = null, }
            };

            whereNode.ShouldDeepEqual(expected);
        }

        /// <summary>
        /// Parses the where when empty where statement expect null.
        /// </summary>
        [Test]
        public void ParseWhere_WhenSingleWhereStatementWithType_ExpectWhereNodeBack()
        {
            // Arrange
            var mockWhereStatementParser = new Mock<IWhereStatementParser>();

            mockWhereStatementParser
                .Setup(r => r.ParseStatement(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(new EqualsOperator { Statement = "name:test", Name = "name", CaseInsensitive = false, Value = "test", IsNot = false });

            var whereParser = new WhereParser(mockWhereStatementParser.Object);

            // Act
            var stopwatch = Stopwatch.StartNew();
            var whereNode = whereParser.ParseWhere("name:test as string");
            stopwatch.Stop();

            // Assert
            this.WriteTimeElapsed(stopwatch);

            var expected = new WhereNode
            {
                Statement = new WhereStatement { Value = new EqualsOperator { Statement = "name:test", Name = "name", CaseInsensitive = false, Value = "test", IsNot = false }, As = "string", }
            };

            whereNode.ShouldDeepEqual(expected);
        }
    }
}