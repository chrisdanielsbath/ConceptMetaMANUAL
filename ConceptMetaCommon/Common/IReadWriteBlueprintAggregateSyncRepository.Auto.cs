/****************************
 * IReadWriteBlueprintAggregateSyncRepository.Auto.cs
 ****************************/
namespace ConceptMeta.Common
{
    /// <summary>
    /// Synchronous Read/Write Repository Interface for Blueprint Aggregates
    /// </summary>
    public partial interface IReadWriteBlueprintAggregateSyncRepository<TAggregate>
        : IReadableBlueprintAggregateSyncRepository<TAggregate>,
        IReadWriteSyncRepository<TAggregate>
        where TAggregate : class
    {
    }
}
