/****************************
 * IQueryableReadWriteAggregateRootAsyncRepository.Auto.cs
 ****************************/
namespace ConceptMeta.Common
{
    /// <summary>
    /// Asynchronous Queryable Read/Write Repository interface for Aggregate Roots
    /// </summary>
    public partial interface IQueryableReadWriteAggregateRootAsyncRepository<TAggregateRoot>
        : IReadWriteAggregateRootAsyncRepository<TAggregateRoot>,
        IQueryableAggregateRootAsyncRepository<TAggregateRoot>
        where TAggregateRoot : class
    {
    }
}
