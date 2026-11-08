/****************************
 * IUnitOfWork.Auto.cs
 ****************************/
using System;
using System.Threading.Tasks;

namespace ConceptMeta.Common
{
    /// <summary>
    /// Common Unit Of Work interface
    /// </summary>
    public partial interface IUnitOfWork
        : IDisposable
    {

        #region Instance Methods

        /// <summary>
        /// A method that may optionally be called after SaveChanges().
        /// This clears the cache without making any change to the current transaction.
        /// </summary>
        void ClearCache();

        /// <summary>
        /// Saves changes
        /// </summary>
        /// <returns></returns>
        int SaveChanges();

        /// <summary>
        /// Saves changes
        /// </summary>
        /// <returns></returns>
        Task<int> SaveChangesAsync();

        /// <summary>
        /// Method to be called once the unit of work is complete
        /// </summary>
        /// <returns></returns>
        int Complete();

        /// <summary>
        /// Method to be called once the unit of work is complete
        /// </summary>
        /// <returns></returns>
        Task<int> CompleteAsync();

        #endregion
    }
}
