/****************************
 * IReadableEntityAsyncRepository.Auto.cs
 ****************************/
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConceptMeta.Common
{
    /// <summary>
    /// Asynchronous Readable Repository interface for a relational data store
    /// </summary>
    public partial interface IReadableEntityAsyncRepository<TEntity>
        : IReadableEntityRepositoryBase<TEntity>
        where TEntity : class
    {

        #region Methods that must be implemented separately within each concrete class

        /// <summary>
        /// Populates missing primary key fields where the values to use can be deduced using the logical key
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        Task<bool> PopulateMissingPrimaryKeyIfKnownAsync(TEntity e);

        #endregion

        #region Methods that find objects

        /// <summary>
        /// Gets the entity that has the specified business key
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        Task<TEntity> GetByBusinessKeyAsync(params object[] keyValues);

        #endregion

        #region Methods that enrich content

        /// <summary>
        /// Modifies objects to populate primary keys that can be deduced from logical keys
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> PopulateMissingPrimaryKeysIfKnownAsync(IEnumerable<TEntity> items);

        #endregion
    }
}
