/****************************
 * IQueryableEntityAggregateRootAsyncRepository.Auto.cs
 ****************************/
namespace ConceptMeta.Common
{
    /// <summary>
    /// Asynchronous Queryable Repository Interface for Aggregate Root Entities
    /// </summary>
    public partial interface IQueryableEntityAggregateRootAsyncRepository<TAggregateRoot>
        : IReadableEntityAggregateRootAsyncRepository<TAggregateRoot>,
        IQueryableAsyncRepository<TAggregateRoot>
        where TAggregateRoot : class
    {
    }
}
