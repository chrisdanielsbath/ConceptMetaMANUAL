/****************************
 * IQueryableReadWriteAggregateRootSyncRepository.Auto.cs
 ****************************/
namespace ConceptMeta.Common
{
    /// <summary>
    /// Synchronous Queryable Read/Write Repository interface for Aggregate Roots
    /// </summary>
    public partial interface IQueryableReadWriteAggregateRootSyncRepository<TAggregateRoot>
        : IReadWriteAggregateRootSyncRepository<TAggregateRoot>,
        IQueryableAggregateRootSyncRepository<TAggregateRoot>
        where TAggregateRoot : class
    {
    }
}
