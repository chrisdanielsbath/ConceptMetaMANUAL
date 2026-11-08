/****************************
 * IQueryableReadWriteEntitySyncRepository.Auto.cs
 ****************************/
namespace ConceptMeta.Common
{
    /// <summary>
    /// Synchronous Queryable Read/Write Repository interface for a relational data store
    /// </summary>
    public partial interface IQueryableReadWriteEntitySyncRepository<TEntity>
        : IReadWriteEntitySyncRepository<TEntity>,
        IQueryableEntitySyncRepository<TEntity>
        where TEntity : class
    {
    }
}
