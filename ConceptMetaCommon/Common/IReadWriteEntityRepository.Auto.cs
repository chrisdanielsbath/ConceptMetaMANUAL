/****************************
 * IReadWriteEntityRepository.Auto.cs
 ****************************/
namespace ConceptMeta.Common
{
    /// <summary>
    /// Read/Write Repository interface for a relational data store
    /// </summary>
    public partial interface IReadWriteEntityRepository<TEntity>
        : IReadableEntityRepository<TEntity>,
        IReadWriteRepository<TEntity>,
        IReadWriteEntitySyncRepository<TEntity>,
        IReadWriteEntityAsyncRepository<TEntity>
        where TEntity : class
    {
    }
}
