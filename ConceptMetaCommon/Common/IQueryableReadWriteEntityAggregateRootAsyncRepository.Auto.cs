/****************************
 * IQueryableReadWriteEntityAggregateRootAsyncRepository.Auto.cs
 ****************************/
namespace ConceptMeta.Common
{
    /// <summary>
    /// Asynchronous Queryable Read/Write Repository interface for Aggregate Root Entities
    /// </summary>
    public partial interface IQueryableReadWriteEntityAggregateRootAsyncRepository<TAggregateRoot>
        : IReadWriteEntityAggregateRootAsyncRepository<TAggregateRoot>,
        IQueryableEntityAggregateRootAsyncRepository<TAggregateRoot>
        where TAggregateRoot : class
    {
    }
}
