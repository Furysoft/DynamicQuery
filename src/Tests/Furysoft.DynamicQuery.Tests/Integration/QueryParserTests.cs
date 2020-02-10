// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QueryParserTests.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Tests.Integration
{
    using System.Diagnostics;
    using DynamicQuery.Logic.OperatorFactories;
    using Furysoft.DynamicQuery.Entities.QueryComponents;
    using Interfaces;
    using NUnit.Framework;
    using TestHelpers;

    /// <summary>
    /// The Query Parser Tests
    /// </summary>
    [TestFixture]
    public sealed class QueryParserTests : TestBase
    {
        /// <summary>
        /// Parses the when query passed in expect parsed correctly.
        /// </summary>
        [Test]
        public void Parse_WhenEmptyString_ExpectNullQuery()
        {
            // Arrange
            IDynamicQueryParser queryParser = new DynamicQueryParser();

            // Act
            var stopwatch = Stopwatch.StartNew();
            var query = queryParser.Parse<TestEntity>(string.Empty);
            stopwatch.Stop();

            // Assert
            this.WriteTimeElapsed(stopwatch);

            Assert.That(query.WhereNode, Is.Null);
            Assert.That(query.OrderByNodes, Is.Null);
            Assert.That(query.PageNode, Is.Null);
        }

        /// <summary>
        /// Parses the when query passed in expect parsed correctly.
        /// </summary>
        [Test]
        public void Parse_WhenNoOrderBy_ExpectNoOrderByOnQueryQuery()
        {
            // Arrange
            IDynamicQueryParser queryParser = new DynamicQueryParser();

            // Act
            var stopwatch = Stopwatch.StartNew();
            var query = queryParser.Parse<TestEntity>("where::age:test page::1,10");
            stopwatch.Stop();

            // Assert
            this.WriteTimeElapsed(stopwatch);

            Assert.That(query.WhereNode, Is.Not.Null);
            Assert.That(query.OrderByNodes, Is.Null);
            Assert.That(query.PageNode, Is.Not.Null);
        }

        /// <summary>
        /// Parses the when query passed in expect parsed correctly.
        /// </summary>
        [Test]
        public void Parse_WhenNoWhere_ExpectNoWhereOnQueryQuery()
        {
            // Arrange
            IDynamicQueryParser queryParser = new DynamicQueryParser();

            // Act
            var stopwatch = Stopwatch.StartNew();
            var query = queryParser.Parse<TestEntity>("orderby::age asc page::1,10");
            stopwatch.Stop();

            // Assert
            this.WriteTimeElapsed(stopwatch);

            Assert.That(query.WhereNode, Is.Null);
            Assert.That(query.OrderByNodes, Is.Not.Null);
            Assert.That(query.PageNode, Is.Not.Null);
        }

        /// <summary>
        /// Parses the when query passed in expect parsed correctly.
        /// </summary>
        [Test]
        public void Parse_WhenQueryPassedIn_ExpectParsedCorrectly()
        {
            // Arrange
            IDynamicQueryParser queryParser = new DynamicQueryParser();

            // Act
            var stopwatch = Stopwatch.StartNew();
            var query = queryParser.Parse<TestEntity>("where::Name:\"test name\" and age:asdorderby::age asc page::1,10");
            stopwatch.Stop();

            query.Where(new WhereNode { Statement = new WhereStatement { Value = EqualsNode.CreateEquals("test", "bob") } });
            query.Where("val:bob");

            // Assert
            this.WriteTimeElapsed(stopwatch);
        }

        /// <summary>
        /// Parses the when query passed in expect parsed correctly.
        /// </summary>
        [Test]
        public void Parse_WhenQueryPassedInWithAndAndOrs_ExpectParsedCorrectly()
        {
            // Arrange
            IDynamicQueryParser queryParser = new DynamicQueryParser();

            // Act
            var stopwatch = Stopwatch.StartNew();
            var query = queryParser.Parse<TestEntity>("where::Name:\"test or name\" and age:aandsd as string orderby::age asc page::1,10");
            stopwatch.Stop();

            query.Where(new WhereNode { Statement = new WhereStatement { Value = EqualsNode.CreateEquals("test", "bob") } });
            query.Where("val:bob");

            // Assert
            this.WriteTimeElapsed(stopwatch);
        }

        /// <summary>
        /// Parses the when query with date passed in expect parsed correctly.
        /// </summary>
        [Test]
        public void Parse_WhenQueryWithDatePassedIn_ExpectParsedCorrectly()
        {
            // Arrange
            IDynamicQueryParser queryParser = new DynamicQueryParser();

            // Act
            var stopwatch = Stopwatch.StartNew();
            var query = queryParser.Parse<TestEntity>("where::Name:[2018-01-01,*] as datetime orderby::age asc page::1,10");
            stopwatch.Stop();

            // Assert
            this.WriteTimeElapsed(stopwatch);
        }

        /// <summary>
        /// Parses the when where part of query expect parsed correctly.
        /// </summary>
        [Test]
        public void Parse_WhenWherePartOfQuery_ExpectParsedCorrectly()
        {
            // Arrange
            IDynamicQueryParser queryParser = new DynamicQueryParser();

            // Act
            var stopwatch = Stopwatch.StartNew();
            var query = queryParser.Parse<TestEntity>("where::Name:\"test name\" and age:[10,25]");
            stopwatch.Stop();

            // Assert
            this.WriteTimeElapsed(stopwatch);

            Assert.That(query.OrderByNodes, Is.Null);
            Assert.That(query.PageNode, Is.Null);
        }
    }
}