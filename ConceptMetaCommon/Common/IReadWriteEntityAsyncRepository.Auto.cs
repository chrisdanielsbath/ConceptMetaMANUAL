/****************************
 * IReadWriteEntityAsyncRepository.Auto.cs
 ****************************/
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConceptMeta.Common
{
    /// <summary>
    /// Asynchronous Read/Write Repository interface for a relational data store
    /// </summary>
    public partial interface IReadWriteEntityAsyncRepository<TEntity>
        : IReadWriteEntityRepositoryBase<TEntity>,
        IReadWriteAsyncRepository<TEntity>
        where TEntity : class
    {

        #region Methods that add objects

        /// <summary>
        /// Adds sterilised variants of a set of objects to the repository collection
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        Task AddSterilisedRangeAsync(IEnumerable<TEntity> entities);

        #endregion

        #region Methods that update objects

        /// <summary>
        /// Updates a set of objects in the repository collection with sterlised variants of the supplied values
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        Task UpdateSterilisedRangeAsync(IEnumerable<TEntity> entities);

        #endregion
    }
}
