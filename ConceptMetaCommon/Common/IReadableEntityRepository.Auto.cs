/****************************
 * IReadableEntityRepository.Auto.cs
 ****************************/
namespace ConceptMeta.Common
{
    /// <summary>
    /// Readable Repository interface for a relational data store
    /// </summary>
    public partial interface IReadableEntityRepository<TEntity>
        : IReadableRepository<TEntity>,
        IReadableEntitySyncRepository<TEntity>,
        IReadableEntityAsyncRepository<TEntity>
        where TEntity : class
    {
    }
}
