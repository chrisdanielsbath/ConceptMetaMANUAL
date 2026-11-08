/****************************
 * IQueryableReadWriteEntityAggregateRootRepository.Auto.cs
 ****************************/
namespace ConceptMeta.Common
{
    /// <summary>
    /// Queryable Read/Write Repository interface for Aggregate Root Entities
    /// </summary>
    public partial interface IQueryableReadWriteEntityAggregateRootRepository<TAggregateRoot>
        : IReadWriteEntityAggregateRootRepository<TAggregateRoot>,
        IQueryableEntityAggregateRootRepository<TAggregateRoot>,
        IQueryableReadWriteEntityAggregateRootSyncRepository<TAggregateRoot>,
        IQueryableReadWriteEntityAggregateRootAsyncRepository<TAggregateRoot>
        where TAggregateRoot : class
    {
    }
}
