/****************************
 * IQueryableReadWriteEntityRepository.Auto.cs
 ****************************/
namespace ConceptMeta.Common
{
    /// <summary>
    /// Queryable Read/Write Repository interface for a relational data store
    /// </summary>
    public partial interface IQueryableReadWriteEntityRepository<TEntity>
        : IReadWriteEntityRepository<TEntity>,
        IQueryableEntityRepository<TEntity>,
        IQueryableReadWriteEntitySyncRepository<TEntity>,
        IQueryableReadWriteEntityAsyncRepository<TEntity>
        where TEntity : class
    {
    }
}
