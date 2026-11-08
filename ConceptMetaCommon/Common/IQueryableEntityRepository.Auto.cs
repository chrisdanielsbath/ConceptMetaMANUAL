/****************************
 * IQueryableEntityRepository.Auto.cs
 ****************************/
namespace ConceptMeta.Common
{
    /// <summary>
    /// Queryable Repository interface for a relational data store
    /// </summary>
    public partial interface IQueryableEntityRepository<TEntity>
        : IReadableEntityRepository<TEntity>,
        IQueryableEntitySyncRepository<TEntity>,
        IQueryableEntityAsyncRepository<TEntity>
        where TEntity : class
    {
    }
}
