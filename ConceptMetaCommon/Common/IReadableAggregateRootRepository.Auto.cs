/****************************
 * IReadableAggregateRootRepository.Auto.cs
 ****************************/
namespace ConceptMeta.Common
{
    /// <summary>
    /// Readable Repository Interface for Aggregate Roots
    /// </summary>
    public partial interface IReadableAggregateRootRepository<TAggregateRoot>
        : IReadableRepository<TAggregateRoot>,
        IReadableAggregateRootSyncRepository<TAggregateRoot>,
        IReadableAggregateRootAsyncRepository<TAggregateRoot>
        where TAggregateRoot : class
    {
    }
}
