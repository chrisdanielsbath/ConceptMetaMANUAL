/****************************
 * EfCoreAggregateRootRepository.Auto.cs
 ****************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ConceptMeta.Common.EfCore
{
    /// <summary>
    /// EfCore repository for aggregate roots
    /// </summary>
    public abstract partial class EfCoreAggregateRootRepository<TAggregateRoot>
        : EfCoreRepository<TAggregateRoot>,
        IQueryableReadWriteEntityAggregateRootRepository<TAggregateRoot>
        where TAggregateRoot : class
    {

        #region Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="EfCoreAggregateRootRepository{TAggregateRoot}" /> class
        /// </summary>
        /// <param name="context"></param>
        public EfCoreAggregateRootRepository(DbContext context)
            : base (context)
        {
            PopulateAggregateIncludes();
        }

        #endregion

        #region Instance Properties

        /// <summary>
        /// Paths to the child entities that should be returned by each query
        /// </summary>
        protected IList<string> AggregateIncludes { get; } = new List<string>();

        #endregion

        #region Protected methods that must be implemented separately within each concrete class

        /// <summary>
        /// Adds child entities to the set of items to be returned by queries
        /// </summary>
        protected abstract void PopulateAggregateIncludes();

        #endregion

        #region Methods that find objects

        /// <summary>
        /// Gets an aggregate from the data store
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        public TAggregateRoot GetAggregate(params object[] keyValues)
        {
            Expression<Func<TAggregateRoot, bool>> predicate = GetPrimaryKeyPredicate(keyValues);
            return (Find(predicate, AggregateIncludes)).FirstOrDefault();
        }

        /// <summary>
        /// Gets an aggregate from the data store
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        public async Task<TAggregateRoot> GetAggregateAsync(params object[] keyValues)
        {
            Expression<Func<TAggregateRoot, bool>> predicate = GetPrimaryKeyPredicate(keyValues);
            return (await FindAsync(predicate, AggregateIncludes)).FirstOrDefault();
        }

        /// <summary>
        /// Gets all aggregates from the data store
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TAggregateRoot> GetAllAggregates()
        {
            return GetAll(AggregateIncludes);
        }

        /// <summary>
        /// Gets all aggregates from the data store
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<TAggregateRoot>> GetAllAggregatesAsync()
        {
            return await GetAllAsync(AggregateIncludes);
        }

        /// <summary>
        /// Gets the aggregate that has the supplied business key
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        public TAggregateRoot GetAggregateByBusinessKey(params object[] keyValues)
        {
            Expression<Func<TAggregateRoot, bool>> predicate = GetBusinessKeyPredicate(keyValues);

            return (Find(predicate, AggregateIncludes)).FirstOrDefault();
        }

        /// <summary>
        /// Gets the aggregate that has the supplied business key
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        public async Task<TAggregateRoot> GetAggregateByBusinessKeyAsync(params object[] keyValues)
        {
            Expression<Func<TAggregateRoot, bool>> predicate = GetBusinessKeyPredicate(keyValues);

            return (await FindAsync(predicate, AggregateIncludes)).FirstOrDefault();
        }

        /// <summary>
        /// Finds aggregates that satisfy the given condition
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public IEnumerable<TAggregateRoot> FindAggregates(Expression<Func<TAggregateRoot, bool>> predicate)
        {
            return Find(predicate, AggregateIncludes);
        }

        /// <summary>
        /// Finds aggregates that satisfy the given condition
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TAggregateRoot>> FindAggregatesAsync(Expression<Func<TAggregateRoot, bool>> predicate)
        {
            return await FindAsync(predicate, AggregateIncludes);
        }

        /// <summary>
        /// Finds the number of aggregates that satisfy the given condition
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public int FindAggregatesCount(Expression<Func<TAggregateRoot, bool>> predicate)
        {
            return FindCount(predicate);
        }

        /// <summary>
        /// Finds the number of aggregates that satisfy the given condition
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<int> FindAggregatesCountAsync(Expression<Func<TAggregateRoot, bool>> predicate)
        {
            return await FindCountAsync(predicate);
        }

        /// <summary>
        /// Finds aggregates that satisfy the given condition
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="orderBy"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public IEnumerable<TAggregateRoot> FindAggregates<TOrderBy>(
            Expression<Func<TAggregateRoot, bool>> predicate,
            Expression<Func<TAggregateRoot, TOrderBy>> orderBy,
            int pageIndex,
            int pageSize)
        {
            return Find(predicate, orderBy, pageIndex, pageSize, AggregateIncludes);
        }

        /// <summary>
        /// Finds aggregates that satisfy the given condition
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="orderBy"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TAggregateRoot>> FindAggregatesAsync<TOrderBy>(
            Expression<Func<TAggregateRoot, bool>> predicate,
            Expression<Func<TAggregateRoot, TOrderBy>> orderBy,
            int pageIndex,
            int pageSize)
        {
            return await FindAsync(predicate, orderBy, pageIndex, pageSize, AggregateIncludes);
        }

        #endregion
    }
}
