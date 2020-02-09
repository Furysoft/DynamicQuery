// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DynamicQueryException.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// The Dynamic Query Exception.
    /// </summary>
    [Serializable]
    public class DynamicQueryException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DynamicQueryException"/> class.
        /// </summary>
        public DynamicQueryException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DynamicQueryException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public DynamicQueryException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DynamicQueryException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="inner">The inner.</param>
        public DynamicQueryException(string message, Exception inner)
            : base(message, inner)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DynamicQueryException"/> class.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"></see> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext"></see> that contains contextual information about the source or destination.</param>
        protected DynamicQueryException(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context)
        {
        }
    }
}