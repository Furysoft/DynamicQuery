// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OrderByParserTests.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Tests.Logic.QueryParsers
{
    using System.Diagnostics;
    using DynamicQuery.Logic.QueryParsers;
    using Entities;
    using Interfaces;
    using Moq;
    using NUnit.Framework;

    /// <summary>
    /// The Order By Parser
    /// </summary>
    [TestFixture]
    public sealed class OrderByParserTests : TestBase
    {
        /// <summary>
        /// Parses the order by when column not permitted expect skip.
        /// </summary>
        [Test]
        public void ParseOrderBy_WhenColumnNotPermitted_ExpectSkip()
        {
            // Arrange
            var mockEntityParser = new Mock<IEntityParser<string>>();

            mockEntityParser.Setup(r => r.IsPermitted(It.IsAny<string>())).Returns(false);

            var orderByParser = new OrderByParser<string>(mockEntityParser.Object);

            // Act
            var stopwatch = Stopwatch.StartNew();
            var orderByNodes = orderByParser.ParseOrderBy(" name asc ");
            stopwatch.Stop();

            // Assert
            this.WriteTimeElapsed(stopwatch);

            Assert.That(orderByNodes, Is.Not.Null);
            Assert.That(orderByNodes.Count, Is.EqualTo(0));
        }

        /// <summary>
        /// Parses the actual name of the order by when escaped name expect.
        /// </summary>
        [Test]
        public void ParseOrderBy_WhenEscapedName_ExpectActualName()
        {
            // Arrange
            var mockEntityParser = new Mock<IEntityParser<string>>();

            mockEntityParser.Setup(r => r.IsPermitted(It.IsAny<string>())).Returns(true);

            var orderByParser = new OrderByParser<string>(mockEntityParser.Object);

            // Act
            var stopwatch = Stopwatch.StartNew();
            var orderByNodes = orderByParser.ParseOrderBy("\"Test Value\" asc");
            stopwatch.Stop();

            // Assert
            this.WriteTimeElapsed(stopwatch);

            Assert.That(orderByNodes, Is.Not.Null);
            Assert.That(orderByNodes.Count, Is.EqualTo(1));

            Assert.That(orderByNodes[0].Name, Is.EqualTo("Test Value"));
            Assert.That(orderByNodes[0].SortOrder, Is.EqualTo(SortOrder.Asc));
        }

        /// <summary>
        /// Parses the order by when multiple query expect all parts parsed.
        /// </summary>
        [Test]
        public void ParseOrderBy_WhenMultipleQuery_ExpectAllPartsParsed()
        {
            // Arrange
            var mockEntityParser = new Mock<IEntityParser<string>>();

            mockEntityParser.Setup(r => r.IsPermitted(It.IsAny<string>())).Returns(true);

            var orderByParser = new OrderByParser<string>(mockEntityParser.Object);

            // Act
            var stopwatch = Stopwatch.StartNew();
            var orderByNodes = orderByParser.ParseOrderBy(" name asc value desc ");
            stopwatch.Stop();

            // Assert
            this.WriteTimeElapsed(stopwatch);

            Assert.That(orderByNodes, Is.Not.Null);
            Assert.That(orderByNodes.Count, Is.EqualTo(2));

            Assert.That(orderByNodes[0].Name, Is.EqualTo("name"));
            Assert.That(orderByNodes[0].SortOrder, Is.EqualTo(SortOrder.Asc));

            Assert.That(orderByNodes[1].Name, Is.EqualTo("value"));
            Assert.That(orderByNodes[1].SortOrder, Is.EqualTo(SortOrder.Desc));
        }

        /// <summary>
        /// Parses the order by when single query expect correct node.
        /// </summary>
        [Test]
        public void ParseOrderBy_WhenSingleQueryAsc_ExpectCorrectNode()
        {
            // Arrange
            var mockEntityParser = new Mock<IEntityParser<string>>();

            mockEntityParser.Setup(r => r.IsPermitted(It.IsAny<string>())).Returns(true);

            var orderByParser = new OrderByParser<string>(mockEntityParser.Object);

            // Act
            var stopwatch = Stopwatch.StartNew();
            var orderByNodes = orderByParser.ParseOrderBy("name asc");
            stopwatch.Stop();

            // Assert
            this.WriteTimeElapsed(stopwatch);

            Assert.That(orderByNodes, Is.Not.Null);
            Assert.That(orderByNodes.Count, Is.EqualTo(1));

            Assert.That(orderByNodes[0].Name, Is.EqualTo("name"));
            Assert.That(orderByNodes[0].SortOrder, Is.EqualTo(SortOrder.Asc));
        }

        /// <summary>
        /// Parses the order by when single query desc expect correct node.
        /// </summary>
        [Test]
        public void ParseOrderBy_WhenSingleQueryDesc_ExpectCorrectNode()
        {
            // Arrange
            var mockEntityParser = new Mock<IEntityParser<string>>();

            mockEntityParser.Setup(r => r.IsPermitted(It.IsAny<string>())).Returns(true);

            var orderByParser = new OrderByParser<string>(mockEntityParser.Object);

            // Act
            var stopwatch = Stopwatch.StartNew();
            var orderByNodes = orderByParser.ParseOrderBy("name desc");
            stopwatch.Stop();

            // Assert
            this.WriteTimeElapsed(stopwatch);

            Assert.That(orderByNodes, Is.Not.Null);
            Assert.That(orderByNodes.Count, Is.EqualTo(1));

            Assert.That(orderByNodes[0].Name, Is.EqualTo("name"));
            Assert.That(orderByNodes[0].SortOrder, Is.EqualTo(SortOrder.Desc));
        }
    }
}