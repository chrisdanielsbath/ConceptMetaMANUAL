/****************************
 * IQueryableReadWriteBlueprintAggregateRootSyncRepository.Auto.cs
 ****************************/
namespace ConceptMeta.Common
{
    /// <summary>
    /// Synchronous Queryable Read/Write Repository interface for Blueprint Aggregate Roots
    /// </summary>
    public partial interface IQueryableReadWriteBlueprintAggregateRootSyncRepository<TAggregateRoot>
        : IReadWriteBlueprintAggregateRootSyncRepository<TAggregateRoot>,
        IQueryableBlueprintAggregateRootSyncRepository<TAggregateRoot>
        where TAggregateRoot : class
    {
    }
}
