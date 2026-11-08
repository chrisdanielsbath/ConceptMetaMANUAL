/****************************
 * DomainUnitOfWork.Auto.cs
 ****************************/
using System.Data;
using System.Threading.Tasks;
using AutoMapper;

namespace ConceptMeta.Common.Domain
{
    /// <summary>
    /// Domain Unit Of Work class
    /// </summary>
    public abstract partial class DomainUnitOfWork<TBlueprintUnitOfWork>
        : IDomainUnitOfWork<TBlueprintUnitOfWork>
        where TBlueprintUnitOfWork : class, IBlueprintUnitOfWork
    {

        #region Constructors
        public DomainUnitOfWork(TBlueprintUnitOfWork blueprintUnitOfWork)
        {
            BlueprintUnitOfWork = blueprintUnitOfWork;
        }

        #endregion

        #region Instance Properties

        /// <summary>
        /// The Unit Of Work class to be used when persisting and retrieving blueprint objects
        /// </summary>
        public TBlueprintUnitOfWork BlueprintUnitOfWork { get; private set; }

        #endregion

        #region Instance Properties that must be implemented separately in each concrete class

        /// <summary>
        /// The mapper to be used when converting to blueprint objects
        /// </summary>
        public abstract IMapper ToBlueprintMapper { get; }

        /// <summary>
        /// The mapper to be used when converting from blueprint objects
        /// </summary>
        public abstract IMapper FromBlueprintMapper { get; }

        #endregion

        #region Instance Methods

        /// <summary>
        /// A method that may optionally be called after SaveChanges().
        /// This clears the cache without making any change to the current transaction.
        /// </summary>
        public void ClearCache()
        {
            BlueprintUnitOfWork.ClearCache();
        }

        /// <summary>
        /// Saves changes
        /// </summary>
        /// <returns></returns>
        public int SaveChanges()
        {
            return BlueprintUnitOfWork.SaveChanges();
        }

        /// <summary>
        /// Saves changes
        /// </summary>
        /// <returns></returns>
        public async Task<int> SaveChangesAsync()
        {
            return await BlueprintUnitOfWork.SaveChangesAsync();
        }

        /// <summary>
        /// Method to be called if multiple saves are to be performed within a transaction
        /// </summary>
        /// <param name="isolationLevel"></param>
        public void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            BlueprintUnitOfWork.BeginTransaction(isolationLevel);
        }

        /// <summary>
        /// Method to be called if multiple saves are to be performed within a transaction
        /// </summary>
        /// <param name="isolationLevel"></param>
        /// <returns></returns>
        public async Task BeginTransactionAsync(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            await BlueprintUnitOfWork.BeginTransactionAsync(isolationLevel);
        }

        /// <summary>
        /// Method to be called once the unit of work is complete
        /// </summary>
        /// <returns></returns>
        public int Complete()
        {
            int result = BlueprintUnitOfWork.Complete();
            return result;
        }

        /// <summary>
        /// Method to be called once the unit of work is complete
        /// </summary>
        /// <returns></returns>
        public async Task<int> CompleteAsync()
        {
            int result = await BlueprintUnitOfWork.CompleteAsync();
            return result;
        }

        /// <summary>
        /// Method to be called to rollback the unit of work
        /// </summary>
        public void Rollback()
        {
            // NOTE: No asynchronous variant of Rollback() exists in Ef6 or EfCore 2.2
            BlueprintUnitOfWork.Rollback();
        }

        /// <summary>
        /// Method to be called to rollback the unit of work
        /// </summary>
        /// <returns></returns>
        public async Task RollbackAsync()
        {
            // NOTE: No asynchronous variant of Rollback() exists in Ef6 or EfCore 2.2
            BlueprintUnitOfWork.Rollback();
            await Task.FromResult<object>(null);
        }

        /// <summary>
        /// Dispose the unit of work
        /// </summary>
        public void Dispose()
        {
            BlueprintUnitOfWork.Dispose();
        }

        #endregion
    }
}
