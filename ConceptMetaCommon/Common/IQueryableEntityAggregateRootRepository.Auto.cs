/****************************
 * IQueryableEntityAggregateRootRepository.Auto.cs
 ****************************/
namespace ConceptMeta.Common
{
    /// <summary>
    /// Queryable Repository Interface for Aggregate Root Entities
    /// </summary>
    public partial interface IQueryableEntityAggregateRootRepository<TAggregateRoot>
        : IReadableEntityAggregateRootRepository<TAggregateRoot>,
        IQueryableEntityAggregateRootSyncRepository<TAggregateRoot>,
        IQueryableEntityAggregateRootAsyncRepository<TAggregateRoot>
        where TAggregateRoot : class
    {
    }
}
