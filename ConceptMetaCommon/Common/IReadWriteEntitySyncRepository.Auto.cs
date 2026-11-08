/****************************
 * IReadWriteEntitySyncRepository.Auto.cs
 ****************************/
using System.Collections.Generic;

namespace ConceptMeta.Common
{
    /// <summary>
    /// Synchronous Read/Write Repository interface for a relational data store
    /// </summary>
    public partial interface IReadWriteEntitySyncRepository<TEntity>
        : IReadWriteEntityRepositoryBase<TEntity>,
        IReadWriteSyncRepository<TEntity>
        where TEntity : class
    {

        #region Methods that add objects

        /// <summary>
        /// Adds sterilised variants of a set of objects to the repository collection
        /// </summary>
        /// <param name="entities"></param>
        void AddSterilisedRange(IEnumerable<TEntity> entities);

        #endregion

        #region Methods that update objects

        /// <summary>
        /// Updates a set of objects in the repository collection with sterlised variants of the supplied values
        /// </summary>
        /// <param name="entities"></param>
        void UpdateSterilisedRange(IEnumerable<TEntity> entities);

        #endregion
    }
}
