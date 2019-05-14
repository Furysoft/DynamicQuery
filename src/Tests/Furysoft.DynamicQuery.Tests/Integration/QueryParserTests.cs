// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QueryParserTests.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Tests.Integration
{
    using System.Diagnostics;
    using DynamicQuery.Logic.OperatorFactories;
    using Entities.Nodes;
    using Entities.Operations;
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
        public void Parse_WhenQueryPassedIn_ExpectParsedCorrectly()
        {
            // Arrange
            IDynamicQueryParser queryParser = new DynamicQueryParser();

            // Act
            var stopwatch = Stopwatch.StartNew();
            var query = queryParser.Parse<TestEntity>("where::Name:\"test name\" and age:asd orderby::age asc page::1,10");
            stopwatch.Stop();

      //      query.WhereNode = Operator.And(Operator.Equals("asd", 12), Operator.Equals("asd2", 23));

         //   query.Where(EqualsNode.CreateEquals("test", "bob"));
           // query.Where("val:bob");

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

            var whereNode = query.WhereNode as BinaryNode;
            Assert.That(whereNode, Is.Not.Null);

            var leftNode = whereNode.LeftNode as EqualsOperator;
            var rightNode = whereNode.RightNode as RangeOperator;

            Assert.That(leftNode, Is.Not.Null);
            Assert.That(rightNode, Is.Not.Null);

            Assert.That(leftNode.Name, Is.EqualTo("Name"));
            Assert.That(leftNode.Value, Is.EqualTo("test name"));

            Assert.That(rightNode.Name, Is.EqualTo("age"));
            Assert.That(rightNode.Lower, Is.EqualTo(10));
            Assert.That(rightNode.LowerInclusive, Is.EqualTo(false));
            Assert.That(rightNode.Upper, Is.EqualTo(25));
            Assert.That(rightNode.UpperInclusive, Is.EqualTo(false));
        }
    }
}