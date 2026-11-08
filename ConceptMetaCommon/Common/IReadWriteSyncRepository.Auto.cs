/****************************
 * IReadWriteSyncRepository.Auto.cs
 ****************************/
using System.Collections.Generic;

namespace ConceptMeta.Common
{
    /// <summary>
    /// Synchronous Read/Write Repository Interface
    /// </summary>
    public partial interface IReadWriteSyncRepository<T>
        : IReadableSyncRepository<T>
        where T : class
    {

        #region Methods that add objects

        /// <summary>
        /// Adds the object to the repository collection
        /// </summary>
        /// <param name="item"></param>
        void Add(T item);

        /// <summary>
        /// Adds a set of objects to the repository collection
        /// </summary>
        /// <param name="items"></param>
        void AddRange(IEnumerable<T> items);

        /// <summary>
        /// Adds the object to the repository collection if no existing object shares the same identifier
        /// </summary>
        /// <param name="item"></param>
        void AddIfNotExists(T item);

        /// <summary>
        /// Adds objects to the repository collection where no existing object shares the same identifier
        /// </summary>
        /// <param name="items"></param>
        void AddRangeIfNotExists(IEnumerable<T> items);

        #endregion

        #region Methods that update objects

        /// <summary>
        /// Updates the object in the repository collection
        /// </summary>
        /// <param name="item"></param>
        void Update(T item);

        /// <summary>
        /// Updates a set of objects in the repository collection
        /// </summary>
        /// <param name="items"></param>
        void UpdateRange(IEnumerable<T> items);

        #endregion

        #region Methods that add or update objects

        /// <summary>
        /// Adds or updates the object in the repository collection
        /// </summary>
        /// <param name="item"></param>
        void AddOrUpdate(T item);

        /// <summary>
        /// Adds or updates a set of objects in the repository collection
        /// </summary>
        /// <param name="items"></param>
        void AddOrUpdateRange(IEnumerable<T> items);

        #endregion

        #region Methods that remove objects

        /// <summary>
        /// Removes the object from the repository collection
        /// </summary>
        /// <param name="item"></param>
        void Remove(T item);

        /// <summary>
        /// Removes a set of objects from the repository collection
        /// </summary>
        /// <param name="items"></param>
        void RemoveRange(IEnumerable<T> items);

        #endregion
    }
}
