/****************************
 * IReadWriteEntityAggregateRootRepository.Auto.cs
 ****************************/
namespace ConceptMeta.Common
{
    /// <summary>
    /// Read/Write Repository Interface for Aggregate Root Entities
    /// </summary>
    public partial interface IReadWriteEntityAggregateRootRepository<TAggregateRoot>
        : IReadableEntityAggregateRootRepository<TAggregateRoot>,
        IReadWriteEntityRepository<TAggregateRoot>,
        IReadWriteEntityAggregateRootSyncRepository<TAggregateRoot>,
        IReadWriteEntityAggregateRootAsyncRepository<TAggregateRoot>
        where TAggregateRoot : class
    {
    }
}
