/****************************
 * IReadWriteBlueprintAsyncRepository.Auto.cs
 ****************************/
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConceptMeta.Common
{
    /// <summary>
    /// Asynchronous Read/Write Blueprint Repository interface
    /// </summary>
    public partial interface IReadWriteBlueprintAsyncRepository<TBlueprintObj>
        : IReadableBlueprintAsyncRepository<TBlueprintObj>,
        IReadWriteAsyncRepository<TBlueprintObj>
        where TBlueprintObj : class
    {

        #region Methods that add objects

        /// <summary>
        /// Adds sterilised variants of a set of objects to the repository collection
        /// </summary>
        /// <param name="blueprintObjects"></param>
        /// <returns></returns>
        Task AddSterilisedRangeAsync(IEnumerable<TBlueprintObj> blueprintObjects);

        #endregion

        #region Methods that update objects

        /// <summary>
        /// Updates a set of objects in the repository collection with sterlised variants of the supplied values
        /// </summary>
        /// <param name="blueprintObjects"></param>
        /// <returns></returns>
        Task UpdateSterilisedRangeAsync(IEnumerable<TBlueprintObj> blueprintObjects);

        #endregion
    }
}
