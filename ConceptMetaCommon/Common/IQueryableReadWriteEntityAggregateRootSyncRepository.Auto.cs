/****************************
 * IQueryableReadWriteEntityAggregateRootSyncRepository.Auto.cs
 ****************************/
namespace ConceptMeta.Common
{
    /// <summary>
    /// Synchronous Queryable Read/Write Repository interface for Aggregate Root Entities
    /// </summary>
    public partial interface IQueryableReadWriteEntityAggregateRootSyncRepository<TAggregateRoot>
        : IReadWriteEntityAggregateRootSyncRepository<TAggregateRoot>,
        IQueryableEntityAggregateRootSyncRepository<TAggregateRoot>
        where TAggregateRoot : class
    {
    }
}
