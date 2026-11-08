/****************************
 * IQueryableAggregateRootAsyncRepository.Auto.cs
 ****************************/
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ConceptMeta.Common
{
    /// <summary>
    /// Asynchronous Queryable Repository Interface for Aggregate Roots
    /// </summary>
    public partial interface IQueryableAggregateRootAsyncRepository<TAggregateRoot>
        : IReadableAggregateRootAsyncRepository<TAggregateRoot>
        where TAggregateRoot : class
    {

        #region Methods that find objects

        /// <summary>
        /// Finds aggregates that satisfy the given condition
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<IEnumerable<TAggregateRoot>> FindAggregatesAsync(Expression<Func<TAggregateRoot, bool>> predicate);

        /// <summary>
        /// Finds the number of aggregates that satisfy the given condition
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<int> FindAggregatesCountAsync(Expression<Func<TAggregateRoot, bool>> predicate);

        /// <summary>
        /// Finds aggregates that satisfy the given condition
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="orderBy"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<IEnumerable<TAggregateRoot>> FindAggregatesAsync<TOrderBy>(
            Expression<Func<TAggregateRoot, bool>> predicate,
            Expression<Func<TAggregateRoot, TOrderBy>> orderBy,
            int pageIndex,
            int pageSize);

        #endregion
    }
}
