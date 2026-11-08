/****************************
 * IReadWriteBlueprintSyncRepository.Auto.cs
 ****************************/
using System.Collections.Generic;

namespace ConceptMeta.Common
{
    /// <summary>
    /// Synchronous Read/Write Blueprint Repository interface
    /// </summary>
    public partial interface IReadWriteBlueprintSyncRepository<TBlueprintObj>
        : IReadableBlueprintSyncRepository<TBlueprintObj>,
        IReadWriteSyncRepository<TBlueprintObj>
        where TBlueprintObj : class
    {

        #region Methods that add objects

        /// <summary>
        /// Adds sterilised variants of a set of objects to the repository collection
        /// </summary>
        /// <param name="blueprintObjects"></param>
        void AddSterilisedRange(IEnumerable<TBlueprintObj> blueprintObjects);

        #endregion

        #region Methods that update objects

        /// <summary>
        /// Updates a set of objects in the repository collection with sterlised variants of the supplied values
        /// </summary>
        /// <param name="blueprintObjects"></param>
        void UpdateSterilisedRange(IEnumerable<TBlueprintObj> blueprintObjects);

        #endregion
    }
}
