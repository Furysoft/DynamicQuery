// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QueryParserTests.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Tests.Integration
{
    using System.Diagnostics;
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
        [Repeat(2)]
        public void Parse_WhenQueryPassedIn_ExpectParsedCorrectly()
        {
            // Arrange
            IDynamicQueryParser queryParser = new DynamicQueryParser();

            // Act
            var stopwatch = Stopwatch.StartNew();
            var query = queryParser.Parse<TestEntity>("where::Name:\"test name\" and age:[10,25]orderby::age asc page::1,10");
            stopwatch.Stop();

            // Assert
            this.WriteTimeElapsed(stopwatch);
        }
    }
}