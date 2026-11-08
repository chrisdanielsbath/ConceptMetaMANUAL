/****************************
 * IReadWriteBlueprintAggregateRootRepository.Auto.cs
 ****************************/
namespace ConceptMeta.Common
{
    /// <summary>
    /// ReadWrite Repository Interface for Blueprint Aggregate Roots
    /// </summary>
    public partial interface IReadWriteBlueprintAggregateRootRepository<TAggregateRoot>
        : IReadableBlueprintAggregateRootRepository<TAggregateRoot>,
        IReadWriteBlueprintRepository<TAggregateRoot>,
        IReadWriteBlueprintAggregateRootSyncRepository<TAggregateRoot>,
        IReadWriteBlueprintAggregateRootAsyncRepository<TAggregateRoot>
        where TAggregateRoot : class
    {
    }
}
