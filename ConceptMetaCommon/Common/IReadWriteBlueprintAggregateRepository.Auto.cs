/****************************
 * IReadWriteBlueprintAggregateRepository.Auto.cs
 ****************************/
namespace ConceptMeta.Common
{
    /// <summary>
    /// Read/Write Repository Interface for Blueprint Aggregates
    /// </summary>
    public partial interface IReadWriteBlueprintAggregateRepository<TAggregate>
        : IReadableBlueprintAggregateRepository<TAggregate>,
        IReadWriteRepository<TAggregate>,
        IReadWriteBlueprintAggregateSyncRepository<TAggregate>,
        IReadWriteBlueprintAggregateAsyncRepository<TAggregate>
        where TAggregate : class
    {
    }
}
