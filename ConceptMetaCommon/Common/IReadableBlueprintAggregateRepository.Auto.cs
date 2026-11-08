/****************************
 * IReadableBlueprintAggregateRepository.Auto.cs
 ****************************/
namespace ConceptMeta.Common
{
    /// <summary>
    /// Readable Repository Interface for Blueprint Aggregates
    /// </summary>
    public partial interface IReadableBlueprintAggregateRepository<TAggregate>
        : IReadableRepository<TAggregate>,
        IReadableBlueprintAggregateSyncRepository<TAggregate>,
        IReadableBlueprintAggregateAsyncRepository<TAggregate>
        where TAggregate : class
    {
    }
}
