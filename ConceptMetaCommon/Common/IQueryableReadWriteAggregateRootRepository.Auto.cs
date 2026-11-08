/****************************
 * IQueryableReadWriteAggregateRootRepository.Auto.cs
 ****************************/
namespace ConceptMeta.Common
{
    /// <summary>
    /// Queryable Read/Write Repository interface for Aggregate Roots
    /// </summary>
    public partial interface IQueryableReadWriteAggregateRootRepository<TAggregateRoot>
        : IReadWriteAggregateRootRepository<TAggregateRoot>,
        IQueryableAggregateRootRepository<TAggregateRoot>,
        IQueryableReadWriteAggregateRootSyncRepository<TAggregateRoot>,
        IQueryableReadWriteAggregateRootAsyncRepository<TAggregateRoot>
        where TAggregateRoot : class
    {
    }
}
