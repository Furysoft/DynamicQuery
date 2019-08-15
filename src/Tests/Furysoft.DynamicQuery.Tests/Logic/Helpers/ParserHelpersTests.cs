// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParserHelpersTests.cs" company="Email Hippo Ltd">
//   © Email Hippo Ltd
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Tests.Logic.Helpers
{
    using System;
    using System.Diagnostics;
    using DynamicQuery.Logic.Helpers;
    using NUnit.Framework;

    /// <summary>
    /// The Parser Helpers Tests
    /// </summary>
    [TestFixture]
    public sealed class ParserHelpersTests : TestBase
    {
        /// <summary>
        /// Parses the when date time expect parsed as date time.
        /// </summary>
        [Test]
        public void Parse_WhenDateTime_ExpectParsedAsDateTime()
        {
            // Arrange

            // Act
            var stopwatch = Stopwatch.StartNew();
            var obj = ParserHelpers.Parse("2018-1-1");
            stopwatch.Stop();

            // Assert
            this.WriteTimeElapsed(stopwatch);

            var objAsDateTime = obj as DateTime?;

            Assert.That(objAsDateTime, Is.Not.Null);
            Assert.That(objAsDateTime, Is.EqualTo(new DateTime(2018, 1, 1)));
        }

        /// <summary>
        /// Parses the when decimal expect parsed as decimal.
        /// </summary>
        [Test]
        public void Parse_WhenDecimal_ExpectParsedAsDecimal()
        {
            // Arrange

            // Act
            var stopwatch = Stopwatch.StartNew();
            var obj = ParserHelpers.Parse("123.52");
            stopwatch.Stop();

            // Assert
            this.WriteTimeElapsed(stopwatch);

            var objAsDecimal = obj as decimal?;

            Assert.That(objAsDecimal, Is.Not.Null);
            Assert.That(objAsDecimal, Is.EqualTo(123.52));
        }

        /// <summary>
        /// Parses the when int expect parsed as int.
        /// </summary>
        [Test]
        public void Parse_WhenInt_ExpectParsedAsInt()
        {
            // Arrange

            // Act
            var stopwatch = Stopwatch.StartNew();
            var obj = ParserHelpers.Parse("123");
            stopwatch.Stop();

            // Assert
            this.WriteTimeElapsed(stopwatch);

            var objAsInt = obj as int?;

            Assert.That(objAsInt, Is.Not.Null);
            Assert.That(objAsInt, Is.EqualTo(123));
        }

        /// <summary>
        /// Parses the when string expect parsed as string.
        /// </summary>
        [Test]
        public void Parse_WhenString_ExpectParsedAsString()
        {
            // Arrange

            // Act
            var stopwatch = Stopwatch.StartNew();
            var obj = ParserHelpers.Parse("Some text");
            stopwatch.Stop();

            // Assert
            this.WriteTimeElapsed(stopwatch);

            var objAsString = obj as string;

            Assert.That(objAsString, Is.Not.Null);
            Assert.That(objAsString, Is.EqualTo("Some text"));
        }
    }
}