/****************************
 * EfCoreUnitOfWork.Auto.cs
 ****************************/
using System.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace ConceptMeta.Common.EfCore
{
    /// <summary>
    /// EfCore Unit Of Work class
    /// </summary>
    public partial class EfCoreUnitOfWork<TDbContext>
        : ITransactionalUnitOfWork
        where TDbContext : DbContext
    {

        #region Instance Variables
        protected readonly TDbContext _context;
        protected IDbContextTransaction _transaction;

        #endregion

        #region Constructors
        public EfCoreUnitOfWork(TDbContext dbContext)
        {
            _context = dbContext;
        }

        #endregion

        #region Instance Methods

        /// <summary>
        /// A method that may optionally be called after SaveChanges().
        /// This clears the cache without making any change to the current transaction.
        /// </summary>
        public void ClearCache()
        {
            _context.ChangeTracker.Clear();
        }

        /// <summary>
        /// Saves changes
        /// </summary>
        /// <returns></returns>
        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        /// <summary>
        /// Saves changes
        /// </summary>
        /// <returns></returns>
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Method to be called if multiple saves are to be performed within a transaction
        /// </summary>
        /// <param name="isolationLevel"></param>
        public void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            _transaction = _context.Database.BeginTransaction(isolationLevel);
        }

        /// <summary>
        /// Method to be called if multiple saves are to be performed within a transaction
        /// </summary>
        /// <param name="isolationLevel"></param>
        /// <returns></returns>
        public async Task BeginTransactionAsync(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            _transaction = await _context.Database.BeginTransactionAsync(isolationLevel);
        }

        /// <summary>
        /// Method to be called once the unit of work is complete
        /// </summary>
        /// <returns></returns>
        public int Complete()
        {
            int result = _context.SaveChanges();
            if (_transaction != null)
            {
                _transaction.Commit();
            }
            return result;
        }

        /// <summary>
        /// Method to be called once the unit of work is complete
        /// </summary>
        /// <returns></returns>
        public async Task<int> CompleteAsync()
        {
            int result = await _context.SaveChangesAsync();
            if (_transaction != null)
            {
                _transaction.Commit();
            }
            return result;
        }

        /// <summary>
        /// Method to be called to rollback the unit of work
        /// </summary>
        public void Rollback()
        {
            // NOTE: No asynchronous variant of Rollback() exists in Ef6 or EfCore 2.2
            _transaction.Rollback();
        }

        /// <summary>
        /// Method to be called to rollback the unit of work
        /// </summary>
        /// <returns></returns>
        public async Task RollbackAsync()
        {
            // NOTE: No asynchronous variant of Rollback() exists in Ef6 or EfCore 2.2
            _transaction.Rollback();
            await Task.FromResult<object>(null);
        }

        /// <summary>
        /// Dispose the unit of work
        /// </summary>
        public void Dispose()
        {
            if (_transaction != null)
            {
                _transaction.Dispose();
            }
            _context.Dispose();
        }

        #endregion
    }
}
