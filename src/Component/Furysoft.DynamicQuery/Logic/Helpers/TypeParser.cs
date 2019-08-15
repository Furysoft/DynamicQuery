// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TypeParser.cs" company="Email Hippo Ltd">
//   © Email Hippo Ltd
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Logic.Helpers
{
    using System;
    using Entities;
    using Exceptions;

    /// <summary>
    /// The Type Parser
    /// </summary>
    public static class TypeParser
    {
        /// <summary>
        /// Parses the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="type">The type.</param>
        /// <returns>The parsed object</returns>
        public static object Parse(string value, string type)
        {
            if (type == Types.String)
            {
                return value;
            }
            else if (type == Types.Int)
            {
                if (int.TryParse(value, out var intVal))
                {
                    return intVal;
                }
            }
            else if (type == Types.Decimal)
            {
                if (decimal.TryParse(value, out var intVal))
                {
                    return intVal;
                }
            }
            else if (type == Types.DateTime)
            {
                if (DateTime.TryParse(value, out var intVal))
                {
                    return intVal;
                }
            }

            throw new ParseException($"Failed to parse {value} as type {type}");
        }
    }
}