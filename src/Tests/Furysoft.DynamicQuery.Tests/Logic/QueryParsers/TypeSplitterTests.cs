// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TypeSplitterTests.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Tests.Logic.QueryParsers
{
    using System.Diagnostics;
    using DynamicQuery.Logic.Splitters;
    using Exceptions;
    using NUnit.Framework;

    /// <summary>
    /// The Type Splitter Tests
    /// </summary>
    [TestFixture]
    public sealed class TypeSplitterTests : TestBase
    {
        /// <summary>
        /// Splits the by token when as in quoted value expect just data.
        /// </summary>
        [Test]
        public void SplitByToken_WhenAsInQuotedValue_ExpectJustData()
        {
            // Arrange
            var splitter = new TypeSplitter();

            // Act
            var stopwatch = Stopwatch.StartNew();
            var split = splitter.SplitByToken("key:\"value as data\"");
            stopwatch.Stop();

            // Assert
            this.WriteTimeElapsed(stopwatch);

            Assert.That(split, Is.Not.Null);

            Assert.That(split.Data, Is.EqualTo("key:\"value as data\""));
            Assert.That(split.HasType, Is.False);
            Assert.That(split.Type, Is.Null);
        }

        /// <summary>
        /// Splits the type of the by token when as in quoted value with type expect split with.
        /// </summary>
        [Test]
        public void SplitByToken_WhenAsInQuotedValueWithType_ExpectSplitWithType()
        {
            // Arrange
            var splitter = new TypeSplitter();

            // Act
            var stopwatch = Stopwatch.StartNew();
            var split = splitter.SplitByToken("key:\"value as data\" as string");
            stopwatch.Stop();

            // Assert
            this.WriteTimeElapsed(stopwatch);

            Assert.That(split, Is.Not.Null);

            Assert.That(split.Data, Is.EqualTo("key:\"value as data\""));
            Assert.That(split.HasType, Is.True);
            Assert.That(split.Type, Is.EqualTo("string"));
        }

        /// <summary>
        /// Splits the by token when as in value expect just data.
        /// </summary>
        [Test]
        public void SplitByToken_WhenAsInValue_ExpectJustData()
        {
            // Arrange
            var splitter = new TypeSplitter();

            // Act
            var stopwatch = Stopwatch.StartNew();
            var split = splitter.SplitByToken("key:valueasdata");
            stopwatch.Stop();

            // Assert
            this.WriteTimeElapsed(stopwatch);

            Assert.That(split, Is.Not.Null);

            Assert.That(split.Data, Is.EqualTo("key:valueasdata"));
            Assert.That(split.HasType, Is.False);
            Assert.That(split.Type, Is.Null);
        }

        /// <summary>
        /// Splits the by token when does not include type expect just data.
        /// </summary>
        [Test]
        public void SplitByToken_WhenDoesNotIncludeType_ExpectJustData()
        {
            // Arrange
            var splitter = new TypeSplitter();

            // Act
            var stopwatch = Stopwatch.StartNew();
            var split = splitter.SplitByToken("key:value");
            stopwatch.Stop();

            // Assert
            this.WriteTimeElapsed(stopwatch);

            Assert.That(split, Is.Not.Null);

            Assert.That(split.Data, Is.EqualTo("key:value"));
            Assert.That(split.HasType, Is.False);
            Assert.That(split.Type, Is.Null);
        }

        /// <summary>
        /// Splits the by token when complex query expect all parts split.
        /// </summary>
        [Test]
        public void SplitByToken_WhenIncludesType_ExpectSplitWithType()
        {
            // Arrange
            var splitter = new TypeSplitter();

            // Act
            var stopwatch = Stopwatch.StartNew();
            var split = splitter.SplitByToken("key:value as string");
            stopwatch.Stop();

            // Assert
            this.WriteTimeElapsed(stopwatch);

            Assert.That(split, Is.Not.Null);

            Assert.That(split.Data, Is.EqualTo("key:value"));
            Assert.That(split.HasType, Is.True);
            Assert.That(split.Type, Is.EqualTo("string"));
        }

        /// <summary>
        /// Splits the by token when invalid type expect throws.
        /// </summary>
        [Test]
        public void SplitByToken_WhenInvalidType_ExpectThrows()
        {
            // Arrange
            var splitter = new TypeSplitter();

            // Act
            var stopwatch = Stopwatch.StartNew();
            Assert.Throws<InvalidTypeException>(() => splitter.SplitByToken("key:value as testEntity"));
            stopwatch.Stop();

            // Assert
            this.WriteTimeElapsed(stopwatch);
        }
    }
}