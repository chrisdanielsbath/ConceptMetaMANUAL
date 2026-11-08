/****************************
 * IReadableBlueprintSyncRepository.Auto.cs
 ****************************/
using System.Collections.Generic;

namespace ConceptMeta.Common
{
    /// <summary>
    /// Synchronous Readable Blueprint Repository Interface
    /// </summary>
    public partial interface IReadableBlueprintSyncRepository<TBlueprintObj>
        : IReadableBlueprintRepositoryBase<TBlueprintObj>,
        IReadableSyncRepository<TBlueprintObj>
        where TBlueprintObj : class
    {

        #region Methods that must be implemented separately in each concrete class

        /// <summary>
        /// Gets the unique entity that has the specified business key
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        TBlueprintObj GetByBusinessKey(params object[] keyValues);

        /// <summary>
        /// Populates foreign key fields using unique key values from parent objects
        /// </summary>
        /// <param name="items"></param>
        void PopulateForeignKeyValuesFromParents(IEnumerable<TBlueprintObj> items);

        /// <summary>
        /// Populates missing primary key fields where the values to use can be deduced using the logical key
        /// </summary>
        /// <param name="items"></param>
        void PopulateMissingPrimaryKeysIfKnown(IEnumerable<TBlueprintObj> items);

        #endregion
    }
}
