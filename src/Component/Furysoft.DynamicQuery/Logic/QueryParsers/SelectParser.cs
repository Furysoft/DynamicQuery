// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SelectParser.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Logic.QueryParsers
{
    using System.Linq;
    using Furysoft.DynamicQuery.Entities.QueryComponents;
    using Furysoft.DynamicQuery.Interfaces;
    using Furysoft.DynamicQuery.Interfaces.QueryParsers;
    using JetBrains.Annotations;

    /// <summary>
    /// The Select Parser.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <seealso cref="ISelectParser" />
    public sealed class SelectParser<TEntity> : ISelectParser
    {
        /// <summary>
        /// The entity parser.
        /// </summary>
        [NotNull]
        private readonly IEntityParser<TEntity> entityParser;

        /// <summary>
        /// Initializes a new instance of the <see cref="SelectParser{TEntity}"/> class.
        /// </summary>
        /// <param name="entityParser">The entity parser.</param>
        public SelectParser([NotNull] IEntityParser<TEntity> entityParser)
        {
            this.entityParser = entityParser;
        }

        /// <summary>
        /// Parses the specified page data.
        /// </summary>
        /// <param name="selectData">The select data.</param>
        /// <param name="separator">The separator.</param>
        /// <returns>
        /// The Page Node.
        /// </returns>
        public SelectNode Parse(string selectData, char separator = ',')
        {
            if (selectData == "*")
            {
                var permittedProperties = this.entityParser.PermittedProperties.Select(r => r.QueryName).ToList();

                return new SelectNode { SelectAll = true, SelectColumns = permittedProperties };
            }

            var properties = selectData.Split(separator).Select(r => r.Trim()).Where(r => this.entityParser.IsPermitted(r)).ToList();

            return new SelectNode { SelectColumns = properties, SelectAll = false };
        }
    }
}