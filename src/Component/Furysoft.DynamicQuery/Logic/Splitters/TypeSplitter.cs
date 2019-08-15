// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TypeSplitter.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Logic.Splitters
{
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Entities;
    using Exceptions;
    using Interfaces.Splitters;

    /// <inheritdoc />
    public sealed class TypeSplitter : ISplitter<TypeSplitterResponse>
    {
        /// <summary>
        /// The regex
        /// </summary>
        private static readonly Regex RegexQuery = new Regex(
            "( as )",
            RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.ExplicitCapture);

        /// <inheritdoc />
        public TypeSplitterResponse SplitByToken(string query)
        {
            var lastQuote = query.LastIndexOf('"');

            // If it ends with a quote, there's no type included (entire string is quoted)
            if (lastQuote == query.Length - 1)
            {
                return new TypeSplitterResponse
                {
                    Data = query,
                    Type = null,
                    HasType = false
                };
            }

            var splitParts = new List<string>();
            
            // No quote at all, treat literally
            if (lastQuote == -1)
            {
                splitParts = RegexQuery.Split(query).Where(r => !string.IsNullOrWhiteSpace(r)).ToList();
            }
            // There's a quote in here, but it's not the end
            else
            {
                // The quota part is the data query
                var quotedPart = query.Substring(0, lastQuote + 1);

                // The extra part is the remained of the data
                var extraPart = query.Substring(lastQuote + 1);

                var split = RegexQuery.Split(extraPart).Where(r => !string.IsNullOrWhiteSpace(r)).ToList();

                splitParts = new List<string>
                {
                    quotedPart,
                    split[0]
                };
            }
            
            // If there's only one part, then there is no type
            if (splitParts.Count == 1)
            {
                return new TypeSplitterResponse
                {
                    Data = query,
                    Type = null,
                    HasType = false
                };
            }

            var data = splitParts[0].TrimEnd();
            var type = splitParts[1].TrimStart();

            if (!IsValidType(type))
            {
                throw new InvalidTypeException($"Type {type} is not a valid type");
            }

            return new TypeSplitterResponse
            {
                Data = data,
                Type = type,
                HasType = true
            };
        }

        /// <summary>
        /// Determines whether [is valid type] [the specified type].
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>
        ///   <c>true</c> if [is valid type] [the specified type]; otherwise, <c>false</c>.
        /// </returns>
        private static bool IsValidType(string type)
        {
            switch (type)
            {
                case Types.String:
                case Types.Int:
                case Types.Decimal:
                case Types.DateTime:
                    return true;
                default:
                    return false;
            }
        }
    }
}