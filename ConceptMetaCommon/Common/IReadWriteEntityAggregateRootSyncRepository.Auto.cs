/****************************
 * IReadWriteEntityAggregateRootSyncRepository.Auto.cs
 ****************************/
namespace ConceptMeta.Common
{
    /// <summary>
    /// Synchronous Read/Write Repository Interface for Aggregate Root Entities
    /// </summary>
    public partial interface IReadWriteEntityAggregateRootSyncRepository<TAggregateRoot>
        : IReadableEntityAggregateRootSyncRepository<TAggregateRoot>,
        IReadWriteEntitySyncRepository<TAggregateRoot>
        where TAggregateRoot : class
    {
    }
}
