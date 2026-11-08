/****************************
 * IReadWriteAggregateRootSyncRepository.Auto.cs
 ****************************/
using System.Collections.Generic;

namespace ConceptMeta.Common
{
    /// <summary>
    /// Synchronous Read/Write Repository Interface for Aggregate Roots
    /// </summary>
    public partial interface IReadWriteAggregateRootSyncRepository<TAggregateRoot>
        : IReadableAggregateRootSyncRepository<TAggregateRoot>
        where TAggregateRoot : class
    {

        #region Methods that add objects

        /// <summary>
        /// Adds an aggregate to the data store
        /// </summary>
        /// <param name="entity"></param>
        void AddAggregate(TAggregateRoot entity);

        /// <summary>
        /// Adds a set of aggregates to the data store
        /// </summary>
        /// <param name="entities"></param>
        void AddAggregateRange(IEnumerable<TAggregateRoot> entities);

        /// <summary>
        /// Adds an aggregate in the data store if no existing entry has the same identifier
        /// </summary>
        /// <param name="entity"></param>
        void AddAggregateIfNotExists(TAggregateRoot entity);

        /// <summary>
        /// Adds a set of aggregates to the data store where no existing entry has the same identifier
        /// </summary>
        /// <param name="entities"></param>
        void AddAggregateRangeIfNotExists(IEnumerable<TAggregateRoot> entities);

        #endregion

        #region Methods that update objects

        /// <summary>
        /// Updates an aggregate in the data store
        /// </summary>
        /// <param name="entity"></param>
        void UpdateAggregate(TAggregateRoot entity);

        /// <summary>
        /// Updates a set of aggregates in the data store
        /// </summary>
        /// <param name="entities"></param>
        void UpdateAggregateRange(IEnumerable<TAggregateRoot> entities);

        #endregion

        #region Methods that add or update objects

        /// <summary>
        /// Adds an aggregate or updates an aggregate in the data store
        /// </summary>
        /// <param name="entity"></param>
        void AddOrUpdateAggregate(TAggregateRoot entity);

        /// <summary>
        /// Adds or updates a set of aggregates in the data store
        /// </summary>
        /// <param name="entities"></param>
        void AddOrUpdateAggregateRange(IEnumerable<TAggregateRoot> entities);

        #endregion

        #region Methods that remove objects

        /// <summary>
        /// Removes an aggregate from the data store
        /// </summary>
        /// <param name="entity"></param>
        void RemoveAggregate(TAggregateRoot entity);

        /// <summary>
        /// Removes a set of aggregates from the data store
        /// </summary>
        /// <param name="entities"></param>
        void RemoveAggregateRange(IEnumerable<TAggregateRoot> entities);

        #endregion
    }
}
