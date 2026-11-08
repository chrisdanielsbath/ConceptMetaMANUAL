/****************************
 * IReadableBlueprintRepositoryBase.Auto.cs
 ****************************/
using System;
using System.Collections.Generic;

namespace ConceptMeta.Common
{
    /// <summary>
    /// Readable Blueprint Repository Base Interface
    /// </summary>
    public partial interface IReadableBlueprintRepositoryBase<TBlueprintObj>
        : IReadableRepositoryBase<TBlueprintObj>
        where TBlueprintObj : class
    {

        #region Methods that must be implemented separately in each concrete class

        /// <summary>
        /// Copies logical business key values to nested objects
        /// </summary>
        /// <param name="items"></param>
        /// <param name="recurse"></param>
        void CopyLogicalBusinessKeysToNestedObjects(
            IEnumerable<TBlueprintObj> items,
            bool recurse = true);

        /// <summary>
        /// Renumbers nested objects
        /// </summary>
        /// <param name="items"></param>
        /// <param name="recurse"></param>
        void RenumberNestedObjects(
            IEnumerable<TBlueprintObj> items,
            bool recurse = true);

        /// <summary>
        /// Sorts nested objects
        /// </summary>
        /// <param name="items"></param>
        /// <param name="recurse"></param>
        void SortNestedObjects(
            IEnumerable<TBlueprintObj> items,
            bool recurse = true);

        /// <summary>
        /// Gets a function that maps a blueprintObj to a string representation of its logical key
        /// </summary>
        /// <returns></returns>
        Func<TBlueprintObj, string> GetLogicalKeyFunction();

        /// <summary>
        /// Gets a predicate that identifies items without a primary key
        /// </summary>
        /// <returns></returns>
        Func<TBlueprintObj, bool> GetMissingPrimaryKeyPredicate();

        /// <summary>
        /// Copies primary key values from a blueprint object to each object within a collection
        /// </summary>
        /// <param name="fromBlueprintObj">the blueprint object from which to copy the primary key</param>
        /// <param name="toObjects">the set of objects in which to set the primary key</param>
        void CopyPrimaryKeyValuesFromEntityToObjects(
            TBlueprintObj fromBlueprintObj,
            IEnumerable<TBlueprintObj> toObjects);

        #endregion

        #region More Methods

        /// <summary>
        /// Identifies which items need to be added, updated and removed, based on primary keys
        /// </summary>
        /// <param name="oldItems"></param>
        /// <param name="newItems"></param>
        /// <param name="itemsToAdd"></param>
        /// <param name="itemsToUpdate1"></param>
        /// <param name="itemsToUpdate2"></param>
        /// <param name="itemsToRemove"></param>
        void IdentifyItemsPerAction(
            IEnumerable<TBlueprintObj> oldItems,
            IEnumerable<TBlueprintObj> newItems,
            out IEnumerable<TBlueprintObj> itemsToAdd,
            out IEnumerable<TBlueprintObj> itemsToUpdate1,
            out IEnumerable<TBlueprintObj> itemsToUpdate2,
            out IEnumerable<TBlueprintObj> itemsToRemove);

        #endregion
    }
}
