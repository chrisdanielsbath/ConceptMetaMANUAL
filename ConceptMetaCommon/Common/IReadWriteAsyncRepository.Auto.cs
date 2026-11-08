/****************************
 * IReadWriteAsyncRepository.Auto.cs
 ****************************/
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConceptMeta.Common
{
    /// <summary>
    /// Asynchronous Read/Write Repository Interface
    /// </summary>
    public partial interface IReadWriteAsyncRepository<T>
        : IReadableAsyncRepository<T>
        where T : class
    {

        #region Methods that add objects

        /// <summary>
        /// Adds the object to the repository collection
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task AddAsync(T item);

        /// <summary>
        /// Adds a set of objects to the repository collection
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        Task AddRangeAsync(IEnumerable<T> items);

        /// <summary>
        /// Adds the object to the repository collection if no existing object shares the same identifier
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task AddIfNotExistsAsync(T item);

        /// <summary>
        /// Adds objects to the repository collection where no existing object shares the same identifier
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        Task AddRangeIfNotExistsAsync(IEnumerable<T> items);

        #endregion

        #region Methods that update objects

        /// <summary>
        /// Updates the object in the repository collection
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task UpdateAsync(T item);

        /// <summary>
        /// Updates a set of objects in the repository collection
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        Task UpdateRangeAsync(IEnumerable<T> items);

        #endregion

        #region Methods that add or update objects

        /// <summary>
        /// Adds or updates the object in the repository collection
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task AddOrUpdateAsync(T item);

        /// <summary>
        /// Adds or updates a set of objects in the repository collection
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        Task AddOrUpdateRangeAsync(IEnumerable<T> items);

        #endregion

        #region Methods that remove objects

        /// <summary>
        /// Removes the object from the repository collection
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task RemoveAsync(T item);

        /// <summary>
        /// Removes a set of objects from the repository collection
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        Task RemoveRangeAsync(IEnumerable<T> items);

        #endregion
    }
}
