/****************************
 * IReadableAggregateRootSyncRepository.Auto.cs
 ****************************/
using System.Collections.Generic;

namespace ConceptMeta.Common
{
    /// <summary>
    /// Synchronous Readable Repository Interface for Aggregate Roots
    /// </summary>
    public partial interface IReadableAggregateRootSyncRepository<TAggregateRoot>
        : IReadableSyncRepository<TAggregateRoot>
        where TAggregateRoot : class
    {

        #region Methods that find objects

        /// <summary>
        /// Gets an aggregate from the data store
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        TAggregateRoot GetAggregate(params object[] keyValues);

        /// <summary>
        /// Gets all aggregates from the data store
        /// </summary>
        /// <returns></returns>
        IEnumerable<TAggregateRoot> GetAllAggregates();

        #endregion
    }
}
