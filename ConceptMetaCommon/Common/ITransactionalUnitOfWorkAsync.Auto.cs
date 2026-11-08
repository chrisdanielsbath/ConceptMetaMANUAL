/****************************
 * ITransactionalUnitOfWorkAsync.Auto.cs
 ****************************/
using System.Data;
using System.Threading.Tasks;

namespace ConceptMeta.Common
{
    /// <summary>
    /// Asynchronous Transactional Unit Of Work interface
    /// </summary>
    public partial interface ITransactionalUnitOfWorkAsync
        : IReadWriteUnitOfWorkAsync
    {

        #region Instance Methods

        /// <summary>
        /// Method to be called if multiple saves are to be performed within a transaction
        /// </summary>
        /// <param name="isolationLevel"></param>
        /// <returns></returns>
        Task BeginTransactionAsync(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);

        /// <summary>
        /// Method to be called once the unit of work is complete
        /// </summary>
        /// <returns></returns>
        Task<int> CompleteAsync();

        /// <summary>
        /// Method to be called to rollback the unit of work
        /// </summary>
        /// <returns></returns>
        Task RollbackAsync();

        #endregion
    }
}
