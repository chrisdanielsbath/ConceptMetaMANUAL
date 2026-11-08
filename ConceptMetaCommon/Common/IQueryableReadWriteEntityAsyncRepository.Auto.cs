/****************************
 * IQueryableReadWriteEntityAsyncRepository.Auto.cs
 ****************************/
namespace ConceptMeta.Common
{
    /// <summary>
    /// Asynchronous Queryable Read/Write Repository interface for a relational data store
    /// </summary>
    public partial interface IQueryableReadWriteEntityAsyncRepository<TEntity>
        : IReadWriteEntityAsyncRepository<TEntity>,
        IQueryableEntityAsyncRepository<TEntity>
        where TEntity : class
    {
    }
}
