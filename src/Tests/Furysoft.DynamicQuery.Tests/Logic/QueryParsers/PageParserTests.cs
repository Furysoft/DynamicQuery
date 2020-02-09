// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PageParserTests.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Tests.Logic.QueryParsers
{
    using System.Diagnostics;
    using DynamicQuery.Logic.QueryParsers;
    using NUnit.Framework;

    /// <summary>
    /// The Page Parser
    /// </summary>
    [TestFixture]
    public sealed class PageParserTests : TestBase
    {
        /// <summary>
        /// Parses the when valid structure expect correct data.
        /// </summary>
        [Test]
        public void Parse_WhenValidStructure_ExpectCorrectData()
        {
            // Arrange
            var pageParser = new PageParser();

            // Act
            var stopwatch = Stopwatch.StartNew();
            var pageNode = pageParser.Parse("1,25");
            stopwatch.Stop();

            // Assert
            this.WriteTimeElapsed(stopwatch);

            Assert.That(pageNode?.Page, Is.EqualTo(1));
            Assert.That(pageNode?.ItemsPerPage, Is.EqualTo(25));
        }
    }
}