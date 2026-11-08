/****************************
 * IReadableEntitySyncRepository.Auto.cs
 ****************************/
using System.Collections.Generic;

namespace ConceptMeta.Common
{
    /// <summary>
    /// Synchronous Readable Repository interface for a relational data store
    /// </summary>
    public partial interface IReadableEntitySyncRepository<TEntity>
        : IReadableEntityRepositoryBase<TEntity>
        where TEntity : class
    {

        #region Methods that must be implemented separately within each concrete class

        /// <summary>
        /// Populates missing primary key fields where the values to use can be deduced using the logical key
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        bool PopulateMissingPrimaryKeyIfKnown(TEntity e);

        #endregion

        #region Methods that find objects

        /// <summary>
        /// Gets the entity that has the specified business key
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        TEntity GetByBusinessKey(params object[] keyValues);

        #endregion

        #region Methods that enrich content

        /// <summary>
        /// Modifies objects to populate primary keys that can be deduced from logical keys
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        IEnumerable<TEntity> PopulateMissingPrimaryKeysIfKnown(IEnumerable<TEntity> items);

        #endregion
    }
}
