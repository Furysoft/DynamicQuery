// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParseException.cs" company="Email Hippo Ltd">
//   © Email Hippo Ltd
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// The Parse Exception
    /// </summary>
    [Serializable]
    public class ParseException : DynamicQueryException
    {
        public ParseException()
        {
        }

        public ParseException(string message)
            : base(message)
        {
        }

        public ParseException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected ParseException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}