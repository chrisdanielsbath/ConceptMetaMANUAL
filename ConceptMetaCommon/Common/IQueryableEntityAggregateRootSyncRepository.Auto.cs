/****************************
 * IQueryableEntityAggregateRootSyncRepository.Auto.cs
 ****************************/
namespace ConceptMeta.Common
{
    /// <summary>
    /// Synchronous Queryable Repository Interface for Aggregate Root Entities
    /// </summary>
    public partial interface IQueryableEntityAggregateRootSyncRepository<TAggregateRoot>
        : IReadableEntityAggregateRootSyncRepository<TAggregateRoot>,
        IQueryableSyncRepository<TAggregateRoot>
        where TAggregateRoot : class
    {
    }
}
