/****************************
 * IReadWriteAggregateRootAsyncRepository.Auto.cs
 ****************************/
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConceptMeta.Common
{
    /// <summary>
    /// Asynchronous Read/Write Repository Interface for Aggregate Roots
    /// </summary>
    public partial interface IReadWriteAggregateRootAsyncRepository<TAggregateRoot>
        : IReadableAggregateRootAsyncRepository<TAggregateRoot>
        where TAggregateRoot : class
    {

        #region Methods that add objects

        /// <summary>
        /// Adds an aggregate to the data store
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task AddAggregateAsync(TAggregateRoot entity);

        /// <summary>
        /// Adds a set of aggregates to the data store
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        Task AddAggregateRangeAsync(IEnumerable<TAggregateRoot> entities);

        /// <summary>
        /// Adds an aggregate in the data store if no existing entry has the same identifier
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task AddAggregateIfNotExistsAsync(TAggregateRoot entity);

        /// <summary>
        /// Adds a set of aggregates to the data store where no existing entry has the same identifier
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        Task AddAggregateRangeIfNotExistsAsync(IEnumerable<TAggregateRoot> entities);

        #endregion

        #region Methods that update objects

        /// <summary>
        /// Updates an aggregate in the data store
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task UpdateAggregateAsync(TAggregateRoot entity);

        /// <summary>
        /// Updates a set of aggregates in the data store
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        Task UpdateAggregateRangeAsync(IEnumerable<TAggregateRoot> entities);

        #endregion

        #region Methods that add or update objects

        /// <summary>
        /// Adds an aggregate or updates an aggregate in the data store
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task AddOrUpdateAggregateAsync(TAggregateRoot entity);

        /// <summary>
        /// Adds or updates a set of aggregates in the data store
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        Task AddOrUpdateAggregateRangeAsync(IEnumerable<TAggregateRoot> entities);

        #endregion

        #region Methods that remove objects

        /// <summary>
        /// Removes an aggregate from the data store
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task RemoveAggregateAsync(TAggregateRoot entity);

        /// <summary>
        /// Removes a set of aggregates from the data store
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        Task RemoveAggregateRangeAsync(IEnumerable<TAggregateRoot> entities);

        #endregion
    }
}
