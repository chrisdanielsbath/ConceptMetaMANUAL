/****************************
 * IReadableBlueprintAsyncRepository.Auto.cs
 ****************************/
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConceptMeta.Common
{
    /// <summary>
    /// Asynchronous Readable Blueprint Repository Interface
    /// </summary>
    public partial interface IReadableBlueprintAsyncRepository<TBlueprintObj>
        : IReadableBlueprintRepositoryBase<TBlueprintObj>,
        IReadableAsyncRepository<TBlueprintObj>
        where TBlueprintObj : class
    {

        #region Methods that must be implemented separately in each concrete class

        /// <summary>
        /// Gets the unique entity that has the specified business key
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        Task<TBlueprintObj> GetByBusinessKeyAsync(params object[] keyValues);

        /// <summary>
        /// Populates foreign key fields using unique key values from parent objects
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        Task PopulateForeignKeyValuesFromParentsAsync(IEnumerable<TBlueprintObj> items);

        /// <summary>
        /// Populates missing primary key fields where the values to use can be deduced using the logical key
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        Task PopulateMissingPrimaryKeysIfKnownAsync(IEnumerable<TBlueprintObj> items);

        #endregion
    }
}
