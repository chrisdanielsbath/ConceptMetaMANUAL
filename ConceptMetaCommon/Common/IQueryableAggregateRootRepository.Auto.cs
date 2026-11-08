/****************************
 * IQueryableAggregateRootRepository.Auto.cs
 ****************************/
namespace ConceptMeta.Common
{
    /// <summary>
    /// Queryable Repository Interface for Aggregate Roots
    /// </summary>
    public partial interface IQueryableAggregateRootRepository<TAggregateRoot>
        : IReadableAggregateRootRepository<TAggregateRoot>,
        IQueryableAggregateRootSyncRepository<TAggregateRoot>,
        IQueryableAggregateRootAsyncRepository<TAggregateRoot>
        where TAggregateRoot : class
    {
    }
}
