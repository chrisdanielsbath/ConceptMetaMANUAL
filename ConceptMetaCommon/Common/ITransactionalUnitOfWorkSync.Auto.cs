/****************************
 * ITransactionalUnitOfWorkSync.Auto.cs
 ****************************/
using System.Data;

namespace ConceptMeta.Common
{
    /// <summary>
    /// Synchronous Transactional Unit Of Work interface
    /// </summary>
    public partial interface ITransactionalUnitOfWorkSync
        : IReadWriteUnitOfWorkSync
    {

        #region Instance Methods

        /// <summary>
        /// Method to be called if multiple saves are to be performed within a transaction
        /// </summary>
        /// <param name="isolationLevel"></param>
        void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);

        /// <summary>
        /// Method to be called once the unit of work is complete
        /// </summary>
        /// <returns></returns>
        int Complete();

        /// <summary>
        /// Method to be called to rollback the unit of work
        /// </summary>
        void Rollback();

        #endregion
    }
}
