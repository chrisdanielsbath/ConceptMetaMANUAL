/****************************
 * IQueryableEntitySyncRepository.Auto.cs
 ****************************/
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ConceptMeta.Common
{
    /// <summary>
    /// Synchronous Queryable Repository interface for a relational data store
    /// </summary>
    public partial interface IQueryableEntitySyncRepository<TEntity>
        : IReadableEntitySyncRepository<TEntity>,
        IQueryableSyncRepository<TEntity>
        where TEntity : class
    {

        #region Methods that find objects

        /// <summary>
        /// Gets all objects in the collection
        /// </summary>
        /// <param name="includes"></param>
        /// <returns></returns>
        IEnumerable<TEntity> GetAll(IList<string> includes);

        /// <summary>
        /// Finds the objects that satisfy the specified condition
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        IEnumerable<TEntity> Find(
            Expression<Func<TEntity, bool>> predicate,
            IList<string> includes);

        /// <summary>
        /// Finds the objects that satisfy the specified condition
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="orderBy"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        IEnumerable<TEntity> Find<TOrderBy>(
            Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, TOrderBy>> orderBy,
            int pageIndex,
            int pageSize,
            IList<string> includes);

        #endregion
    }
}
