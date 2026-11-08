/****************************
 * BlueprintUnitOfWork.Auto.cs
 ****************************/
using System.Data;
using System.Threading.Tasks;
using AutoMapper;

namespace ConceptMeta.Common.Blueprint
{
    /// <summary>
    /// Blueprint Unit Of Work class
    /// </summary>
    public abstract partial class BlueprintUnitOfWork<TDbUnitOfWork>
        : IBlueprintUnitOfWork<TDbUnitOfWork>
        where TDbUnitOfWork : class, ITransactionalUnitOfWork
    {

        #region Constructors
        public BlueprintUnitOfWork(TDbUnitOfWork dbUnitOfWork)
        {
            DbUnitOfWork = dbUnitOfWork;
        }

        #endregion

        #region Instance Properties

        /// <summary>
        /// The Unit Of Work class to be used when persisting and retrieving database entities
        /// </summary>
        public TDbUnitOfWork DbUnitOfWork { get; private set; }

        #endregion

        #region Instance Properties that must be implemented separately in each concrete class

        /// <summary>
        /// The mapper to be used when converting to Entities
        /// </summary>
        public abstract IMapper ToEntityMapper { get; }

        /// <summary>
        /// The mapper to be used when converting from Entities
        /// </summary>
        public abstract IMapper FromEntityMapper { get; }

        /// <summary>
        /// The mapper to be used when converting to Entity/Blueprint pairs
        /// </summary>
        public abstract IMapper ToEntityBlueprintPairMapper { get; }

        /// <summary>
        /// The mapper to be used when converting from Entity/Blueprint pairs
        /// </summary>
        public abstract IMapper FromEntityBlueprintPairMapper { get; }

        #endregion

        #region Instance Methods

        /// <summary>
        /// A method that may optionally be called after SaveChanges().
        /// This clears the cache without making any change to the current transaction.
        /// </summary>
        public void ClearCache()
        {
            DbUnitOfWork.ClearCache();
        }

        /// <summary>
        /// Saves changes
        /// </summary>
        /// <returns></returns>
        public int SaveChanges()
        {
            return DbUnitOfWork.SaveChanges();
        }

        /// <summary>
        /// Saves changes
        /// </summary>
        /// <returns></returns>
        public async Task<int> SaveChangesAsync()
        {
            return await DbUnitOfWork.SaveChangesAsync();
        }

        /// <summary>
        /// Method to be called if multiple saves are to be performed within a transaction
        /// </summary>
        /// <param name="isolationLevel"></param>
        public void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            DbUnitOfWork.BeginTransaction(isolationLevel);
        }

        /// <summary>
        /// Method to be called if multiple saves are to be performed within a transaction
        /// </summary>
        /// <param name="isolationLevel"></param>
        /// <returns></returns>
        public async Task BeginTransactionAsync(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            await DbUnitOfWork.BeginTransactionAsync(isolationLevel);
        }

        /// <summary>
        /// Method to be called once the unit of work is complete
        /// </summary>
        /// <returns></returns>
        public int Complete()
        {
            int result = DbUnitOfWork.Complete();
            return result;
        }

        /// <summary>
        /// Method to be called once the unit of work is complete
        /// </summary>
        /// <returns></returns>
        public async Task<int> CompleteAsync()
        {
            int result = await DbUnitOfWork.CompleteAsync();
            return result;
        }

        /// <summary>
        /// Method to be called to rollback the unit of work
        /// </summary>
        public void Rollback()
        {
            // NOTE: No asynchronous variant of Rollback() exists in Ef6 or EfCore 2.2
            DbUnitOfWork.Rollback();
        }

        /// <summary>
        /// Method to be called to rollback the unit of work
        /// </summary>
        /// <returns></returns>
        public async Task RollbackAsync()
        {
            // NOTE: No asynchronous variant of Rollback() exists in Ef6 or EfCore 2.2
            DbUnitOfWork.Rollback();
            await Task.FromResult<object>(null);
        }

        /// <summary>
        /// Dispose the unit of work
        /// </summary>
        public void Dispose()
        {
            DbUnitOfWork.Dispose();
        }

        #endregion
    }
}
