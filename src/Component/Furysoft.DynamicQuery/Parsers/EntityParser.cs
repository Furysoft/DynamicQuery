// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EntityParser.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Parsers
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Runtime.Serialization;
    using Attributes;
    using Interfaces;

    /// <summary>
    /// The Entity Parser
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <seealso cref="Furysoft.DynamicQuery.Interfaces.IEntityParser{TEntity}" />
    public sealed class EntityParser<TEntity> : IEntityParser<TEntity>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityParser{TEntity}"/> class.
        /// </summary>
        public EntityParser()
        {
            this.PermittedProperties = this.GetProperties();
        }

        /// <summary>
        /// Gets the permitted properties.
        /// </summary>
        public List<string> PermittedProperties { get; }

        /// <summary>
        /// Determines whether the specified name is permitted.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>
        ///   <c>true</c> if the specified name is permitted; otherwise, <c>false</c>.
        /// </returns>
        public bool IsPermitted(string name)
        {
            return this.PermittedProperties.Contains(name);
        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        /// <returns>The list of property names</returns>
        private List<string> GetProperties()
        {
            var publicProperties = typeof(TEntity).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            var rtn = new List<string>();
            foreach (var propertyInfo in publicProperties)
            {
                if (Attribute.IsDefined(propertyInfo, typeof(ExcludeAttribute)))
                {
                    continue;
                }

                var customName = propertyInfo.GetCustomAttribute<NameAttribute>(false);
                if (customName != null)
                {
                    rtn.Add(customName.Name);
                    continue;
                }

                var dataMemberName = propertyInfo.GetCustomAttribute<DataMemberAttribute>(false);
                if (dataMemberName != null)
                {
                    rtn.Add(dataMemberName.Name);
                    continue;
                }

                rtn.Add(propertyInfo.Name);
            }

            return rtn;
        }
    }
}