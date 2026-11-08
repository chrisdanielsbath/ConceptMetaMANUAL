/****************************
 * IReadableSyncRepository.Auto.cs
 ****************************/
using System.Collections.Generic;

namespace ConceptMeta.Common
{
    /// <summary>
    /// Common Readable Synchronous Repository Interface
    /// </summary>
    public partial interface IReadableSyncRepository<T>
        : IReadableRepositoryBase<T>
        where T : class
    {

        #region Methods that find objects

        /// <summary>
        /// Gets the object identified by the specified key
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        T Get(params object[] keyValues);

        /// <summary>
        /// Gets all objects in the collection
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetAll();

        #endregion
    }
}
