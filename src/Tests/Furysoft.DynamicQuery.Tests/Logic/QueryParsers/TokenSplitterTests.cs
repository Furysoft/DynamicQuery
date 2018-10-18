// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TokenSplitterTests.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Tests.Logic.QueryParsers
{
    using System.Diagnostics;
    using DynamicQuery.Logic.QueryParsers;
    using DynamicQuery.Logic.Splitters;
    using NUnit.Framework;

    /// <summary>
    /// The Token Splitter Tests
    /// </summary>
    [TestFixture]
    public sealed class TokenSplitterTests : TestBase
    {
        /// <summary>
        /// Splits the by token when complex query expect all parts split.
        /// </summary>
        [Test]
        public void SplitByToken_WhenComplexQuery_ExpectAllPartsSplit()
        {
            // Arrange
            var tokenSplitter = new TokenSplitter();

            // Act
            var stopwatch = Stopwatch.StartNew();
            var splitByToken = tokenSplitter.SplitByToken("where::where:\"where value\" AND value:\"Other\" orderby::\"Name\" asc page::1,25");
            stopwatch.Stop();

            // Assert
            this.WriteTimeElapsed(stopwatch);

            Assert.That(splitByToken, Is.Not.Null);

            Assert.That(splitByToken.Where, Is.EqualTo("where:\"where value\" AND value:\"Other\""));
            Assert.That(splitByToken.OrderBy, Is.EqualTo("\"Name\" asc"));
            Assert.That(splitByToken.Page, Is.EqualTo("1,25"));
        }

        /// <summary>
        /// Splits the by token when order by clause expect query part.
        /// </summary>
        [Test]
        public void SplitByToken_WhenOrderByClause_ExpectQueryPart()
        {
            // Arrange
            var tokenSplitter = new TokenSplitter();

            // Act
            var stopwatch = Stopwatch.StartNew();
            var splitByToken = tokenSplitter.SplitByToken("orderby::\"User Name\" asc");
            stopwatch.Stop();

            // Assert
            this.WriteTimeElapsed(stopwatch);

            Assert.That(splitByToken, Is.Not.Null);

            Assert.That(splitByToken.OrderBy, Is.EqualTo("\"User Name\" asc"));
        }

        /// <summary>
        /// Splits the by token when page clause expect query part.
        /// </summary>
        [Test]
        public void SplitByToken_WhenPageClause_ExpectQueryPart()
        {
            // Arrange
            var tokenSplitter = new TokenSplitter();

            // Act
            var stopwatch = Stopwatch.StartNew();
            var splitByToken = tokenSplitter.SplitByToken("page::1,10");
            stopwatch.Stop();

            // Assert
            this.WriteTimeElapsed(stopwatch);

            Assert.That(splitByToken, Is.Not.Null);

            Assert.That(splitByToken.Page, Is.EqualTo("1,10"));
        }

        /// <summary>
        /// Splits the by token when string passed in expect token parts.
        /// </summary>
        [Test]
        public void SplitByToken_WhenWhereClause_ExpectQueryPart()
        {
            // Arrange
            var tokenSplitter = new TokenSplitter();

            // Act
            var stopwatch = Stopwatch.StartNew();
            var splitByToken = tokenSplitter.SplitByToken("where::name:\"test\" AND value:2 OR where:\"something\"");
            stopwatch.Stop();

            // Assert
            this.WriteTimeElapsed(stopwatch);

            Assert.That(splitByToken, Is.Not.Null);

            Assert.That(splitByToken.Where, Is.EqualTo("name:\"test\" AND value:2 OR where:\"something\""));
        }
    }
}