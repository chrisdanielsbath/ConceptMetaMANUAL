/****************************
 * IReadableBlueprintAggregateRootRepository.Auto.cs
 ****************************/
namespace ConceptMeta.Common
{
    /// <summary>
    /// Readable Repository Interface for Blueprint Aggregate Roots
    /// </summary>
    public partial interface IReadableBlueprintAggregateRootRepository<TAggregateRoot>
        : IReadableBlueprintRepository<TAggregateRoot>,
        IReadableBlueprintAggregateRootSyncRepository<TAggregateRoot>,
        IReadableBlueprintAggregateRootAsyncRepository<TAggregateRoot>
        where TAggregateRoot : class
    {
    }
}
