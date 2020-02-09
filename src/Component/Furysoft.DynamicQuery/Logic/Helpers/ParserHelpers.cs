// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParserHelpers.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Logic.Helpers
{
    using System;

    /// <summary>
    /// The Parser Helpers.
    /// </summary>
    public static class ParserHelpers
    {
        /// <summary>
        /// Parses the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="type">The type.</param>
        /// <returns>
        /// The Object.
        /// </returns>
        public static object Parse(string source, string type = null)
        {
            var cleaned = source.Trim('"');

            if (type != null)
            {
                return TypeParser.Parse(cleaned, type);
            }

            if (int.TryParse(cleaned, out var intType))
            {
                return intType;
            }

            if (decimal.TryParse(cleaned, out var decimalType))
            {
                return decimalType;
            }

            if (DateTime.TryParse(cleaned, out var dateTimeType))
            {
                return dateTimeType;
            }

            return source;
        }
    }
}