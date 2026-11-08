/****************************
 * IReadableBlueprintAggregateRootSyncRepository.Auto.cs
 ****************************/
using System.Collections.Generic;

namespace ConceptMeta.Common
{
    /// <summary>
    /// Synchronous Readable Repository Interface for Blueprint Aggregate Roots
    /// </summary>
    public partial interface IReadableBlueprintAggregateRootSyncRepository<TAggregateRoot>
        : IReadableBlueprintSyncRepository<TAggregateRoot>
        where TAggregateRoot : class
    {

        #region Methods that must be implemented separately in each concrete class

        /// <summary>
        /// Gets the aggregate that has the supplied business key
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        TAggregateRoot GetAggregateByBusinessKey(params object[] keyValues);

        #endregion

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
