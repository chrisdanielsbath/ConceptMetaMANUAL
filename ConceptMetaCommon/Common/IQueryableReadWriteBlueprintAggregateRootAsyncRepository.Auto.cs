/****************************
 * IQueryableReadWriteBlueprintAggregateRootAsyncRepository.Auto.cs
 ****************************/
namespace ConceptMeta.Common
{
    /// <summary>
    /// Asynchronous Queryable Read/Write Repository interface for Blueprint Aggregate Roots
    /// </summary>
    public partial interface IQueryableReadWriteBlueprintAggregateRootAsyncRepository<TAggregateRoot>
        : IReadWriteBlueprintAggregateRootAsyncRepository<TAggregateRoot>,
        IQueryableBlueprintAggregateRootAsyncRepository<TAggregateRoot>
        where TAggregateRoot : class
    {
    }
}
