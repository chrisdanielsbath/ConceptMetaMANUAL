/****************************
 * IReadableEntityAggregateRootRepository.Auto.cs
 ****************************/
namespace ConceptMeta.Common
{
    /// <summary>
    /// Readable Repository Interface for Aggregate Root Entities
    /// </summary>
    public partial interface IReadableEntityAggregateRootRepository<TAggregateRoot>
        : IReadableAggregateRootRepository<TAggregateRoot>,
        IReadableEntityAggregateRootSyncRepository<TAggregateRoot>,
        IReadableEntityAggregateRootAsyncRepository<TAggregateRoot>
        where TAggregateRoot : class
    {
    }
}
