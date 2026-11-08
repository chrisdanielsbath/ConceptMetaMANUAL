/****************************
 * IReadableAsyncRepository.Auto.cs
 ****************************/
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConceptMeta.Common
{
    /// <summary>
    /// Common Readable Asynchronous Repository Interface
    /// </summary>
    public partial interface IReadableAsyncRepository<T>
        : IReadableRepositoryBase<T>
        where T : class
    {

        #region Methods that find objects

        /// <summary>
        /// Gets the object identified by the specified key
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        Task<T> GetAsync(params object[] keyValues);

        /// <summary>
        /// Gets all objects in the collection
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<T>> GetAllAsync();

        #endregion
    }
}
