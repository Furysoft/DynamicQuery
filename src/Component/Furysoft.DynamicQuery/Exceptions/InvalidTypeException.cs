// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InvalidTypeException.cs" company="Email Hippo Ltd">
//   © Email Hippo Ltd
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// The Invalid Type Exception
    /// </summary>
    /// <seealso cref="DynamicQueryException" />
    [Serializable]
    public class InvalidTypeException : DynamicQueryException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidTypeException"/> class.
        /// </summary>
        public InvalidTypeException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidTypeException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public InvalidTypeException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidTypeException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="inner">The inner.</param>
        public InvalidTypeException(string message, Exception inner)
            : base(message, inner)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidTypeException"/> class.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"></see> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext"></see> that contains contextual information about the source or destination.</param>
        protected InvalidTypeException(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context)
        {
        }
    }
}