/****************************
 * IQueryableAsyncRepository.Auto.cs
 ****************************/
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ConceptMeta.Common
{
    /// <summary>
    /// Queryable Asynchronous Repository Interface
    /// </summary>
    public partial interface IQueryableAsyncRepository<T>
        : IReadableAsyncRepository<T>
        where T : class
    {

        #region Methods that find objects

        /// <summary>
        /// Finds the objects that satisfy the specified condition
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Finds the number of objects that satisfy the specified condition
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<int> FindCountAsync(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Finds the objects that satisfy the specified condition
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="orderBy"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> FindAsync<TOrderBy>(
            Expression<Func<T, bool>> predicate,
            Expression<Func<T, TOrderBy>> orderBy,
            int pageIndex,
            int pageSize);

        #endregion
    }
}
