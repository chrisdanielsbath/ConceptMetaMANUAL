/****************************
 * IQueryableAggregateRootSyncRepository.Auto.cs
 ****************************/
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ConceptMeta.Common
{
    /// <summary>
    /// Synchronous Queryable Repository Interface for Aggregate Roots
    /// </summary>
    public partial interface IQueryableAggregateRootSyncRepository<TAggregateRoot>
        : IReadableAggregateRootSyncRepository<TAggregateRoot>
        where TAggregateRoot : class
    {

        #region Methods that find objects

        /// <summary>
        /// Finds aggregates that satisfy the given condition
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        IEnumerable<TAggregateRoot> FindAggregates(Expression<Func<TAggregateRoot, bool>> predicate);

        /// <summary>
        /// Finds the number of aggregates that satisfy the given condition
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        int FindAggregatesCount(Expression<Func<TAggregateRoot, bool>> predicate);

        /// <summary>
        /// Finds aggregates that satisfy the given condition
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="orderBy"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        IEnumerable<TAggregateRoot> FindAggregates<TOrderBy>(
            Expression<Func<TAggregateRoot, bool>> predicate,
            Expression<Func<TAggregateRoot, TOrderBy>> orderBy,
            int pageIndex,
            int pageSize);

        #endregion
    }
}
