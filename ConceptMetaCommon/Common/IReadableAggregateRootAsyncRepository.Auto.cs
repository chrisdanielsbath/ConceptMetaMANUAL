/****************************
 * IReadableAggregateRootAsyncRepository.Auto.cs
 ****************************/
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConceptMeta.Common
{
    /// <summary>
    /// Asynchronous Readable Repository Interface for Aggregate Roots
    /// </summary>
    public partial interface IReadableAggregateRootAsyncRepository<TAggregateRoot>
        : IReadableAsyncRepository<TAggregateRoot>
        where TAggregateRoot : class
    {

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
