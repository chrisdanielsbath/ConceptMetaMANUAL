/****************************
 * IReadableEntityRepositoryBase.Auto.cs
 ****************************/
using System;
using System.Collections.Generic;

namespace ConceptMeta.Common
{
    /// <summary>
    /// Readable Repository base interface for a relational data store
    /// </summary>
    public partial interface IReadableEntityRepositoryBase<TEntity>
        : IReadableRepositoryBase<TEntity>
        where TEntity : class
    {

        #region Methods that must be implemented separately within each concrete class

        /// <summary>
        /// Populates foreign key fields using unique key values from parent objects
        /// </summary>
        /// <param name="items"></param>
        void PopulateForeignKeyValuesFromParents(IEnumerable<TEntity> items);

        /// <summary>
        /// Copies unique key values to child objects
        /// </summary>
        /// <param name="items"></param>
        void CopyUniqueKeyValuesToChildren(IEnumerable<TEntity> items);

        /// <summary>
        /// Copies primary key values from an entity to each object within a collection
        /// </summary>
        /// <param name="fromEntity">the entity from which to copy the primary key</param>
        /// <param name="toObjects">the set of objects in which to set the primary key</param>
        void CopyPrimaryKeyValuesFromEntityToObjects(
            TEntity fromEntity,
            IEnumerable<TEntity> toObjects);

        /// <summary>
        /// Gets a function that maps a entity to a string representation of its logical key
        /// </summary>
        /// <returns></returns>
        Func<TEntity, string> GetLogicalKeyFunction();

        /// <summary>
        /// Gets a predicate that identifies items without a primary key
        /// </summary>
        /// <returns></returns>
        Func<TEntity, bool> GetMissingPrimaryKeyPredicate();

        #endregion
    }
}
