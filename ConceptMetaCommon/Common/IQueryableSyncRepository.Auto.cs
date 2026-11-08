/****************************
 * IQueryableSyncRepository.Auto.cs
 ****************************/
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ConceptMeta.Common
{
    /// <summary>
    /// Queryable Synchronous Repository Interface
    /// </summary>
    public partial interface IQueryableSyncRepository<T>
        : IReadableSyncRepository<T>
        where T : class
    {

        #region Methods that find objects

        /// <summary>
        /// Finds the objects that satisfy the specified condition
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Finds the number of objects that satisfy the specified condition
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        int FindCount(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Finds the objects that satisfy the specified condition
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="orderBy"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        IEnumerable<T> Find<TOrderBy>(
            Expression<Func<T, bool>> predicate,
            Expression<Func<T, TOrderBy>> orderBy,
            int pageIndex,
            int pageSize);

        #endregion
    }
}
