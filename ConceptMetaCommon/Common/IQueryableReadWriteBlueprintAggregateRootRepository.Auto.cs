/****************************
 * IQueryableReadWriteBlueprintAggregateRootRepository.Auto.cs
 ****************************/
namespace ConceptMeta.Common
{
    /// <summary>
    /// Queryable Read/Write Repository interface for Blueprint Aggregate Roots
    /// </summary>
    public partial interface IQueryableReadWriteBlueprintAggregateRootRepository<TAggregateRoot>
        : IReadWriteBlueprintAggregateRootRepository<TAggregateRoot>,
        IQueryableBlueprintAggregateRootRepository<TAggregateRoot>,
        IQueryableReadWriteBlueprintAggregateRootSyncRepository<TAggregateRoot>,
        IQueryableReadWriteBlueprintAggregateRootAsyncRepository<TAggregateRoot>
        where TAggregateRoot : class
    {
    }
}
