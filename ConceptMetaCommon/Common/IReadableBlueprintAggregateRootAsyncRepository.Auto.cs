/****************************
 * IReadableBlueprintAggregateRootAsyncRepository.Auto.cs
 ****************************/
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConceptMeta.Common
{
    /// <summary>
    /// Asynchronous Readable Repository Interface for Blueprint Aggregate Roots
    /// </summary>
    public partial interface IReadableBlueprintAggregateRootAsyncRepository<TAggregateRoot>
        : IReadableBlueprintAsyncRepository<TAggregateRoot>
        where TAggregateRoot : class
    {

        #region Methods that must be implemented separately in each concrete class

        /// <summary>
        /// Gets the aggregate that has the supplied business key
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        Task<TAggregateRoot> GetAggregateByBusinessKeyAsync(params object[] keyValues);

        #endregion

        #region Methods that find objects

        /// <summary>
        /// Gets an aggregate from the data store
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        Task<TAggregateRoot> GetAggregateAsync(params object[] keyValues);

        /// <summary>
        /// Gets all aggregates from the data store
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TAggregateRoot>> GetAllAggregatesAsync();

        #endregion
    }
}
