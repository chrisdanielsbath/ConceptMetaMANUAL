/****************************
 * IReadWriteEntityRepositoryBase.Auto.cs
 ****************************/
using System.Collections.Generic;

namespace ConceptMeta.Common
{
    /// <summary>
    /// Read/Write Repository base interface for a relational data store
    /// </summary>
    public partial interface IReadWriteEntityRepositoryBase<TEntity>
        : IReadableEntityRepositoryBase<TEntity>
        where TEntity : class
    {

        #region Methods that identify change

        /// <summary>
        /// Identifies which items need to be added, updated and removed, based on primary keys
        /// </summary>
        /// <param name="oldItems"></param>
        /// <param name="newItems"></param>
        /// <param name="itemsToAdd"></param>
        /// <param name="itemsToUpdate1"></param>
        /// <param name="itemsToUpdate2"></param>
        /// <param name="itemsToRemove"></param>
        void IdentifyItemsPerAction<TBlueprintObj>(
            IEnumerable<KeyValuePair<TEntity, TBlueprintObj>> oldItems,
            IEnumerable<KeyValuePair<TEntity, TBlueprintObj>> newItems,
            out IEnumerable<KeyValuePair<TEntity, TBlueprintObj>> itemsToAdd,
            out IEnumerable<KeyValuePair<TEntity, TBlueprintObj>> itemsToUpdate1,
            out IEnumerable<KeyValuePair<TEntity, TBlueprintObj>> itemsToUpdate2,
            out IEnumerable<KeyValuePair<TEntity, TBlueprintObj>> itemsToRemove);

        #endregion
    }
}
