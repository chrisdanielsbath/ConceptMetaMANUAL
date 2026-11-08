/****************************
 * IReadWriteBlueprintAggregateRootSyncRepository.Auto.cs
 ****************************/
using System.Collections.Generic;

namespace ConceptMeta.Common
{
    /// <summary>
    /// Synchronous Read/Write Repository Interface for Blueprint Aggregate Roots
    /// </summary>
    public partial interface IReadWriteBlueprintAggregateRootSyncRepository<TAggregateRoot>
        : IReadableBlueprintAggregateRootSyncRepository<TAggregateRoot>,
        IReadWriteBlueprintSyncRepository<TAggregateRoot>
        where TAggregateRoot : class
    {

        #region Methods that add objects

        /// <summary>
        /// Adds an aggregate to the data store
        /// </summary>
        /// <param name="blueprintObj"></param>
        void AddAggregate(TAggregateRoot blueprintObj);

        /// <summary>
        /// Adds a set of aggregates to the data store
        /// </summary>
        /// <param name="blueprintObjects"></param>
        void AddAggregateRange(IEnumerable<TAggregateRoot> blueprintObjects);

        /// <summary>
        /// Adds an aggregate in the data store if no existing entry has the same identifier
        /// </summary>
        /// <param name="blueprintObj"></param>
        void AddAggregateIfNotExists(TAggregateRoot blueprintObj);

        /// <summary>
        /// Adds a set of aggregates to the data store where no existing entry has the same identifier
        /// </summary>
        /// <param name="blueprintObjects"></param>
        void AddAggregateRangeIfNotExists(IEnumerable<TAggregateRoot> blueprintObjects);

        #endregion

        #region Methods that update objects

        /// <summary>
        /// Updates an aggregate in the data store
        /// </summary>
        /// <param name="blueprintObj"></param>
        void UpdateAggregate(TAggregateRoot blueprintObj);

        /// <summary>
        /// Updates a set of aggregates in the data store
        /// </summary>
        /// <param name="blueprintObjects"></param>
        void UpdateAggregateRange(IEnumerable<TAggregateRoot> blueprintObjects);

        #endregion

        #region Methods that add or update objects

        /// <summary>
        /// Adds an aggregate or updates an aggregate in the data store
        /// </summary>
        /// <param name="blueprintObj"></param>
        void AddOrUpdateAggregate(TAggregateRoot blueprintObj);

        /// <summary>
        /// Adds or updates a set of aggregates in the data store
        /// </summary>
        /// <param name="blueprintObjects"></param>
        void AddOrUpdateAggregateRange(IEnumerable<TAggregateRoot> blueprintObjects);

        #endregion

        #region Methods that remove objects

        /// <summary>
        /// Removes an aggregate from the data store
        /// </summary>
        /// <param name="blueprintObj"></param>
        void RemoveAggregate(TAggregateRoot blueprintObj);

        /// <summary>
        /// Removes a set of aggregates from the data store
        /// </summary>
        /// <param name="blueprintObjects"></param>
        void RemoveAggregateRange(IEnumerable<TAggregateRoot> blueprintObjects);

        #endregion
    }
}
