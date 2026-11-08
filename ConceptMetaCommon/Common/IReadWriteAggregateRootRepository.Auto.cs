/****************************
 * IReadWriteAggregateRootRepository.Auto.cs
 ****************************/
namespace ConceptMeta.Common
{
    /// <summary>
    /// Read/Write Repository Interface for Aggregate Roots
    /// </summary>
    public partial interface IReadWriteAggregateRootRepository<TAggregateRoot>
        : IReadableAggregateRootRepository<TAggregateRoot>,
        IReadWriteAggregateRootSyncRepository<TAggregateRoot>,
        IReadWriteAggregateRootAsyncRepository<TAggregateRoot>
        where TAggregateRoot : class
    {
    }
}
